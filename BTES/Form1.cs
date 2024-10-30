using BTES.Business_layer;
using BTES.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES
{
    public partial class frmMain : Form
    {
        private Form currentFrm;
        public frmMain()
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
            ChangeForm(new FRM_Events());
        }

        private void BTN_Event_Click(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Events());

        }

        private void BTN_Tickets_Click(object sender, EventArgs e)
        {
            ChangeForm(new FRM_Tickets());
 
        }
    }
}
