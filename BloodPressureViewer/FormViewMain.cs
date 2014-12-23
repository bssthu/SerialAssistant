// bss, all rights reserved.

//using BloodPressureData;
using BloodPressureViewer.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodPressureViewer
{
    public partial class FormView
    {
        /// <summary>
        /// 写入串口收到的数据的文件
        /// </summary>
        private StreamWriter swRcv = null;

        /// <summary>
        /// 写入滤波结果
        /// </summary>
        public StreamWriter swPulse = null;

        /// <summary>
        /// 从文件提取数据到串口的数据源
        /// </summary>
        private StreamReader srData = null;

        /// <summary>
        /// 从文件读取数据的定时器
        /// </summary>
        private System.Windows.Forms.Timer timerReadData = new System.Windows.Forms.Timer();

        /// <summary>
        /// 正在从文件读取数据到串口
        /// </summary>
        private bool isReadingData = false;

        /// <summary>
        /// 载入应用程序设置
        /// </summary>
        protected void loadSettings()
        {
            try
            {
                if (Settings.Default.useGetHex)
                {
                    radioButtonGetHex.Checked = true;
                }
                else
                {
                    radioButtonGetASCII.Checked = true;
                }
                if (Settings.Default.useSendHex)
                {
                    radioButtonSendHex.Checked = true;
                }
                else
                {
                    radioButtonSendASCII.Checked = true;
                }
                checkBoxWriteRcv.Checked = Settings.Default.writeRcv;
                checkBoxFastRefresh.Checked = Settings.Default.fastRefresh;
                checkBoxWritePulse.Checked = Settings.Default.writePulse;
                comboBoxBaudRate.SelectedIndex = Settings.Default.baudRateIndex;
                comboBoxParity.SelectedItem = Settings.Default.parity;
                comboBoxDataBits.SelectedIndex = Settings.Default.dataBitsIndex;
                comboBoxStopBits.SelectedIndex = Settings.Default.stopBitsIndex;
                serialPort.PortName = Settings.Default.portName;
                this.Size = Settings.Default.windowSize;
                this.WindowState = Settings.Default.windowState;
                try
                {
                    tabControl.SelectTab(Settings.Default.selectedTabpageName);
                }
                catch { }
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
            }
        }

        /// <summary>
        /// 保存应用程序设置
        /// </summary>
        protected void saveSettings()
        {
            Settings.Default.useGetHex = radioButtonGetHex.Checked;
            Settings.Default.useSendHex = radioButtonSendHex.Checked;
            if (comboBoxSelectSP.Items.Count > 0)
            {
                Settings.Default.portName = comboBoxSelectSP.SelectedItem.ToString();
            }
            Settings.Default.baudRateIndex = comboBoxBaudRate.SelectedIndex;
            Settings.Default.parity = (Parity)comboBoxParity.SelectedItem;
            Settings.Default.dataBitsIndex = comboBoxDataBits.SelectedIndex;
            Settings.Default.stopBitsIndex = comboBoxStopBits.SelectedIndex;
            Settings.Default.windowSize = this.Size;
            Settings.Default.windowLeft = this.Left;
            Settings.Default.windowTop = this.Top;
            Settings.Default.windowState = this.WindowState;
            Settings.Default.autoStartSP = serialPort.IsOpen;
            Settings.Default.selectedTabpageName = tabControl.SelectedTab.Name;
            Settings.Default.writeRcv = checkBoxWriteRcv.Checked;
            Settings.Default.fastRefresh = checkBoxFastRefresh.Checked;
            Settings.Default.writePulse = checkBoxWritePulse.Checked;
            Settings.Default.Save();
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        protected void initComboBoxes()
        {
            try
            {
                comboBoxParity.Items.Add(Parity.None);
                comboBoxParity.Items.Add(Parity.Odd);
                comboBoxParity.Items.Add(Parity.Even);
                comboBoxParity.Items.Add(Parity.Mark);
                comboBoxParity.Items.Add(Parity.Space);
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
            }
        }

        /// <summary>
        /// 应用串口设置
        /// </summary>
        protected void applySPSettings()
        {
            try
            {
                serialPort.PortName = comboBoxSelectSP.SelectedItem.ToString();
                serialPort.BaudRate =
                    int.Parse(comboBoxBaudRate.SelectedItem.ToString());
                serialPort.Parity = (Parity)comboBoxParity.SelectedItem;
                serialPort.DataBits =
                    int.Parse(comboBoxDataBits.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
            }
            toolStripStatusLabelError.Text = "";
        }

        /// <summary>
        /// 从文件中载入数据到串口进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readDataFromFile(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                if (!srData.EndOfStream)
                {
                    //string strIn = srData.ReadLine() + "\r\n";
                    //dataProcesser.GetData(strIn);

                    ////bufStringBuilder.Append(strIn);
                    ////if (bufStringBuilder.Length > maxStringLength)  // 长度限制
                    ////{
                    ////    bufStringBuilder.Remove(0, bufStringBuilder.Length - maxStringLength);
                    ////}
                    ////if (!checkBoxFastRefresh.Checked)
                    ////{
                    ////    textBoxGet.Text = bufStringBuilder.ToString();
                    ////}

                    //// 绘制
                    //panelAir.Invalidate();
                    //panelFFT.Invalidate();
                    //panelIFFTResult.Invalidate();
                    //panelFIR.Invalidate();
                    //panelAirFromMCU.Invalidate();
                    //panelPulseFromMCU.Invalidate();
                    //dataCount ++;
                    //toolStripStatusLabelDataCount.Text = String.Format("Data: {0}", dataCount);
                }
                else    // 结束
                {
                    timerReadData.Stop();
                    srData.Close();
                    srData = null;
                    buttonOpenFile.Enabled = true;
                    isReadingData = false;
                    return;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (WM_HOTKEY == m.Msg)
            {
                switch (m.WParam.ToInt32())
                {
                    case 1000:  // Shift+Alt+O
                        if (!serialPort.IsOpen)
                        {
                            buttonOpenCloseSP_Click(this, null);
                        }
                        break;
                    case 1001:  // Shift+Alt+X
                        if (serialPort.IsOpen)
                        {
                            buttonOpenCloseSP_Click(this, null);
                        }
                        break;
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        } 
    }
}
