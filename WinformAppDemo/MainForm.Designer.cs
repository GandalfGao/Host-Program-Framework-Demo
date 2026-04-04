namespace WinformAppDemo
{
    partial class MainForm
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
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiPanelTop = new Sunny.UI.UIPanel();
            this.uiPanelLanSet = new Sunny.UI.UIPanel();
            this.uiCBoxLanSetting = new Sunny.UI.UIComboBox();
            this.uiLabLanSet = new Sunny.UI.UILabel();
            this.uiPanelCtrlBox = new Sunny.UI.UIPanel();
            this.picBoxMinus = new System.Windows.Forms.PictureBox();
            this.picBoxClose = new System.Windows.Forms.PictureBox();
            this.uiPanelBottom = new Sunny.UI.UIPanel();
            this.uiTabCtrlContent = new Sunny.UI.UITabControl();
            this.tabPageProdInfo = new System.Windows.Forms.TabPage();
            this.uiPanelQualCheck = new Sunny.UI.UIPanel();
            this.uiTxtBoxResistance = new Sunny.UI.UITextBox();
            this.uiLabResistance = new Sunny.UI.UILabel();
            this.uiSwitchSetLineState = new Sunny.UI.UISwitch();
            this.tabPageInfoQuery = new System.Windows.Forms.TabPage();
            this.uiTxtBarcode = new Sunny.UI.UITextBox();
            this.uiLabBarcode = new Sunny.UI.UILabel();
            this.uiPanelTop.SuspendLayout();
            this.uiPanelLanSet.SuspendLayout();
            this.uiPanelCtrlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).BeginInit();
            this.uiPanelBottom.SuspendLayout();
            this.uiTabCtrlContent.SuspendLayout();
            this.tabPageProdInfo.SuspendLayout();
            this.uiPanelQualCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelTop
            // 
            this.uiPanelTop.Controls.Add(this.uiPanelLanSet);
            this.uiPanelTop.Controls.Add(this.uiPanelCtrlBox);
            this.uiPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelTop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelTop.Location = new System.Drawing.Point(0, 0);
            this.uiPanelTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiPanelTop.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelTop.Name = "uiPanelTop";
            this.uiPanelTop.Size = new System.Drawing.Size(1350, 108);
            this.uiPanelTop.TabIndex = 0;
            this.uiPanelTop.Text = null;
            this.uiPanelTop.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelLanSet
            // 
            this.uiPanelLanSet.BackColor = System.Drawing.Color.Transparent;
            this.uiPanelLanSet.Controls.Add(this.uiCBoxLanSetting);
            this.uiPanelLanSet.Controls.Add(this.uiLabLanSet);
            this.uiPanelLanSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanelLanSet.FillColor = System.Drawing.Color.Transparent;
            this.uiPanelLanSet.FillColor2 = System.Drawing.Color.Transparent;
            this.uiPanelLanSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelLanSet.Location = new System.Drawing.Point(1050, 36);
            this.uiPanelLanSet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelLanSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelLanSet.Name = "uiPanelLanSet";
            this.uiPanelLanSet.Padding = new System.Windows.Forms.Padding(6);
            this.uiPanelLanSet.RectColor = System.Drawing.Color.Transparent;
            this.uiPanelLanSet.Size = new System.Drawing.Size(300, 72);
            this.uiPanelLanSet.TabIndex = 1;
            this.uiPanelLanSet.Text = null;
            this.uiPanelLanSet.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiCBoxLanSetting
            // 
            this.uiCBoxLanSetting.DataSource = null;
            this.uiCBoxLanSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCBoxLanSetting.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiCBoxLanSetting.FillColor = System.Drawing.Color.White;
            this.uiCBoxLanSetting.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCBoxLanSetting.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiCBoxLanSetting.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiCBoxLanSetting.Location = new System.Drawing.Point(154, 6);
            this.uiCBoxLanSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCBoxLanSetting.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiCBoxLanSetting.Name = "uiCBoxLanSetting";
            this.uiCBoxLanSetting.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiCBoxLanSetting.Size = new System.Drawing.Size(140, 60);
            this.uiCBoxLanSetting.SymbolSize = 24;
            this.uiCBoxLanSetting.TabIndex = 1;
            this.uiCBoxLanSetting.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiCBoxLanSetting.Watermark = "";
            this.uiCBoxLanSetting.SelectedIndexChanged += new System.EventHandler(this.UICBoxLanSetting_SelectedIndexChanged);
            // 
            // uiLabLanSet
            // 
            this.uiLabLanSet.BackColor = System.Drawing.Color.Transparent;
            this.uiLabLanSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLabLanSet.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabLanSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabLanSet.Location = new System.Drawing.Point(6, 6);
            this.uiLabLanSet.Name = "uiLabLanSet";
            this.uiLabLanSet.Size = new System.Drawing.Size(148, 60);
            this.uiLabLanSet.TabIndex = 0;
            this.uiLabLanSet.Text = "Language ";
            this.uiLabLanSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiPanelCtrlBox
            // 
            this.uiPanelCtrlBox.BackColor = System.Drawing.SystemColors.Control;
            this.uiPanelCtrlBox.Controls.Add(this.picBoxMinus);
            this.uiPanelCtrlBox.Controls.Add(this.picBoxClose);
            this.uiPanelCtrlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanelCtrlBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(136)))), ((int)(((byte)(255)))));
            this.uiPanelCtrlBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelCtrlBox.Location = new System.Drawing.Point(0, 0);
            this.uiPanelCtrlBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelCtrlBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelCtrlBox.Name = "uiPanelCtrlBox";
            this.uiPanelCtrlBox.Size = new System.Drawing.Size(1350, 36);
            this.uiPanelCtrlBox.TabIndex = 0;
            this.uiPanelCtrlBox.Text = null;
            this.uiPanelCtrlBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBoxMinus
            // 
            this.picBoxMinus.BackColor = System.Drawing.Color.Transparent;
            this.picBoxMinus.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBoxMinus.Image = ((System.Drawing.Image)(resources.GetObject("picBoxMinus.Image")));
            this.picBoxMinus.Location = new System.Drawing.Point(1278, 0);
            this.picBoxMinus.Margin = new System.Windows.Forms.Padding(6);
            this.picBoxMinus.Name = "picBoxMinus";
            this.picBoxMinus.Padding = new System.Windows.Forms.Padding(6);
            this.picBoxMinus.Size = new System.Drawing.Size(36, 36);
            this.picBoxMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMinus.TabIndex = 1;
            this.picBoxMinus.TabStop = false;
            this.picBoxMinus.Click += new System.EventHandler(this.PicBoxMinus_Click);
            this.picBoxMinus.MouseEnter += new System.EventHandler(this.PicBoxMinus_MouseEnter);
            this.picBoxMinus.MouseLeave += new System.EventHandler(this.PicBoxMinus_MouseLeave);
            // 
            // picBoxClose
            // 
            this.picBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.picBoxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("picBoxClose.Image")));
            this.picBoxClose.Location = new System.Drawing.Point(1314, 0);
            this.picBoxClose.Margin = new System.Windows.Forms.Padding(6);
            this.picBoxClose.Name = "picBoxClose";
            this.picBoxClose.Padding = new System.Windows.Forms.Padding(6);
            this.picBoxClose.Size = new System.Drawing.Size(36, 36);
            this.picBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxClose.TabIndex = 0;
            this.picBoxClose.TabStop = false;
            this.picBoxClose.Click += new System.EventHandler(this.PicBoxClose_Click);
            this.picBoxClose.MouseEnter += new System.EventHandler(this.PicBoxClose_MouseEnter);
            this.picBoxClose.MouseLeave += new System.EventHandler(this.PicBoxClose_MouseLeave);
            // 
            // uiPanelBottom
            // 
            this.uiPanelBottom.Controls.Add(this.uiTabCtrlContent);
            this.uiPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelBottom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelBottom.Location = new System.Drawing.Point(0, 108);
            this.uiPanelBottom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uiPanelBottom.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelBottom.Name = "uiPanelBottom";
            this.uiPanelBottom.Size = new System.Drawing.Size(1350, 852);
            this.uiPanelBottom.TabIndex = 1;
            this.uiPanelBottom.Text = null;
            this.uiPanelBottom.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTabCtrlContent
            // 
            this.uiTabCtrlContent.Controls.Add(this.tabPageProdInfo);
            this.uiTabCtrlContent.Controls.Add(this.tabPageInfoQuery);
            this.uiTabCtrlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabCtrlContent.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabCtrlContent.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabCtrlContent.ItemSize = new System.Drawing.Size(340, 40);
            this.uiTabCtrlContent.Location = new System.Drawing.Point(0, 0);
            this.uiTabCtrlContent.MainPage = "";
            this.uiTabCtrlContent.Name = "uiTabCtrlContent";
            this.uiTabCtrlContent.SelectedIndex = 0;
            this.uiTabCtrlContent.Size = new System.Drawing.Size(1350, 852);
            this.uiTabCtrlContent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabCtrlContent.TabIndex = 0;
            this.uiTabCtrlContent.TabPageTextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.uiTabCtrlContent.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPageProdInfo
            // 
            this.tabPageProdInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPageProdInfo.Controls.Add(this.uiPanelQualCheck);
            this.tabPageProdInfo.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageProdInfo.Location = new System.Drawing.Point(0, 40);
            this.tabPageProdInfo.Name = "tabPageProdInfo";
            this.tabPageProdInfo.Size = new System.Drawing.Size(1350, 812);
            this.tabPageProdInfo.TabIndex = 0;
            this.tabPageProdInfo.Text = "Production Information";
            // 
            // uiPanelQualCheck
            // 
            this.uiPanelQualCheck.Controls.Add(this.uiTxtBarcode);
            this.uiPanelQualCheck.Controls.Add(this.uiLabBarcode);
            this.uiPanelQualCheck.Controls.Add(this.uiTxtBoxResistance);
            this.uiPanelQualCheck.Controls.Add(this.uiLabResistance);
            this.uiPanelQualCheck.Controls.Add(this.uiSwitchSetLineState);
            this.uiPanelQualCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanelQualCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanelQualCheck.Location = new System.Drawing.Point(0, 0);
            this.uiPanelQualCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanelQualCheck.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanelQualCheck.Name = "uiPanelQualCheck";
            this.uiPanelQualCheck.Size = new System.Drawing.Size(1350, 812);
            this.uiPanelQualCheck.TabIndex = 0;
            this.uiPanelQualCheck.Text = null;
            this.uiPanelQualCheck.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTxtBoxResistance
            // 
            this.uiTxtBoxResistance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxtBoxResistance.Font = new System.Drawing.Font("楷体", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxtBoxResistance.Location = new System.Drawing.Point(572, 262);
            this.uiTxtBoxResistance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxtBoxResistance.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxtBoxResistance.Name = "uiTxtBoxResistance";
            this.uiTxtBoxResistance.Padding = new System.Windows.Forms.Padding(5);
            this.uiTxtBoxResistance.ReadOnly = true;
            this.uiTxtBoxResistance.ShowText = false;
            this.uiTxtBoxResistance.Size = new System.Drawing.Size(498, 86);
            this.uiTxtBoxResistance.TabIndex = 2;
            this.uiTxtBoxResistance.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTxtBoxResistance.Watermark = "";
            // 
            // uiLabResistance
            // 
            this.uiLabResistance.Font = new System.Drawing.Font("楷体", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabResistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabResistance.Location = new System.Drawing.Point(87, 262);
            this.uiLabResistance.Name = "uiLabResistance";
            this.uiLabResistance.Size = new System.Drawing.Size(356, 86);
            this.uiLabResistance.TabIndex = 1;
            this.uiLabResistance.Text = "电阻值";
            this.uiLabResistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSwitchSetLineState
            // 
            this.uiSwitchSetLineState.ActiveText = "启动";
            this.uiSwitchSetLineState.Font = new System.Drawing.Font("楷体", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitchSetLineState.InActiveText = "停止";
            this.uiSwitchSetLineState.Location = new System.Drawing.Point(87, 36);
            this.uiSwitchSetLineState.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitchSetLineState.Name = "uiSwitchSetLineState";
            this.uiSwitchSetLineState.Size = new System.Drawing.Size(356, 95);
            this.uiSwitchSetLineState.TabIndex = 0;
            this.uiSwitchSetLineState.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.uiSwitchSetLineState.ActiveChanged += new System.EventHandler(this.UISwitchSetLineState_ActiveChanged);
            // 
            // tabPageInfoQuery
            // 
            this.tabPageInfoQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPageInfoQuery.Font = new System.Drawing.Font("微软雅黑", 16.2F);
            this.tabPageInfoQuery.Location = new System.Drawing.Point(0, 40);
            this.tabPageInfoQuery.Name = "tabPageInfoQuery";
            this.tabPageInfoQuery.Size = new System.Drawing.Size(1350, 812);
            this.tabPageInfoQuery.TabIndex = 1;
            this.tabPageInfoQuery.Text = "Information Query";
            // 
            // uiTxtBarcode
            // 
            this.uiTxtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTxtBarcode.Font = new System.Drawing.Font("楷体", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTxtBarcode.Location = new System.Drawing.Point(572, 412);
            this.uiTxtBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTxtBarcode.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTxtBarcode.Name = "uiTxtBarcode";
            this.uiTxtBarcode.Padding = new System.Windows.Forms.Padding(5);
            this.uiTxtBarcode.ReadOnly = true;
            this.uiTxtBarcode.ShowText = false;
            this.uiTxtBarcode.Size = new System.Drawing.Size(498, 86);
            this.uiTxtBarcode.TabIndex = 4;
            this.uiTxtBarcode.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTxtBarcode.Watermark = "";
            // 
            // uiLabBarcode
            // 
            this.uiLabBarcode.Font = new System.Drawing.Font("楷体", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabBarcode.Location = new System.Drawing.Point(87, 412);
            this.uiLabBarcode.Name = "uiLabBarcode";
            this.uiLabBarcode.Size = new System.Drawing.Size(356, 86);
            this.uiLabBarcode.TabIndex = 3;
            this.uiLabBarcode.Text = "电阻值";
            this.uiLabBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 960);
            this.ControlBox = false;
            this.Controls.Add(this.uiPanelBottom);
            this.Controls.Add(this.uiPanelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.uiPanelTop.ResumeLayout(false);
            this.uiPanelLanSet.ResumeLayout(false);
            this.uiPanelCtrlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxClose)).EndInit();
            this.uiPanelBottom.ResumeLayout(false);
            this.uiTabCtrlContent.ResumeLayout(false);
            this.tabPageProdInfo.ResumeLayout(false);
            this.uiPanelQualCheck.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanelTop;
        private Sunny.UI.UIPanel uiPanelBottom;
        private Sunny.UI.UITabControl uiTabCtrlContent;
        private System.Windows.Forms.TabPage tabPageProdInfo;
        private System.Windows.Forms.TabPage tabPageInfoQuery;
        private Sunny.UI.UIPanel uiPanelCtrlBox;
        private Sunny.UI.UIPanel uiPanelLanSet;
        private Sunny.UI.UILabel uiLabLanSet;
        private Sunny.UI.UIComboBox uiCBoxLanSetting;
        private System.Windows.Forms.PictureBox picBoxClose;
        private Sunny.UI.UIPanel uiPanelQualCheck;
        private System.Windows.Forms.PictureBox picBoxMinus;
        private Sunny.UI.UISwitch uiSwitchSetLineState;
        private Sunny.UI.UILabel uiLabResistance;
        private Sunny.UI.UITextBox uiTxtBoxResistance;
        private Sunny.UI.UITextBox uiTxtBarcode;
        private Sunny.UI.UILabel uiLabBarcode;
    }
}

