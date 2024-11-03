using BTES.Business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Forms
{
    public partial class FRM_Login : Form
    {
        private Button _BTN_Ticket;
        public event Action<object, ClsAdmin> ShowForm;
        


        public FRM_Login(Button BTN_Ticket)
        {
            InitializeComponent();
            _BTN_Ticket = BTN_Ticket;
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            ClsAdmin Admin = ClsAdmin.Login(TXT_Username.Text.Trim(), TXT_Password.Text.Trim());

            if (Admin != null)
            {
                _BTN_Ticket.Visible = false;
                ShowForm.Invoke(null, Admin);
            }
            else
            {
                MessageBox.Show("Wrong Username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
