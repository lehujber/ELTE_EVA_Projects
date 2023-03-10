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
    public partial class SizeSelector : UserControl
    {
        public SizeSelector()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.AutoSize = false;
        }

        private void btn_3x3_Click(object sender, EventArgs e) { setGameMode(3); }
        private void btn_5x5_Click(object sender, EventArgs e) { setGameMode(5); }
        private void btn_7x7_Click(object sender, EventArgs e) { setGameMode(7); }

        private void setGameMode(int size)
        {
            Hunt.selectedGameMode = size;

            this.Hide();
            Control parent = this.Parent;

            MainMenu mn = new MainMenu();
            parent.Controls.Add(mn);
            this.Dispose();


        }
    }
}
