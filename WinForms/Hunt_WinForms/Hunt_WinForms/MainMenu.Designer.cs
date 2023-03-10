namespace Hunt_WinForms
{
    partial class MainMenu
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_loadGame = new System.Windows.Forms.Button();
            this.btn_startGame = new System.Windows.Forms.Button();
            this.pnl_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_menu
            // 
            this.pnl_menu.AutoSize = true;
            this.pnl_menu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_menu.ColumnCount = 1;
            this.pnl_menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_menu.Controls.Add(this.btn_exit, 0, 3);
            this.pnl_menu.Controls.Add(this.btn_settings, 0, 2);
            this.pnl_menu.Controls.Add(this.btn_loadGame, 0, 1);
            this.pnl_menu.Controls.Add(this.btn_startGame, 0, 0);
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_menu.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Padding = new System.Windows.Forms.Padding(40);
            this.pnl_menu.RowCount = 4;
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_menu.Size = new System.Drawing.Size(399, 228);
            this.pnl_menu.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_exit.Location = new System.Drawing.Point(43, 154);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(313, 31);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_settings.Location = new System.Drawing.Point(43, 117);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(313, 31);
            this.btn_settings.TabIndex = 3;
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_loadGame
            // 
            this.btn_loadGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_loadGame.Location = new System.Drawing.Point(43, 80);
            this.btn_loadGame.Name = "btn_loadGame";
            this.btn_loadGame.Size = new System.Drawing.Size(313, 31);
            this.btn_loadGame.TabIndex = 2;
            this.btn_loadGame.Text = "Load Game";
            this.btn_loadGame.UseVisualStyleBackColor = true;
            this.btn_loadGame.Click += new System.EventHandler(this.btn_loadGame_Click);
            // 
            // btn_startGame
            // 
            this.btn_startGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_startGame.Location = new System.Drawing.Point(43, 43);
            this.btn_startGame.Name = "btn_startGame";
            this.btn_startGame.Size = new System.Drawing.Size(313, 31);
            this.btn_startGame.TabIndex = 1;
            this.btn_startGame.Text = "Start Game";
            this.btn_startGame.UseVisualStyleBackColor = true;
            this.btn_startGame.Click += new System.EventHandler(this.btn_startGame_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.pnl_menu);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(399, 228);
            this.pnl_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel pnl_menu;
        private Button btn_loadGame;
        private Button btn_startGame;
        private Button btn_exit;
        private Button btn_settings;
    }
}
