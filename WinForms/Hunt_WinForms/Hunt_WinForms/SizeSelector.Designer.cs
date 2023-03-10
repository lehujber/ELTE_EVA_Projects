namespace Hunt_WinForms
{
    partial class SizeSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_menu = new System.Windows.Forms.TableLayoutPanel();
            this.btn_7x7 = new System.Windows.Forms.Button();
            this.btn_5x5 = new System.Windows.Forms.Button();
            this.btn_3x3 = new System.Windows.Forms.Button();
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.pnl_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_menu
            // 
            this.pnl_menu.AutoSize = true;
            this.pnl_menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_menu.ColumnCount = 1;
            this.pnl_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_menu.Controls.Add(this.btn_7x7, 0, 3);
            this.pnl_menu.Controls.Add(this.btn_5x5, 0, 2);
            this.pnl_menu.Controls.Add(this.btn_3x3, 0, 1);
            this.pnl_menu.Controls.Add(this.lbl_instruction, 0, 0);
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_menu.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.RowCount = 4;
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.Size = new System.Drawing.Size(399, 228);
            this.pnl_menu.TabIndex = 0;
            // 
            // btn_7x7
            // 
            this.btn_7x7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_7x7.Location = new System.Drawing.Point(3, 174);
            this.btn_7x7.Name = "btn_7x7";
            this.btn_7x7.Size = new System.Drawing.Size(393, 51);
            this.btn_7x7.TabIndex = 4;
            this.btn_7x7.Text = "7x7";
            this.btn_7x7.UseVisualStyleBackColor = true;
            this.btn_7x7.Click += new System.EventHandler(this.btn_7x7_Click);
            // 
            // btn_5x5
            // 
            this.btn_5x5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_5x5.Location = new System.Drawing.Point(3, 117);
            this.btn_5x5.Name = "btn_5x5";
            this.btn_5x5.Size = new System.Drawing.Size(393, 51);
            this.btn_5x5.TabIndex = 3;
            this.btn_5x5.Text = "5x5";
            this.btn_5x5.UseVisualStyleBackColor = true;
            this.btn_5x5.Click += new System.EventHandler(this.btn_5x5_Click);
            // 
            // btn_3x3
            // 
            this.btn_3x3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_3x3.Location = new System.Drawing.Point(3, 60);
            this.btn_3x3.Name = "btn_3x3";
            this.btn_3x3.Size = new System.Drawing.Size(393, 51);
            this.btn_3x3.TabIndex = 2;
            this.btn_3x3.Text = "3x3";
            this.btn_3x3.UseVisualStyleBackColor = true;
            this.btn_3x3.Click += new System.EventHandler(this.btn_3x3_Click);
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.AutoSize = true;
            this.lbl_instruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_instruction.ForeColor = System.Drawing.Color.White;
            this.lbl_instruction.Location = new System.Drawing.Point(3, 0);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(393, 57);
            this.lbl_instruction.TabIndex = 5;
            this.lbl_instruction.Text = "Please select the size of the map";
            this.lbl_instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SizeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.pnl_menu);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "SizeSelector";
            this.Size = new System.Drawing.Size(399, 228);
            this.pnl_menu.ResumeLayout(false);
            this.pnl_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel pnl_menu;
        private Button btn_3x3;
        private Button btn_7x7;
        private Button btn_5x5;
        private Label lbl_instruction;
    }
}
