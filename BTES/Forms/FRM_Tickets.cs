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
        private clsCustomer _customer;
        public FRM_Tickets()
        {
            InitializeComponent();
        }

        private DataTable Dt_PT = new DataTable();

        private void Referesh()
        {
            dgvPurchased.DataSource = ClsPurchasedTicket.ViewPurchasedTicket(_customer.Customer_ID);

            dgvPurchased.Columns[0].HeaderText = "Purchased ID";
            dgvPurchased.Columns[0].Width = 100;

            dgvPurchased.Columns[1].HeaderText = "Event Title";
            dgvPurchased.Columns[1].Width = 100;

            dgvPurchased.Columns[2].HeaderText = "Costumer Name";
            dgvPurchased.Columns[2].Width = 140;

            dgvPurchased.Columns[3].HeaderText = "Purchased Date";
            dgvPurchased.Columns[3].Width = 110;

            dgvPurchased.Columns[4].HeaderText = "Fees";
            dgvPurchased.Columns[4].Width = 100;

            dgvPurchased.Columns[5].HeaderText = "Payment Geteway";
            dgvPurchased.Columns[5].Width = 120;

            dgvPurchased.Columns[6].HeaderText = "Status";
            dgvPurchased.Columns[6].Width = 80;

            dgvPurchased.Columns[6].HeaderText = "Ticket Type";
            dgvPurchased.Columns[6].Width = 100;

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
            _customer = clsCustomer.Find(TXT_Username.Text.Trim(), TXT_Password.Text.Trim());
            if(_customer != null )
            {

                dgvPurchased.Visible = true;
                PNL_Login.Visible = false;
                Referesh();
            }
            else
                MessageBox.Show("Wrong UserName Or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
