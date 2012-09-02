namespace KitchenApplication
{
    partial class FormStatistics
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
            this.groupBoxMealStatistics = new System.Windows.Forms.GroupBox();
            this.listBoxKey = new System.Windows.Forms.ListBox();
            this.dataGridViewPopTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewPopMeal = new System.Windows.Forms.DataGridView();
            this.groupBoxOrderStatistics = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrderTimes = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReturnToKitchen = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxMealStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopMeal)).BeginInit();
            this.groupBoxOrderStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderTimes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMealStatistics
            // 
            this.groupBoxMealStatistics.Controls.Add(this.listBoxKey);
            this.groupBoxMealStatistics.Controls.Add(this.dataGridViewPopTable);
            this.groupBoxMealStatistics.Controls.Add(this.dataGridViewPopMeal);
            this.groupBoxMealStatistics.Location = new System.Drawing.Point(12, 48);
            this.groupBoxMealStatistics.Name = "groupBoxMealStatistics";
            this.groupBoxMealStatistics.Size = new System.Drawing.Size(535, 375);
            this.groupBoxMealStatistics.TabIndex = 0;
            this.groupBoxMealStatistics.TabStop = false;
            this.groupBoxMealStatistics.Text = "Most Popular Meal and Table";
            // 
            // listBoxKey
            // 
            this.listBoxKey.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxKey.FormattingEnabled = true;
            this.listBoxKey.Items.AddRange(new object[] {
            "0 - Eggs on Toast",
            "1 - All Day Breakfast",
            "2 - Marmalade On Toast",
            "3 - Boiled Egg",
            "4 - Eggs Benedict",
            "5 - Salmon on Croissant",
            "6 - Cheese Omelette"});
            this.listBoxKey.Location = new System.Drawing.Point(392, 20);
            this.listBoxKey.Name = "listBoxKey";
            this.listBoxKey.Size = new System.Drawing.Size(126, 95);
            this.listBoxKey.TabIndex = 2;
            // 
            // dataGridViewPopTable
            // 
            this.dataGridViewPopTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopTable.Location = new System.Drawing.Point(6, 197);
            this.dataGridViewPopTable.Name = "dataGridViewPopTable";
            this.dataGridViewPopTable.Size = new System.Drawing.Size(365, 153);
            this.dataGridViewPopTable.TabIndex = 1;
            // 
            // dataGridViewPopMeal
            // 
            this.dataGridViewPopMeal.AllowUserToAddRows = false;
            this.dataGridViewPopMeal.AllowUserToDeleteRows = false;
            this.dataGridViewPopMeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopMeal.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewPopMeal.Name = "dataGridViewPopMeal";
            this.dataGridViewPopMeal.ReadOnly = true;
            this.dataGridViewPopMeal.Size = new System.Drawing.Size(364, 161);
            this.dataGridViewPopMeal.TabIndex = 0;
            // 
            // groupBoxOrderStatistics
            // 
            this.groupBoxOrderStatistics.Controls.Add(this.dataGridViewOrderTimes);
            this.groupBoxOrderStatistics.Location = new System.Drawing.Point(12, 439);
            this.groupBoxOrderStatistics.Name = "groupBoxOrderStatistics";
            this.groupBoxOrderStatistics.Size = new System.Drawing.Size(535, 324);
            this.groupBoxOrderStatistics.TabIndex = 1;
            this.groupBoxOrderStatistics.TabStop = false;
            this.groupBoxOrderStatistics.Text = "Order Statistics";
            // 
            // dataGridViewOrderTimes
            // 
            this.dataGridViewOrderTimes.AllowUserToAddRows = false;
            this.dataGridViewOrderTimes.AllowUserToDeleteRows = false;
            this.dataGridViewOrderTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderTimes.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewOrderTimes.Name = "dataGridViewOrderTimes";
            this.dataGridViewOrderTimes.ReadOnly = true;
            this.dataGridViewOrderTimes.Size = new System.Drawing.Size(522, 298);
            this.dataGridViewOrderTimes.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonReturnToKitchen
            // 
            this.buttonReturnToKitchen.Location = new System.Drawing.Point(437, 778);
            this.buttonReturnToKitchen.Name = "buttonReturnToKitchen";
            this.buttonReturnToKitchen.Size = new System.Drawing.Size(104, 32);
            this.buttonReturnToKitchen.TabIndex = 3;
            this.buttonReturnToKitchen.Text = "Back To Kitchen";
            this.buttonReturnToKitchen.UseVisualStyleBackColor = true;
            this.buttonReturnToKitchen.Click += new System.EventHandler(this.buttonReturnToKitchen_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(327, 778);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(91, 32);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 822);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonReturnToKitchen);
            this.Controls.Add(this.groupBoxOrderStatistics);
            this.Controls.Add(this.groupBoxMealStatistics);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormStatistics";
            this.Text = "Statistics";
            this.groupBoxMealStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopMeal)).EndInit();
            this.groupBoxOrderStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderTimes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMealStatistics;
        private System.Windows.Forms.DataGridView dataGridViewPopMeal;
        private System.Windows.Forms.DataGridView dataGridViewPopTable;
        private System.Windows.Forms.GroupBox groupBoxOrderStatistics;
        private System.Windows.Forms.DataGridView dataGridViewOrderTimes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonReturnToKitchen;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ListBox listBoxKey;
    }
}