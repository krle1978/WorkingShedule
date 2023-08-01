using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkingShedule.Data
{
    public partial class DialogWindow : Form
    {
        string lblText = "FilePath:", path = "(path!)";
        public DialogWindow(string lblText, string path)
        {
            this.lblText = lblText;
            this.path = path;
            InitializeComponent();

        }
        
        private void DialogWindow_Load(object sender, EventArgs e)
        {
            lblInfo.Text = lblText;
            tbPathView.Text = path;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbPathView.Text);
            this.Close();
        }
    }
}
