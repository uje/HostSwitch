namespace HostSwitch
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.gvList = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labStatus = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exchargeList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmtShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tbeName = new HostSwitch.Controls.TextBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvList
            // 
            this.gvList.AllowUserToAddRows = false;
            this.gvList.AllowUserToDeleteRows = false;
            this.gvList.AllowUserToResizeColumns = false;
            this.gvList.AllowUserToResizeRows = false;
            this.gvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileContent,
            this.FilePath,
            this.USE,
            this.EDIT,
            this.DELETE});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvList.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvList.Location = new System.Drawing.Point(0, 84);
            this.gvList.MultiSelect = false;
            this.gvList.Name = "gvList";
            this.gvList.ReadOnly = true;
            this.gvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvList.RowHeadersVisible = false;
            this.gvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.gvList.RowTemplate.Height = 23;
            this.gvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvList.ShowEditingIcon = false;
            this.gvList.Size = new System.Drawing.Size(411, 639);
            this.gvList.TabIndex = 6;
            this.gvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvList_CellContentClick);
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "名称 ";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.Width = 230;
            // 
            // FileContent
            // 
            this.FileContent.DataPropertyName = "FileContent";
            this.FileContent.HeaderText = "FileContent";
            this.FileContent.Name = "FileContent";
            this.FileContent.ReadOnly = true;
            this.FileContent.Visible = false;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // USE
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "使用";
            this.USE.DefaultCellStyle = dataGridViewCellStyle1;
            this.USE.HeaderText = "";
            this.USE.Name = "USE";
            this.USE.ReadOnly = true;
            this.USE.Text = "使用";
            this.USE.Width = 60;
            // 
            // EDIT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "编辑";
            this.EDIT.DefaultCellStyle = dataGridViewCellStyle2;
            this.EDIT.HeaderText = "操作";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "编辑";
            this.EDIT.Width = 60;
            // 
            // DELETE
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "删除";
            this.DELETE.DefaultCellStyle = dataGridViewCellStyle3;
            this.DELETE.HeaderText = "";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELETE.Text = "删除";
            this.DELETE.Width = 60;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreate.Location = new System.Drawing.Point(12, 21);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(104, 44);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "新增";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbContent
            // 
            this.tbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContent.Location = new System.Drawing.Point(427, 134);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(787, 579);
            this.tbContent.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1063, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStatus.Location = new System.Drawing.Point(425, 36);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(96, 16);
            this.labStatus.TabIndex = 11;
            this.labStatus.Text = "操作 > 新增";
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipTitle = "、";
            this.trayIcon.ContextMenuStrip = this.cmsTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Host管理器";
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmtShow,
            this.exchargeList});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(149, 48);
            // 
            // exchargeList
            // 
            this.exchargeList.Name = "exchargeList";
            this.exchargeList.Size = new System.Drawing.Size(148, 22);
            this.exchargeList.Text = "HOST切换(&E)";
            // 
            // tsmtShow
            // 
            this.tsmtShow.Name = "tsmtShow";
            this.tsmtShow.Size = new System.Drawing.Size(148, 22);
            this.tsmtShow.Text = "显示(&S)";
            this.tsmtShow.Click += new System.EventHandler(this.tsmtShow_Click);
            // 
            // tbeName
            // 
            this.tbeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbeName.BackColor = System.Drawing.Color.White;
            this.tbeName.Location = new System.Drawing.Point(427, 84);
            this.tbeName.Margin = new System.Windows.Forms.Padding(2);
            this.tbeName.Name = "tbeName";
            this.tbeName.PasswordMode = false;
            this.tbeName.Placeholder = "这里输入host名称 ";
            this.tbeName.PlaceHolderMargin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tbeName.Size = new System.Drawing.Size(623, 34);
            this.tbeName.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 723);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbeName);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.gvList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host管理器";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gvList;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Button button1;
        private Controls.TextBoxEdit tbeName;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewButtonColumn USE;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem exchargeList;
        private System.Windows.Forms.ToolStripMenuItem tsmtShow;
    }
}

