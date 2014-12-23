// bss, all rights reserved.

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodPressureViewer
{
    public partial class FormView
    {
        /// <summary>
        /// 新收到的数据
        /// </summary>
        private StringBuilder bufStringBuilder = new StringBuilder();

        /// <summary>
        /// 串口通信接收计数
        /// </summary>
        private uint receivedCount = 0;

        /// <summary>
        /// 串口通信收到的血压数据条数
        /// </summary>
        private uint dataCount = 0;

        /// <summary>
        /// 串口通信中错误计数
        /// </summary>
        private uint errorCount = 0;

        /// <summary>
        /// 串口通信收到中断的次数
        /// </summary>
        private uint segCount = 0;

        /// <summary>
        /// 正在关闭串口，
        /// 请停止接收数据的操作
        /// </summary>
        private bool closing = false;

        /// <summary>
        /// 正在使用UI，
        /// 请先不要关闭串口
        /// </summary>
        private bool listening = false;

        /// <summary>
        /// 字符串的最大长度
        /// </summary>
        private const int maxStringLength = 0x3FFF;

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns>串口状态发生改变</returns>
        protected bool openSerialPort()
        {
            if (serialPort.IsOpen)   // 串口已经开着
            {
                return false;
            }
            try
            {
                // 等待UI
                while (listening)
                {
                    Application.DoEvents();
                }
                serialPort.Open();
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
                return false;
            }
            toolStripStatusLabelError.Text = "";
            return true;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns>串口状态发生改变</returns>
        protected bool closeSerialPort()
        {
            if (!serialPort.IsOpen)  // 串口没有开着
            {
                return false;
            }
            try
            {
                closing = true;
                // 等待UI
                while (listening)
                {
                    Application.DoEvents();
                }
                serialPort.Close();
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
                return false;
            }
            finally
            {
                closing = false;
            }
            toolStripStatusLabelError.Text = "";
            return true;
        }

        /// <summary>
        /// 串口收到数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(
            object sender, SerialDataReceivedEventArgs e)
        {
            if (closing)
            {
                return;
            }
            try
            {
                segCount++;
                toolStripStatusLabelSegCount.Text = String.Format("Seg: {0}", segCount);
                listening = true;
                int bytesToRead = serialPort.BytesToRead;   // 防止意外更改
                byte[] buf = new byte[bytesToRead];
                serialPort.Read(buf, 0, bytesToRead);
                receivedCount += (uint)bytesToRead;
                //dataCount += dataProcesser.GetData(Encoding.ASCII.GetString(buf));
                
                if (checkBoxWriteRcv.Checked)
                {
                    swRcv.Write(Encoding.ASCII.GetString(buf));
                }
                
                // 更新文本框
                this.Invoke((EventHandler)(delegate
                {
                    //toolStripStatusLabelDataCount.Text = String.Format("Data: {0}", dataCount);
                    if (radioButtonGetHex.Checked)
                    {
                        foreach (byte b in buf)
                        {
                            bufStringBuilder.Append(b.ToString("X2"));
                            bufStringBuilder.Append(' ');
                        }
                    }
                    else if (radioButtonGetASCII.Checked)
                    {
                        // 防止字符串在/0后的内容无法显示
                        for (int i = 0; i < buf.Length; i++)
                        {
                            if (0 == buf[i])
                            {
                                buf[i] = 1;
                            }
                        }
                        //bufStringBuilder.Append(Encoding.ASCII.GetString(buf));
                        try
                        {
                            bufStringBuilder.Append(Encoding.GetEncoding(textBoxEncoding.Text).GetString(buf));
                        }
                        catch { }
                    }
                    if (bufStringBuilder.Length > maxStringLength)
                    {
                        bufStringBuilder.Remove(0, bufStringBuilder.Length - maxStringLength);
                    }
                    if (checkBoxFastRefresh.Checked)
                    {
                        textBoxGet.Text = bufStringBuilder.ToString();
                    }
                    toolStripStatusLabelReceivedCount.Text = String.Format("Get: {0}", receivedCount);
                }));
            }
            catch { }
            finally
            {
                listening = false;
            }
        }

        /// <summary>
        /// 串口收到错误数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (closing)
            {
                return;
            }
            try
            {
                listening = true;
                errorCount++;
                this.Invoke((EventHandler)(delegate
                {
                    toolStripStatusLabelErrorCount.Text =
                        string.Format("Err: {0}", errorCount);
                }));
            }
            catch { }
            finally
            {
                listening = false;
            }
        }

        /// <summary>
        /// 串口发送数据
        /// </summary>
        /// <param name="stringSend">待发字符串</param>
        /// <param name="forceASCII">强制使用ASCII格式发送</param>
        protected void serialPortSend(string stringSend, bool forceASCII = false)
        {
            if (closing)
            {
                return;
            }
            try
            {
                listening = true;
                if (!forceASCII && radioButtonSendHex.Checked)
                {
                    string[] hexs = stringSend.Split(' ');
                    byte[] buf = new byte[hexs.Length];
                    int i = 0;
                    foreach (string hex in hexs)
                    {
                        if (hex == "")
                        {
                            continue;
                        }
                        if (hex.Length > 2)
                        {
                            throw (new Exception(String.Format(
                                "十六进制数{0}格式错误，输入应形如“a0 df”", hex)));
                        }
                        buf[i++] = Convert.ToByte(hex, 16);
                    }
                    serialPort.Write(buf, 0, buf.Length);
                }
                else
                {
                    serialPort.Write(stringSend);
                }
                toolStripStatusLabelError.Text = "";
            }
            catch (Exception ex)
            {
                toolStripStatusLabelError.Text = ex.Message;
            }
            finally
            {
                listening = false;
            }
        }
    }
}
