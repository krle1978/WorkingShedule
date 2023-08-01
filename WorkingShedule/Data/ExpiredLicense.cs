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
    public partial class ExpiredLicense : Form
    {
        public ExpiredLicense()
        {
            InitializeComponent();
        }

        private void ExpiredLicense_Load(object sender, EventArgs e)
        {
            string textForTexting = "Your free version of the program has expired.\r\n" +
                "\r\nWe are glad that you enjoyed this application and that it helped you organize your activities more easily.\r\n" +
                "\r\nYou will need a license for further use. You can contact us at the contacts listed below.",
                textContactForContactBox = "E-mail: \nkrstic.rade@gmail.com\r\n" +
                "WhatsApp, Viber: \r\n+43 681 811 808 51";
            tbTexting.Text=textForTexting;
            tbContact.Text=textContactForContactBox;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
