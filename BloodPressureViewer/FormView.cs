// bss, all rights reserved.

using BloodPressureViewer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BloodPressureViewer
{
    public partial class FormView : Form
    {
        /// <summary>
        /// “关闭”操作被取消
        /// </summary>
        private bool cancelClosing = false;

        /// <summary>
        /// 窗体初始化
        /// </summary>
        public FormView()
        {
            InitializeComponent();
            initComboBoxes();   // 初始化下拉列表
            loadSettings();     // 载入默认设置
            buttonCheckSP_Click(this, null);    // 检查串口
            if (Settings.Default.autoStartSP)   // 自动打开串口
            {
                try
                {
                    buttonOpenCloseSP_Click(this, null);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabelError.Text = ex.Message;
                }
            }
            // 定时器
            timerReadData.Interval = 50;
            timerReadData.Tick += new EventHandler(readDataFromFile);
            // 双缓冲绘图
            this.DoubleBuffered = true;
            // 快捷键
            HotKey.RegisterHotKey(Handle, 1000, HotKey.KeyModifiers.Shift | HotKey.KeyModifiers.Alt, Keys.O);
            HotKey.RegisterHotKey(Handle, 1001, HotKey.KeyModifiers.Shift | HotKey.KeyModifiers.Alt, Keys.X);
        }

        /// <summary>
        /// 窗体第一次显示时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormView_Shown(object sender, EventArgs e)
        {
            this.Left = Settings.Default.windowLeft;
            this.Top = Settings.Default.windowTop;
        }

        /// <summary>
        /// “打开/关闭串口”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenCloseSP_Click(object sender, EventArgs e)
        {
            buttonOpenCloseSP.Enabled = false;
            if ((!serialPort.IsOpen) && ("关闭串口(&X)" == buttonOpenCloseSP.Text))
            {
                enableSPControls(true);
                buttonOpenCloseSP.Text = "打开串口(&O)";
                toolStripStatusLabelSP.Text = "就绪";
                System.GC.Collect();    // 强制垃圾回收
            }
            if (serialPort.IsOpen)  // 要关闭串口
            {
                try
                {
                    closeSerialPort();
                }
                catch (Exception ex)
                {
                    toolStripStatusLabelError.Text = ex.Message;
                }
                enableSPControls(true);
                buttonOpenCloseSP.Text = "打开串口(&O)";
                toolStripStatusLabelSP.Text = "就绪";
                System.GC.Collect();    // 强制垃圾回收
            }
            else                    // 要打开串口
            {
                applySPSettings();
                if (openSerialPort())
                {
                    enableSPControls(false);
                    buttonOpenCloseSP.Text = "关闭串口(&X)";
                    toolStripStatusLabelSP.Text = serialPort.PortName;
                }
            }
            buttonOpenCloseSP.Enabled = true;
        }

        /// <summary>
        /// “检测串口”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheckSP_Click(object sender, EventArgs e)
        {
            buttonCheckSP.Enabled = false;
            comboBoxSelectSP.Items.Clear();
            // 检测可用串口并显示在下拉列表中
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            foreach (string port in ports)
            {
                comboBoxSelectSP.Items.Add(port);
            }
            // 自动选中串口
            if (comboBoxSelectSP.Items.Count > 0)
            {
                int index = 0;
                // 尝试选择原来的COM
                foreach (object obj in comboBoxSelectSP.Items)
                {
                    if (obj.ToString() == serialPort.PortName)
                    {
                        comboBoxSelectSP.SelectedIndex = index;
                    }
                    else
                    {
                        index++;
                    }
                }
                if (index == comboBoxSelectSP.Items.Count)
                {
                    comboBoxSelectSP.SelectedIndex = 0;
                    serialPort.PortName = comboBoxSelectSP.SelectedItem.ToString();
                }
                buttonOpenCloseSP.Enabled = true;
            }
            else
            {
                buttonOpenCloseSP.Enabled = false;
            }
            toolStripStatusLabelError.Text = "";
            buttonCheckSP.Enabled = true;
        }

        /// <summary>
        /// “清空缓冲区”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearGet_Click(object sender, EventArgs e)
        {
            textBoxGet.Clear();
            bufStringBuilder.Clear();
            //dataProcesser.Clear();
        }

        /// <summary>
        /// “清空计数”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearCount_Click(object sender, EventArgs e)
        {
            receivedCount = 0;
            errorCount = 0;
            dataCount = 0;
            segCount = 0;
            toolStripStatusLabelReceivedCount.Text = "Get: ";
            toolStripStatusLabelErrorCount.Text = "Err: ";
            //toolStripStatusLabelDataCount.Text = "Data: ";
            toolStripStatusLabelSegCount.Text = "Seg: ";
            //toolStripStatusLabelPulseCount.Text = "Pulse: ";
        }

        /// <summary>
        /// 自动显示最新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxReceived_TextChanged(object sender, EventArgs e)
        {
            textBoxGet.SelectionStart = textBoxGet.Text.Length;
            textBoxGet.ScrollToCaret();
        }

        /// <summary>
        /// 启用/禁用对串口进行设置的控件
        /// </summary>
        /// <param name="spClosed">串口关闭。true:启用; false:禁用</param>
        protected void enableSPControls(bool spClosed)
        {
            buttonCheckSP.Enabled = spClosed;
            buttonSend.Enabled = !spClosed;
            comboBoxSelectSP.Enabled = spClosed;
            comboBoxBaudRate.Enabled = spClosed;
            comboBoxParity.Enabled = spClosed;
            comboBoxDataBits.Enabled = spClosed;
            comboBoxStopBits.Enabled = spClosed;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            cancelClosing = false;
            if (Settings.Default.askClose)
            {
                DialogResult dr = MessageBox.Show("将要退出，下次是否询问？", "智能血压计", MessageBoxButtons.YesNoCancel);
                if (DialogResult.Yes == dr)
                {
                    base.OnClosing(e);
                }
                else if (DialogResult.No == dr)
                {
                    Settings.Default.askClose = false;
                    base.OnClosing(e);
                }
                else
                {
                    e.Cancel = true;
                    cancelClosing = true;
                    return;
                }
            }
            base.OnClosing(e);
        }

        /// <summary>
        /// 将要退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelClosing)
            {
                return;
            }
            saveSettings();
            if (serialPort.IsOpen)  // 退出前串口应关闭
            {
                buttonOpenCloseSP_Click(this, null);
            }

            if (swRcv != null)
            {
                swRcv.Close();
            }
            if (srData != null)
            {
                srData.Close();
            }
            if (swPulse != null)
            {
                swPulse.Close();
            }
        }

        /// <summary>
        /// “发送”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            serialPortSend(textBoxSend.Text);
        }

        /// <summary>
        /// “写入文件”复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWriteRcv_CheckedChanged(object sender, EventArgs e)
        {
            if (null == swRcv)
            {
                swRcv = new StreamWriter(String.Format("{0}__data.txt",
                    DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss")));
            }
        }

        /// <summary>
        /// “打开文件”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt";
            ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    srData = new StreamReader(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                buttonOpenFile.Enabled = false;
                timerReadData.Start();
                isReadingData = true;
            }
        }

        /// <summary>
        /// 串口发送数据区域按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                serialPortSend(textBoxSend.Text + "\r\n");
            }
        }

        /// <summary>
        /// “写入数值”复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWritePulse_CheckedChanged(object sender, EventArgs e)
        {
            if (null == swPulse)
            {
                swPulse = new StreamWriter(String.Format("{0}__pulse.txt",
                    DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss")));
            }
        }
    }
}
