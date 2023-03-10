using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hunt_WinForms
{
    public partial class MainMenu : UserControl
    {

        public MainMenu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.AutoSize = false;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_startGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameField gf = new GameField(Hunt.selectedGameMode);

            this.Parent.Controls.Add(gf);
            this.Dispose();

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            SizeSelector ss = new SizeSelector();
            this.Parent.Controls.Add(ss);
            this.Dispose();
        }

        private void btn_loadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GameField gf = new GameField(ofd.FileName);
                    this.Hide();

                    Parent.Controls.Add(gf);
                    this.Dispose();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //GameField gf = new GameField();
        }
    }
}
