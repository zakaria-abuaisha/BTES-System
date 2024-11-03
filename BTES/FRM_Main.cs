using BTES.Business_layer;
using BTES.Forms;
using System;
using System.Windows.Forms;

namespace BTES
{
    public partial class FRM_Main : Form
    {
        private Form currentFrm;
        private ClsAdmin admin = null;

        
        public FRM_Main()
        {
            InitializeComponent();

        }

        private void ChangeForm(Form frm)
        {

            if (currentFrm != null)
                currentFrm.Close();

            currentFrm = frm;
            currentFrm.TopLevel = false;
            currentFrm.FormBorderStyle = FormBorderStyle.None;
            this.PNL_Form.Controls.Add(currentFrm);
            currentFrm.Dock = DockStyle.Fill;
            currentFrm.BringToFront();

            currentFrm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Events(admin));
        }

        private void BTN_Event_Click(object sender, EventArgs e)
        {

            ChangeForm(new FRM_Events(admin));

        }

        private void BTN_Tickets_Click(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Tickets());
 
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            FRM_Login FRM_Login = new FRM_Login(BTN_Tickets);
            FRM_Login.ShowForm += FRM_Login_ShowEvent;
            ChangeForm(FRM_Login);
        }

        private void FRM_Login_ShowEvent(object sender, ClsAdmin Admin)
        {
            admin = Admin;
            ChangeForm(new FRM_Events(Admin));
            BTN_Login.Visible = false;
            BTN_Logout.Visible = true;

        }

        private void BTN_Logout_Click(object sender, EventArgs e)
        {
            BTN_Tickets.Visible = true;
            BTN_Login.Visible = true;
            BTN_Logout.Visible = false;

            admin = null;
            ChangeForm(new FRM_Events(admin));
        }
    }
}
