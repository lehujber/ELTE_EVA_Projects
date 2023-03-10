namespace Hunt_WinForms
{
    partial class GameField
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
            this.pnl_gameField = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_board = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_gameField.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_gameField
            // 
            this.pnl_gameField.ColumnCount = 2;
            this.pnl_gameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.pnl_gameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnl_gameField.Controls.Add(this.pnl_board, 0, 0);
            this.pnl_gameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_gameField.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnl_gameField.Location = new System.Drawing.Point(0, 0);
            this.pnl_gameField.Name = "pnl_gameField";
            this.pnl_gameField.RowCount = 1;
            this.pnl_gameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_gameField.Size = new System.Drawing.Size(503, 258);
            this.pnl_gameField.TabIndex = 0;
            // 
            // pnl_board
            // 
            this.pnl_board.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_board.BackColor = System.Drawing.Color.Black;
            this.pnl_board.ColumnCount = 1;
            this.pnl_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_board.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnl_board.Location = new System.Drawing.Point(3, 3);
            this.pnl_board.Name = "pnl_board";
            this.pnl_board.RowCount = 1;
            this.pnl_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnl_board.Size = new System.Drawing.Size(371, 252);
            this.pnl_board.TabIndex = 2;
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.pnl_gameField);
            this.Name = "GameField";
            this.Size = new System.Drawing.Size(503, 258);
            this.pnl_gameField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel pnl_gameField;
        private TableLayoutPanel pnl_board;
    }
}
