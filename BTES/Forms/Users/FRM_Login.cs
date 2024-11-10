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

namespace BTES.Forms.Users
{
    public partial class FRM_Login : Form
    {
        //this a void delegate, and we will use it here if the username, and password added correctly then we will invoke a method in the caller method,
        public event Action<object, ClsAdmin> ShowForm;

        public FRM_Login()
        {
            InitializeComponent();
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_Username.Text.Trim()) || string.IsNullOrEmpty(TXT_Password.Text.Trim()))
            {
                MessageBox.Show("Please Fill up All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClsAdmin Admin = ClsAdmin.Login(TXT_Username.Text.Trim(), TXT_Password.Text.Trim());

            if (Admin != null)
            {
                ShowForm.Invoke(null, Admin);
            }
            else
            {
                MessageBox.Show("Wrong Username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
