using BTES.Business_layer;
using BTES.Forms.Discount;
using BTES.Forms.Events;
using BTES.Forms.Ticket;
using BTES.Forms.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void BTN_Event_Click(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Events(admin));
        }

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Events(admin));
        }

        private void BTN_Tickets_Click(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Tickets());
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            FRM_Login FRM_login = new FRM_Login();
            FRM_login.ShowForm += FRM_Login_ShowEvent;
            ChangeForm(FRM_login);
        }

        private void FRM_Login_ShowEvent(object sender, ClsAdmin Admin)
        {
            admin = Admin;
            ChangeForm(new FRM_Events(Admin));
            BTN_Login.Visible = false;
            BTN_Logout.Visible = true;
            BTN_Tickets.Visible = false;
            BTN_ReqDiscount.Visible = false;


        }

        private void BTN_Logout_Click(object sender, EventArgs e)
        {
            BTN_Tickets.Visible = true;
            BTN_Login.Visible = true;
            BTN_Logout.Visible = false;
            BTN_Tickets.Visible = true;
            admin = null;
            BTN_ReqDiscount.Visible = true;
            ChangeForm(new FRM_Events(admin));
        }

        private void BTN_ReqDiscount_Click(object sender, EventArgs e)
        {
            FRM_OrderDiscount frm = new FRM_OrderDiscount();
            frm.ShowDialog();

        }
    }
}
