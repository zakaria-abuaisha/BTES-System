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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTES.Forms
{
    public partial class FRM_Tickets : Form
    {
        private ClsCustomer _customer;
        public FRM_Tickets()
        {
            InitializeComponent();
        }

        private DataTable Dt_PT = new DataTable();

        private void Referesh()
        {
            dgvPurchased.DataSource = ClsPurchasedTicket.ViewPurchasedTicket(_customer.Customer_ID);



            if (dgvPurchased.Rows.Count > 0)
            {
                LBL_NoRecords.Visible = false;


                dgvPurchased.Columns[0].HeaderText = "Purchased ID";
                dgvPurchased.Columns[0].Width = 100;

                dgvPurchased.Columns[1].HeaderText = "Event Title";
                dgvPurchased.Columns[1].Width = 175;

                dgvPurchased.Columns[2].HeaderText = "Costumer Name";
                dgvPurchased.Columns[2].Width = 175;

                dgvPurchased.Columns[3].HeaderText = "Purchased Date";
                dgvPurchased.Columns[3].Width = 110;

                dgvPurchased.Columns[4].HeaderText = "Fees";
                dgvPurchased.Columns[4].Width = 100;

                dgvPurchased.Columns[5].HeaderText = "Payment Geteway";
                dgvPurchased.Columns[5].Width = 110;

                dgvPurchased.Columns[6].HeaderText = "Status";
                dgvPurchased.Columns[6].Width = 80;

                dgvPurchased.Columns[7].HeaderText = "Ticket Type";
                dgvPurchased.Columns[7].Width = 100;
            }
            else
            {
                LBL_NoRecords.Visible = true;
                dgvPurchased.Visible = false;
                CMS_Options.Visible = false;
            }
        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_Username.Text.Trim()) || string.IsNullOrEmpty(TXT_Password.Text.Trim()))
            {
                MessageBox.Show("Please Fill up All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _customer = ClsCustomer.Find(TXT_Username.Text.Trim(), TXT_Password.Text.Trim());
            if(_customer != null )
            {

                dgvPurchased.Visible = true;
                PNL_Login.Visible = false;
                Referesh();
            }
            else
                MessageBox.Show("Wrong UserName Or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_Refund frm = new FRM_Refund(int.Parse(dgvPurchased.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
            Referesh();
        }


    }
}
