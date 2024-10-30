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
    public partial class FRM_Tickets : Form
    {
        public FRM_Tickets()
        {
            InitializeComponent();
        }

        private DataTable Dt_PT = new DataTable();

        private void Referesh()
        {
            if (Dt_PT.Rows.Count > 0)
            {
                LBL_NoRecords.Visible = false;
                CMS_Options.Visible = true;

                // .....
            }
            else
            {
                LBL_NoRecords.Visible = true;
                LBL_NoRecords.Top = 350;
                CMS_Options.Visible = false;
            }
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            clsCustomer customer = clsCustomer.Find(TXT_Username.Text.Trim(), TXT_Password.Text.Trim());
            if(customer != null )
            {

                dgvEvent.Visible = true;
                PNL_Login.Visible = false;
                Referesh();
            }
            else
                MessageBox.Show("Wrong UserName Or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
