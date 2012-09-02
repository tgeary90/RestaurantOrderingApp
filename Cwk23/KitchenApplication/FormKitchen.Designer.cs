namespace KitchenApplication
{
    partial class FormKitchen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewOrdersPending = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrdersSent = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.groupBoxPending = new System.Windows.Forms.GroupBox();
            this.groupBoxSent = new System.Windows.Forms.GroupBox();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.timerGetPendingOrders = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersPending)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersSent)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxPending.SuspendLayout();
            this.groupBoxSent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrdersPending
            // 
            this.dataGridViewOrdersPending.AllowUserToAddRows = false;
            this.dataGridViewOrdersPending.AllowUserToDeleteRows = false;
            this.dataGridViewOrdersPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrdersPending.Location = new System.Drawing.Point(12, 18);
            this.dataGridViewOrdersPending.Name = "dataGridViewOrdersPending";
            this.dataGridViewOrdersPending.ReadOnly = true;
            this.dataGridViewOrdersPending.Size = new System.Drawing.Size(454, 312);
            this.dataGridViewOrdersPending.TabIndex = 0;
            // 
            // dataGridViewOrdersSent
            // 
            this.dataGridViewOrdersSent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrdersSent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrdersSent.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewOrdersSent.Name = "dataGridViewOrdersSent";
            this.dataGridViewOrdersSent.Size = new System.Drawing.Size(454, 171);
            this.dataGridViewOrdersSent.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(615, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.Location = new System.Drawing.Point(491, 19);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(82, 108);
            this.listBoxOrders.TabIndex = 3;
            this.listBoxOrders.SelectedIndexChanged += new System.EventHandler(this.listBoxOrders_SelectedIndexChanged);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Enabled = false;
            this.buttonOrderReady.Location = new System.Drawing.Point(491, 138);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(82, 36);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Order Ready";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // groupBoxPending
            // 
            this.groupBoxPending.Controls.Add(this.buttonOrderReady);
            this.groupBoxPending.Controls.Add(this.listBoxOrders);
            this.groupBoxPending.Controls.Add(this.dataGridViewOrdersPending);
            this.groupBoxPending.Location = new System.Drawing.Point(15, 36);
            this.groupBoxPending.Name = "groupBoxPending";
            this.groupBoxPending.Size = new System.Drawing.Size(588, 349);
            this.groupBoxPending.TabIndex = 5;
            this.groupBoxPending.TabStop = false;
            this.groupBoxPending.Text = "Pending Orders";
            // 
            // groupBoxSent
            // 
            this.groupBoxSent.Controls.Add(this.buttonStatistics);
            this.groupBoxSent.Controls.Add(this.dataGridViewOrdersSent);
            this.groupBoxSent.Location = new System.Drawing.Point(21, 391);
            this.groupBoxSent.Name = "groupBoxSent";
            this.groupBoxSent.Size = new System.Drawing.Size(582, 204);
            this.groupBoxSent.TabIndex = 6;
            this.groupBoxSent.TabStop = false;
            this.groupBoxSent.Text = "Sent Orders";
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.Location = new System.Drawing.Point(485, 154);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(82, 36);
            this.buttonStatistics.TabIndex = 0;
            this.buttonStatistics.Text = "Statistics";
            this.buttonStatistics.UseVisualStyleBackColor = true;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // timerGetPendingOrders
            // 
            this.timerGetPendingOrders.Enabled = true;
            this.timerGetPendingOrders.Interval = 10000;
            this.timerGetPendingOrders.Tick += new System.EventHandler(this.timerGetPendingOrders_Tick);
            // 
            // FormKitchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 607);
            this.Controls.Add(this.groupBoxPending);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxSent);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormKitchen";
            this.Text = "Kitchen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersPending)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrdersSent)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxPending.ResumeLayout(false);
            this.groupBoxSent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrdersPending;
        private System.Windows.Forms.DataGridView dataGridViewOrdersSent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.GroupBox groupBoxPending;
        private System.Windows.Forms.GroupBox groupBoxSent;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Timer timerGetPendingOrders;
    }
}

