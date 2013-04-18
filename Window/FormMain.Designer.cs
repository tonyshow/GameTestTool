namespace GameTestTool
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnScriptStart = new System.Windows.Forms.Button();
            this.btnScriptStop = new System.Windows.Forms.Button();
            this.cboScript = new System.Windows.Forms.ComboBox();
            this.lstScriptInfo = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnScriptRefresh = new System.Windows.Forms.Button();
            this.txtWinName = new System.Windows.Forms.TextBox();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.txtCursorPos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.closeUACChe = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindTypeCbo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "窗口句柄:";
            // 
            // btnScriptStart
            // 
            this.btnScriptStart.Location = new System.Drawing.Point(420, 634);
            this.btnScriptStart.Name = "btnScriptStart";
            this.btnScriptStart.Size = new System.Drawing.Size(101, 30);
            this.btnScriptStart.TabIndex = 1;
            this.btnScriptStart.Text = "执行脚本(Home)";
            this.btnScriptStart.UseVisualStyleBackColor = true;
            this.btnScriptStart.Click += new System.EventHandler(this.BtnScriptStartClick);
            // 
            // btnScriptStop
            // 
            this.btnScriptStop.Location = new System.Drawing.Point(774, 634);
            this.btnScriptStop.Name = "btnScriptStop";
            this.btnScriptStop.Size = new System.Drawing.Size(92, 30);
            this.btnScriptStop.TabIndex = 2;
            this.btnScriptStop.Text = "停止脚本(End)";
            this.btnScriptStop.UseVisualStyleBackColor = true;
            this.btnScriptStop.Click += new System.EventHandler(this.BtnScriptStopClick);
            // 
            // cboScript
            // 
            this.cboScript.FormattingEnabled = true;
            this.cboScript.Location = new System.Drawing.Point(266, 7);
            this.cboScript.Name = "cboScript";
            this.cboScript.Size = new System.Drawing.Size(623, 20);
            this.cboScript.TabIndex = 3;
            this.cboScript.SelectedIndexChanged += new System.EventHandler(this.CobScriptSelectedIndexChanged);
            this.cboScript.Click += new System.EventHandler(this.CobScriptLoadClick);
            // 
            // lstScriptInfo
            // 
            this.lstScriptInfo.FormattingEnabled = true;
            this.lstScriptInfo.ItemHeight = 12;
            this.lstScriptInfo.Location = new System.Drawing.Point(225, 34);
            this.lstScriptInfo.Name = "lstScriptInfo";
            this.lstScriptInfo.Size = new System.Drawing.Size(814, 568);
            this.lstScriptInfo.TabIndex = 4;
            this.lstScriptInfo.UseTabStops = false;
            this.lstScriptInfo.DoubleClick += new System.EventHandler(this.LstScriptInfoClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "窗口标题：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "脚本:";
            // 
            // btnScriptRefresh
            // 
            this.btnScriptRefresh.Location = new System.Drawing.Point(895, 4);
            this.btnScriptRefresh.Name = "btnScriptRefresh";
            this.btnScriptRefresh.Size = new System.Drawing.Size(63, 25);
            this.btnScriptRefresh.TabIndex = 8;
            this.btnScriptRefresh.Text = "脚本刷新";
            this.btnScriptRefresh.UseVisualStyleBackColor = true;
            this.btnScriptRefresh.Click += new System.EventHandler(this.BtnScriptRefreshClick);
            // 
            // txtWinName
            // 
            this.txtWinName.Location = new System.Drawing.Point(74, 18);
            this.txtWinName.Name = "txtWinName";
            this.txtWinName.Size = new System.Drawing.Size(85, 21);
            this.txtWinName.TabIndex = 10;
            // 
            // txtHandle
            // 
            this.txtHandle.Location = new System.Drawing.Point(74, 45);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(85, 21);
            this.txtHandle.TabIndex = 11;
            // 
            // txtCursorPos
            // 
            this.txtCursorPos.Location = new System.Drawing.Point(8, 46);
            this.txtCursorPos.Name = "txtCursorPos";
            this.txtCursorPos.ReadOnly = true;
            this.txtCursorPos.Size = new System.Drawing.Size(163, 21);
            this.txtCursorPos.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "获取鼠标坐标:(Alt+1)";
            // 
            // closeUACChe
            // 
            this.closeUACChe.AutoSize = true;
            this.closeUACChe.Location = new System.Drawing.Point(18, 20);
            this.closeUACChe.Name = "closeUACChe";
            this.closeUACChe.Size = new System.Drawing.Size(150, 16);
            this.closeUACChe.TabIndex = 14;
            this.closeUACChe.Text = "后台绑定时关闭系统UAC";
            this.closeUACChe.UseVisualStyleBackColor = true;
            this.closeUACChe.CheckedChanged += new System.EventHandler(this.CheCloseUACChangedClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHandle);
            this.groupBox1.Controls.Add(this.txtWinName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 127);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "后台绑定方式";
            // 
            // bindTypeCbo
            // 
            this.bindTypeCbo.FormattingEnabled = true;
            this.bindTypeCbo.Items.AddRange(new object[] {
            "gdi",
            "dx",
            "gdi2",
            "dx2",
            "dx3",
            "normal"});
            this.bindTypeCbo.Location = new System.Drawing.Point(11, 46);
            this.bindTypeCbo.Name = "bindTypeCbo";
            this.bindTypeCbo.Size = new System.Drawing.Size(77, 20);
            this.bindTypeCbo.TabIndex = 16;
            this.bindTypeCbo.Text = "gdi";
            this.bindTypeCbo.SelectedIndexChanged += new System.EventHandler(this.CobBindTypeChangedClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bindTypeCbo);
            this.groupBox2.Controls.Add(this.closeUACChe);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 139);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCursorPos);
            this.groupBox3.Location = new System.Drawing.Point(12, 373);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工具";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(964, 4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(75, 25);
            this.btnOpenFolder.TabIndex = 17;
            this.btnOpenFolder.Text = "浏览文件夹";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnOpenScriptFolder);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 676);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScriptRefresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstScriptInfo);
            this.Controls.Add(this.cboScript);
            this.Controls.Add(this.btnScriptStop);
            this.Controls.Add(this.btnScriptStart);
            this.Name = "FormMain";
            this.Text = "游戏测试工具(QQ:1036409576)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScriptStart;
        private System.Windows.Forms.Button btnScriptStop;
        private System.Windows.Forms.ComboBox cboScript;
        private System.Windows.Forms.ListBox lstScriptInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnScriptRefresh;
        private System.Windows.Forms.TextBox txtWinName;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.TextBox txtCursorPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox closeUACChe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox bindTypeCbo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}

