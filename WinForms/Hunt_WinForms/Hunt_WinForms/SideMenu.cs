using Hunt_basic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunt_WinForms
{
    public partial class SideMenu : UserControl
    {
        private readonly Game g;
        public SideMenu(Game g)
        {
            InitializeComponent();
            this.g = g;
        }

        public void updateGameData(int remRounds,string nextStep)
        {
            string data = $"Remaining rounds: {remRounds}\n" +
                          $"Next step: {nextStep}";
            this.lbl_gameInfo.Text = data;
        }

        private void btn_backToMain_Click(object sender, EventArgs e)
        {
            Control gf = this.Parent.Parent;
            Control main = gf.Parent;

            gf.Hide();
            main.Controls.Add(new MainMenu());
            gf.Dispose();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_saveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    g.save(sfd.FileName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
