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
    public partial class FRM_Events : Form
    {
        private ClsAdmin admin;
        public FRM_Events(ClsAdmin Admin)
        {
            InitializeComponent();
            admin = Admin;
            if (admin != null)
            {
                BTN_AddEvent.Visible = true;
                dgvEvent.ContextMenuStrip = null;
            }
            

        }

        private void Referesh()
        {

            dgvEvent.DataSource = ClsEvent.GetAllRecord();

            if (dgvEvent.Rows.Count > 0)
            {
                LBL_NoRecords.Visible = false;
                CMS_Options.Enabled = true;


                dgvEvent.Columns[0].HeaderText = "Event ID";
                dgvEvent.Columns[0].Width = 40;

                dgvEvent.Columns[1].HeaderText = "Title";
                dgvEvent.Columns[1].Width = 130;


                dgvEvent.Columns[2].HeaderText = "Location";
                dgvEvent.Columns[2].Width = 100;

                dgvEvent.Columns[3].HeaderText = "Date";
                dgvEvent.Columns[3].Width = 70;

                dgvEvent.Columns[4].HeaderText = "Event Type";
                dgvEvent.Columns[4].Width = 80;


                dgvEvent.Columns[5].HeaderText = "Regular Price";
                dgvEvent.Columns[5].Width = 70;

                dgvEvent.Columns[6].HeaderText = "VIP Price";
                dgvEvent.Columns[6].Width = 80;
            }
            else
            {
                LBL_NoRecords.Visible = true;
                CMS_Options.Enabled = false;
                dgvEvent.Visible = false;
            }
        }

        private void FRM_Events_Load(object sender, EventArgs e)
        {
            Referesh();
        }

        private void purchaseTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PurchaseTicket frm = new FRM_PurchaseTicket(int.Parse(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
            Referesh();
        }

        private void BTN_AddEvent_Click(object sender, EventArgs e)
        {
            FRM_AddEvent frm = new FRM_AddEvent(admin.adminID);
            frm.ShowDialog();
            Referesh();
        }
    }
}
