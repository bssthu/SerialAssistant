using BloodPressureViewer;
using System.Windows.Forms;
using System;

namespace BloodPressureViewer
{
    partial class FormView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                srData.Dispose();
                swPulse.Dispose();
                swRcv.Dispose();
            }
            catch (Exception)
            {
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStripForm = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelReceivedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelErrorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSegCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageSerialPort = new System.Windows.Forms.TabPage();
            this.checkBoxWritePulse = new System.Windows.Forms.CheckBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.checkBoxFastRefresh = new System.Windows.Forms.CheckBox();
            this.checkBoxWriteRcv = new System.Windows.Forms.CheckBox();
            this.groupBoxSend = new System.Windows.Forms.GroupBox();
            this.radioButtonSendHex = new System.Windows.Forms.RadioButton();
            this.buttonClearSend = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.radioButtonSendASCII = new System.Windows.Forms.RadioButton();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.labelStopBits = new System.Windows.Forms.Label();
            this.labelDataBits = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.groupBoxReceive = new System.Windows.Forms.GroupBox();
            this.radioButtonGetCustom = new System.Windows.Forms.RadioButton();
            this.textBoxEncoding = new System.Windows.Forms.TextBox();
            this.radioButtonGetHex = new System.Windows.Forms.RadioButton();
            this.buttonClearCount = new System.Windows.Forms.Button();
            this.buttonClearGet = new System.Windows.Forms.Button();
            this.radioButtonGetASCII = new System.Windows.Forms.RadioButton();
            this.textBoxGet = new System.Windows.Forms.TextBox();
            this.buttonOpenCloseSP = new System.Windows.Forms.Button();
            this.buttonCheckSP = new System.Windows.Forms.Button();
            this.comboBoxSelectSP = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statusStripForm.SuspendLayout();
            this.tabPageSerialPort.SuspendLayout();
            this.groupBoxSend.SuspendLayout();
            this.groupBoxReceive.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // statusStripForm
            // 
            this.statusStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSP,
            this.toolStripStatusLabelReceivedCount,
            this.toolStripStatusLabelErrorCount,
            this.toolStripStatusLabelSegCount,
            this.toolStripStatusLabelError});
            this.statusStripForm.Location = new System.Drawing.Point(0, 339);
            this.statusStripForm.Name = "statusStripForm";
            this.statusStripForm.Size = new System.Drawing.Size(528, 22);
            this.statusStripForm.TabIndex = 0;
            this.statusStripForm.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSP
            // 
            this.toolStripStatusLabelSP.AutoSize = false;
            this.toolStripStatusLabelSP.Name = "toolStripStatusLabelSP";
            this.toolStripStatusLabelSP.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabelSP.Text = "就绪";
            this.toolStripStatusLabelSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelReceivedCount
            // 
            this.toolStripStatusLabelReceivedCount.AutoSize = false;
            this.toolStripStatusLabelReceivedCount.Name = "toolStripStatusLabelReceivedCount";
            this.toolStripStatusLabelReceivedCount.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelReceivedCount.Text = "Get: ";
            this.toolStripStatusLabelReceivedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelErrorCount
            // 
            this.toolStripStatusLabelErrorCount.AutoSize = false;
            this.toolStripStatusLabelErrorCount.Name = "toolStripStatusLabelErrorCount";
            this.toolStripStatusLabelErrorCount.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabelErrorCount.Text = "Err: ";
            this.toolStripStatusLabelErrorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelSegCount
            // 
            this.toolStripStatusLabelSegCount.AutoSize = false;
            this.toolStripStatusLabelSegCount.Name = "toolStripStatusLabelSegCount";
            this.toolStripStatusLabelSegCount.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabelSegCount.Text = "Seg:";
            this.toolStripStatusLabelSegCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelError
            // 
            this.toolStripStatusLabelError.Name = "toolStripStatusLabelError";
            this.toolStripStatusLabelError.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelError.Text = "未出错";
            // 
            // tabPageSerialPort
            // 
            this.tabPageSerialPort.Controls.Add(this.checkBoxWritePulse);
            this.tabPageSerialPort.Controls.Add(this.buttonOpenFile);
            this.tabPageSerialPort.Controls.Add(this.checkBoxFastRefresh);
            this.tabPageSerialPort.Controls.Add(this.checkBoxWriteRcv);
            this.tabPageSerialPort.Controls.Add(this.groupBoxSend);
            this.tabPageSerialPort.Controls.Add(this.comboBoxStopBits);
            this.tabPageSerialPort.Controls.Add(this.comboBoxDataBits);
            this.tabPageSerialPort.Controls.Add(this.labelStopBits);
            this.tabPageSerialPort.Controls.Add(this.labelDataBits);
            this.tabPageSerialPort.Controls.Add(this.labelParity);
            this.tabPageSerialPort.Controls.Add(this.comboBoxParity);
            this.tabPageSerialPort.Controls.Add(this.labelBaudRate);
            this.tabPageSerialPort.Controls.Add(this.comboBoxBaudRate);
            this.tabPageSerialPort.Controls.Add(this.groupBoxReceive);
            this.tabPageSerialPort.Controls.Add(this.buttonOpenCloseSP);
            this.tabPageSerialPort.Controls.Add(this.buttonCheckSP);
            this.tabPageSerialPort.Controls.Add(this.comboBoxSelectSP);
            this.tabPageSerialPort.Location = new System.Drawing.Point(4, 22);
            this.tabPageSerialPort.Name = "tabPageSerialPort";
            this.tabPageSerialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSerialPort.Size = new System.Drawing.Size(496, 297);
            this.tabPageSerialPort.TabIndex = 0;
            this.tabPageSerialPort.Text = "串口助手";
            this.tabPageSerialPort.UseVisualStyleBackColor = true;
            // 
            // checkBoxWritePulse
            // 
            this.checkBoxWritePulse.AutoSize = true;
            this.checkBoxWritePulse.Location = new System.Drawing.Point(204, 39);
            this.checkBoxWritePulse.Name = "checkBoxWritePulse";
            this.checkBoxWritePulse.Size = new System.Drawing.Size(72, 16);
            this.checkBoxWritePulse.TabIndex = 30;
            this.checkBoxWritePulse.Text = "写入数值";
            this.checkBoxWritePulse.UseVisualStyleBackColor = true;
            this.checkBoxWritePulse.CheckedChanged += new System.EventHandler(this.checkBoxWritePulse_CheckedChanged);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(6, 35);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(90, 23);
            this.buttonOpenFile.TabIndex = 29;
            this.buttonOpenFile.Text = "打开文件";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // checkBoxFastRefresh
            // 
            this.checkBoxFastRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFastRefresh.AutoSize = true;
            this.checkBoxFastRefresh.Location = new System.Drawing.Point(418, 39);
            this.checkBoxFastRefresh.Name = "checkBoxFastRefresh";
            this.checkBoxFastRefresh.Size = new System.Drawing.Size(72, 16);
            this.checkBoxFastRefresh.TabIndex = 28;
            this.checkBoxFastRefresh.Text = "实时刷新";
            this.checkBoxFastRefresh.UseVisualStyleBackColor = true;
            // 
            // checkBoxWriteRcv
            // 
            this.checkBoxWriteRcv.AutoSize = true;
            this.checkBoxWriteRcv.Location = new System.Drawing.Point(102, 39);
            this.checkBoxWriteRcv.Name = "checkBoxWriteRcv";
            this.checkBoxWriteRcv.Size = new System.Drawing.Size(96, 16);
            this.checkBoxWriteRcv.TabIndex = 10;
            this.checkBoxWriteRcv.Text = "写入原始数据";
            this.checkBoxWriteRcv.UseVisualStyleBackColor = true;
            this.checkBoxWriteRcv.CheckedChanged += new System.EventHandler(this.checkBoxWriteRcv_CheckedChanged);
            // 
            // groupBoxSend
            // 
            this.groupBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSend.Controls.Add(this.radioButtonSendHex);
            this.groupBoxSend.Controls.Add(this.buttonClearSend);
            this.groupBoxSend.Controls.Add(this.textBoxSend);
            this.groupBoxSend.Controls.Add(this.buttonSend);
            this.groupBoxSend.Controls.Add(this.radioButtonSendASCII);
            this.groupBoxSend.Location = new System.Drawing.Point(6, 189);
            this.groupBoxSend.Name = "groupBoxSend";
            this.groupBoxSend.Size = new System.Drawing.Size(484, 76);
            this.groupBoxSend.TabIndex = 10;
            this.groupBoxSend.TabStop = false;
            this.groupBoxSend.Text = "字符串发送区";
            // 
            // radioButtonSendHex
            // 
            this.radioButtonSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonSendHex.AutoSize = true;
            this.radioButtonSendHex.Location = new System.Drawing.Point(6, 50);
            this.radioButtonSendHex.Name = "radioButtonSendHex";
            this.radioButtonSendHex.Size = new System.Drawing.Size(71, 16);
            this.radioButtonSendHex.TabIndex = 12;
            this.radioButtonSendHex.Text = "十六进制";
            this.radioButtonSendHex.UseVisualStyleBackColor = true;
            // 
            // buttonClearSend
            // 
            this.buttonClearSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearSend.Location = new System.Drawing.Point(284, 47);
            this.buttonClearSend.Name = "buttonClearSend";
            this.buttonClearSend.Size = new System.Drawing.Size(94, 23);
            this.buttonClearSend.TabIndex = 14;
            this.buttonClearSend.Text = "清空发送区";
            this.buttonClearSend.UseVisualStyleBackColor = true;
            // 
            // textBoxSend
            // 
            this.textBoxSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSend.Location = new System.Drawing.Point(7, 20);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(471, 21);
            this.textBoxSend.TabIndex = 11;
            this.textBoxSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSend_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(384, 47);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 23);
            this.buttonSend.TabIndex = 15;
            this.buttonSend.Text = "发送(&S)";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // radioButtonSendASCII
            // 
            this.radioButtonSendASCII.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonSendASCII.AutoSize = true;
            this.radioButtonSendASCII.Location = new System.Drawing.Point(83, 50);
            this.radioButtonSendASCII.Name = "radioButtonSendASCII";
            this.radioButtonSendASCII.Size = new System.Drawing.Size(65, 16);
            this.radioButtonSendASCII.TabIndex = 13;
            this.radioButtonSendASCII.Text = "ASCII码";
            this.radioButtonSendASCII.UseVisualStyleBackColor = true;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "1.5"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(335, 271);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(41, 20);
            this.comboBoxStopBits.TabIndex = 23;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(251, 271);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(31, 20);
            this.comboBoxDataBits.TabIndex = 21;
            // 
            // labelStopBits
            // 
            this.labelStopBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStopBits.AutoSize = true;
            this.labelStopBits.Location = new System.Drawing.Point(288, 274);
            this.labelStopBits.Name = "labelStopBits";
            this.labelStopBits.Size = new System.Drawing.Size(41, 12);
            this.labelStopBits.TabIndex = 22;
            this.labelStopBits.Text = "停止位";
            // 
            // labelDataBits
            // 
            this.labelDataBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDataBits.AutoSize = true;
            this.labelDataBits.Location = new System.Drawing.Point(208, 274);
            this.labelDataBits.Name = "labelDataBits";
            this.labelDataBits.Size = new System.Drawing.Size(41, 12);
            this.labelDataBits.TabIndex = 20;
            this.labelDataBits.Text = "数据位";
            // 
            // labelParity
            // 
            this.labelParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(119, 274);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(41, 12);
            this.labelParity.TabIndex = 18;
            this.labelParity.Text = "校验位";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(166, 271);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(36, 20);
            this.comboBoxParity.TabIndex = 19;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(6, 274);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(41, 12);
            this.labelBaudRate.TabIndex = 16;
            this.labelBaudRate.Text = "波特率";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "256000",
            "128000",
            "115200",
            "57600",
            "38400",
            "28800",
            "19200",
            "14400",
            "9600",
            "4800",
            "2400",
            "1200",
            "600"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(53, 271);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(60, 20);
            this.comboBoxBaudRate.TabIndex = 17;
            // 
            // groupBoxReceive
            // 
            this.groupBoxReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReceive.Controls.Add(this.radioButtonGetCustom);
            this.groupBoxReceive.Controls.Add(this.textBoxEncoding);
            this.groupBoxReceive.Controls.Add(this.radioButtonGetHex);
            this.groupBoxReceive.Controls.Add(this.buttonClearCount);
            this.groupBoxReceive.Controls.Add(this.buttonClearGet);
            this.groupBoxReceive.Controls.Add(this.radioButtonGetASCII);
            this.groupBoxReceive.Controls.Add(this.textBoxGet);
            this.groupBoxReceive.Location = new System.Drawing.Point(6, 64);
            this.groupBoxReceive.Name = "groupBoxReceive";
            this.groupBoxReceive.Size = new System.Drawing.Size(484, 119);
            this.groupBoxReceive.TabIndex = 4;
            this.groupBoxReceive.TabStop = false;
            this.groupBoxReceive.Text = "接收缓冲区";
            // 
            // radioButtonGetCustom
            // 
            this.radioButtonGetCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonGetCustom.AutoSize = true;
            this.radioButtonGetCustom.Location = new System.Drawing.Point(154, 93);
            this.radioButtonGetCustom.Name = "radioButtonGetCustom";
            this.radioButtonGetCustom.Size = new System.Drawing.Size(35, 16);
            this.radioButtonGetCustom.TabIndex = 11;
            this.radioButtonGetCustom.Text = "码";
            this.radioButtonGetCustom.UseVisualStyleBackColor = true;
            // 
            // textBoxEncoding
            // 
            this.textBoxEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxEncoding.Location = new System.Drawing.Point(195, 92);
            this.textBoxEncoding.Name = "textBoxEncoding";
            this.textBoxEncoding.Size = new System.Drawing.Size(76, 21);
            this.textBoxEncoding.TabIndex = 10;
            this.textBoxEncoding.Text = "gb2312";
            // 
            // radioButtonGetHex
            // 
            this.radioButtonGetHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonGetHex.AutoSize = true;
            this.radioButtonGetHex.Location = new System.Drawing.Point(6, 93);
            this.radioButtonGetHex.Name = "radioButtonGetHex";
            this.radioButtonGetHex.Size = new System.Drawing.Size(71, 16);
            this.radioButtonGetHex.TabIndex = 6;
            this.radioButtonGetHex.Text = "十六进制";
            this.radioButtonGetHex.UseVisualStyleBackColor = true;
            // 
            // buttonClearCount
            // 
            this.buttonClearCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearCount.Location = new System.Drawing.Point(284, 90);
            this.buttonClearCount.Name = "buttonClearCount";
            this.buttonClearCount.Size = new System.Drawing.Size(94, 23);
            this.buttonClearCount.TabIndex = 8;
            this.buttonClearCount.Text = "清空计数";
            this.buttonClearCount.UseVisualStyleBackColor = true;
            this.buttonClearCount.Click += new System.EventHandler(this.buttonClearCount_Click);
            // 
            // buttonClearGet
            // 
            this.buttonClearGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearGet.Location = new System.Drawing.Point(384, 90);
            this.buttonClearGet.Name = "buttonClearGet";
            this.buttonClearGet.Size = new System.Drawing.Size(94, 23);
            this.buttonClearGet.TabIndex = 9;
            this.buttonClearGet.Text = "清空缓冲区";
            this.buttonClearGet.UseVisualStyleBackColor = true;
            this.buttonClearGet.Click += new System.EventHandler(this.buttonClearGet_Click);
            // 
            // radioButtonGetASCII
            // 
            this.radioButtonGetASCII.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonGetASCII.AutoSize = true;
            this.radioButtonGetASCII.Location = new System.Drawing.Point(83, 93);
            this.radioButtonGetASCII.Name = "radioButtonGetASCII";
            this.radioButtonGetASCII.Size = new System.Drawing.Size(65, 16);
            this.radioButtonGetASCII.TabIndex = 7;
            this.radioButtonGetASCII.Text = "ASCII码";
            this.radioButtonGetASCII.UseVisualStyleBackColor = true;
            // 
            // textBoxGet
            // 
            this.textBoxGet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGet.Location = new System.Drawing.Point(6, 20);
            this.textBoxGet.Multiline = true;
            this.textBoxGet.Name = "textBoxGet";
            this.textBoxGet.ReadOnly = true;
            this.textBoxGet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGet.Size = new System.Drawing.Size(472, 64);
            this.textBoxGet.TabIndex = 5;
            this.textBoxGet.TextChanged += new System.EventHandler(this.textBoxReceived_TextChanged);
            // 
            // buttonOpenCloseSP
            // 
            this.buttonOpenCloseSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenCloseSP.Location = new System.Drawing.Point(400, 6);
            this.buttonOpenCloseSP.Name = "buttonOpenCloseSP";
            this.buttonOpenCloseSP.Size = new System.Drawing.Size(90, 23);
            this.buttonOpenCloseSP.TabIndex = 3;
            this.buttonOpenCloseSP.Text = "打开串口(&O)";
            this.buttonOpenCloseSP.UseVisualStyleBackColor = true;
            this.buttonOpenCloseSP.Click += new System.EventHandler(this.buttonOpenCloseSP_Click);
            // 
            // buttonCheckSP
            // 
            this.buttonCheckSP.Location = new System.Drawing.Point(6, 6);
            this.buttonCheckSP.Name = "buttonCheckSP";
            this.buttonCheckSP.Size = new System.Drawing.Size(90, 23);
            this.buttonCheckSP.TabIndex = 1;
            this.buttonCheckSP.Text = "检测串口(&K)";
            this.buttonCheckSP.UseVisualStyleBackColor = true;
            this.buttonCheckSP.Click += new System.EventHandler(this.buttonCheckSP_Click);
            // 
            // comboBoxSelectSP
            // 
            this.comboBoxSelectSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSelectSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectSP.FormattingEnabled = true;
            this.comboBoxSelectSP.Location = new System.Drawing.Point(129, 8);
            this.comboBoxSelectSP.Name = "comboBoxSelectSP";
            this.comboBoxSelectSP.Size = new System.Drawing.Size(238, 20);
            this.comboBoxSelectSP.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageSerialPort);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(504, 323);
            this.tabControl.TabIndex = 24;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 361);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStripForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(530, 370);
            this.Name = "FormView";
            this.Text = "串口助手和谐版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
            this.Shown += new System.EventHandler(this.FormView_Shown);
            this.statusStripForm.ResumeLayout(false);
            this.statusStripForm.PerformLayout();
            this.tabPageSerialPort.ResumeLayout(false);
            this.tabPageSerialPort.PerformLayout();
            this.groupBoxSend.ResumeLayout(false);
            this.groupBoxSend.PerformLayout();
            this.groupBoxReceive.ResumeLayout(false);
            this.groupBoxReceive.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.StatusStrip statusStripForm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelError;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelReceivedCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelErrorCount;
        private System.Windows.Forms.TabPage tabPageSerialPort;
        private System.Windows.Forms.GroupBox groupBoxSend;
        private System.Windows.Forms.RadioButton radioButtonSendHex;
        private System.Windows.Forms.Button buttonClearSend;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.RadioButton radioButtonSendASCII;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.Label labelStopBits;
        private System.Windows.Forms.Label labelDataBits;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.GroupBox groupBoxReceive;
        private System.Windows.Forms.RadioButton radioButtonGetHex;
        private System.Windows.Forms.Button buttonClearCount;
        private System.Windows.Forms.Button buttonClearGet;
        private System.Windows.Forms.RadioButton radioButtonGetASCII;
        private System.Windows.Forms.TextBox textBoxGet;
        private System.Windows.Forms.Button buttonOpenCloseSP;
        private System.Windows.Forms.Button buttonCheckSP;
        private System.Windows.Forms.ComboBox comboBoxSelectSP;
        private System.Windows.Forms.TabControl tabControl;
        private CheckBox checkBoxWriteRcv;
        private CheckBox checkBoxFastRefresh;
        private ToolStripStatusLabel toolStripStatusLabelSegCount;
        private Button buttonOpenFile;
        public CheckBox checkBoxWritePulse;
        private TextBox textBoxEncoding;
        private RadioButton radioButtonGetCustom;
    }
}

