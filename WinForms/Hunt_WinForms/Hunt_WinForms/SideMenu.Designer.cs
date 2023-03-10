namespace Hunt_WinForms
{
    partial class SideMenu
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
            this.lbl_gameInfo = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_saveGame = new System.Windows.Forms.Button();
            this.btn_backToMain = new System.Windows.Forms.Button();
            this.pnl_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_menu
            // 
            this.pnl_menu.AutoSize = true;
            this.pnl_menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_menu.ColumnCount = 1;
            this.pnl_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_menu.Controls.Add(this.lbl_gameInfo, 0, 0);
            this.pnl_menu.Controls.Add(this.btn_exit, 0, 3);
            this.pnl_menu.Controls.Add(this.btn_saveGame, 0, 2);
            this.pnl_menu.Controls.Add(this.btn_backToMain, 0, 1);
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_menu.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.RowCount = 4;
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.14286F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.pnl_menu.Size = new System.Drawing.Size(399, 952);
            this.pnl_menu.TabIndex = 0;
            // 
            // lbl_gameInfo
            // 
            this.lbl_gameInfo.AutoSize = true;
            this.lbl_gameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_gameInfo.ForeColor = System.Drawing.Color.White;
            this.lbl_gameInfo.Location = new System.Drawing.Point(3, 0);
            this.lbl_gameInfo.Name = "lbl_gameInfo";
            this.lbl_gameInfo.Size = new System.Drawing.Size(393, 544);
            this.lbl_gameInfo.TabIndex = 1;
            this.lbl_gameInfo.Text = "GameInfo PlaceHolder";
            this.lbl_gameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_exit
            // 
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_exit.Location = new System.Drawing.Point(3, 817);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(393, 132);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_saveGame
            // 
            this.btn_saveGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_saveGame.Location = new System.Drawing.Point(3, 682);
            this.btn_saveGame.Name = "btn_saveGame";
            this.btn_saveGame.Size = new System.Drawing.Size(393, 129);
            this.btn_saveGame.TabIndex = 2;
            this.btn_saveGame.Text = "Save Game";
            this.btn_saveGame.UseVisualStyleBackColor = true;
            this.btn_saveGame.Click += new System.EventHandler(this.btn_saveGame_Click);
            // 
            // btn_backToMain
            // 
            this.btn_backToMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_backToMain.Location = new System.Drawing.Point(3, 547);
            this.btn_backToMain.Name = "btn_backToMain";
            this.btn_backToMain.Size = new System.Drawing.Size(393, 129);
            this.btn_backToMain.TabIndex = 1;
            this.btn_backToMain.Text = "Exit to main menu";
            this.btn_backToMain.UseVisualStyleBackColor = true;
            this.btn_backToMain.Click += new System.EventHandler(this.btn_backToMain_Click);
            // 
            // SideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.pnl_menu);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "SideMenu";
            this.Size = new System.Drawing.Size(399, 952);
            this.pnl_menu.ResumeLayout(false);
            this.pnl_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel pnl_menu;
        private Button btn_saveGame;
        private Button btn_backToMain;
        private Button btn_exit;
        private Label lbl_gameInfo;
    }


}

