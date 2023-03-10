using System.Windows.Forms;

namespace Hunt_WinForms
{
    public partial class Hunt : Form
    {


        static public int selectedGameMode = 3;
        public Hunt()
        {
            InitializeComponent();
        }
        

        private void Hunt_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            MainMenu menu = new MainMenu();
            this.Controls.Add(menu);
        }


    }
}