namespace Hunt_WinForms
{
    partial class GameOver
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
            this.pnl_gameOver = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_result = new System.Windows.Forms.Label();
            this.btn_newGame = new System.Windows.Forms.Button();
            this.pnl_gameOver.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_gameOver
            // 
            this.pnl_gameOver.ColumnCount = 1;
            this.pnl_gameOver.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_gameOver.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_gameOver.Controls.Add(this.lbl_result, 0, 0);
            this.pnl_gameOver.Controls.Add(this.btn_newGame, 0, 1);
            this.pnl_gameOver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_gameOver.Location = new System.Drawing.Point(0, 0);
            this.pnl_gameOver.Name = "pnl_gameOver";
            this.pnl_gameOver.RowCount = 2;
            this.pnl_gameOver.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_gameOver.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_gameOver.Size = new System.Drawing.Size(800, 450);
            this.pnl_gameOver.TabIndex = 0;
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_result.ForeColor = System.Drawing.Color.White;
            this.lbl_result.Location = new System.Drawing.Point(3, 0);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(794, 225);
            this.lbl_result.TabIndex = 0;
            this.lbl_result.Text = "placeholder";
            this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_newGame
            // 
            this.btn_newGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_newGame.Location = new System.Drawing.Point(100, 275);
            this.btn_newGame.Margin = new System.Windows.Forms.Padding(100, 50, 100, 50);
            this.btn_newGame.Name = "btn_newGame";
            this.btn_newGame.Size = new System.Drawing.Size(600, 125);
            this.btn_newGame.TabIndex = 1;
            this.btn_newGame.Text = "New Game";
            this.btn_newGame.UseVisualStyleBackColor = true;
            this.btn_newGame.Click += new System.EventHandler(this.btn_newGame_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_gameOver);
            this.Name = "GameOver";
            this.Text = "GameOver";
            this.pnl_gameOver.ResumeLayout(false);
            this.pnl_gameOver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel pnl_gameOver;
        private Label lbl_result;
        private Button btn_newGame;
    }
}