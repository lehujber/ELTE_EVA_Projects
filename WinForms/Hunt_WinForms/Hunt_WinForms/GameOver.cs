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
    public partial class GameOver : Form
    {
        public GameOver(string winner)
        {
            InitializeComponent();
            this.lbl_result.Text=$"The winner is: {winner}";
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
