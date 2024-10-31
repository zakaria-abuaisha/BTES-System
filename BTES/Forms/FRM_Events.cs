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
        public FRM_Events()
        {
            InitializeComponent();
        }

        private void Referesh()
        {
            dgvEvent.DataSource = clsEvent.GetAllRecord();

            dgvEvent.Columns[0].HeaderText = "Event ID";
            dgvEvent.Columns[0].Width = 70;

            dgvEvent.Columns[1].HeaderText = "Title";
            dgvEvent.Columns[1].Width = 120;

            dgvEvent.Columns[2].HeaderText = "Content";
            dgvEvent.Columns[2].Width = 300;

            dgvEvent.Columns[3].HeaderText = "Location";
            dgvEvent.Columns[3].Width = 100;

            dgvEvent.Columns[4].HeaderText = "Date";
            dgvEvent.Columns[4].Width = 100;

            dgvEvent.Columns[5].HeaderText = "Event Type";
            dgvEvent.Columns[5].Width = 120;

            dgvEvent.Columns[6].HeaderText = "Number of\nRegular Tickets";
            dgvEvent.Columns[6].Width = 110;

            dgvEvent.Columns[7].HeaderText = "Number of\nVIPTickets";
            dgvEvent.Columns[7].Width = 100;

            dgvEvent.Columns[8].HeaderText = "Regular\nPrice";
            dgvEvent.Columns[8].Width = 70;

            dgvEvent.Columns[9].HeaderText = "VIP\nPrice";
            dgvEvent.Columns[9].Width = 80;

            if (dgvEvent.Rows.Count > 0)
            {
                LBL_NoRecords.Visible = false;
                CMS_Options.Enabled = true;


                // .....
            }
            else
            {
                LBL_NoRecords.Visible = true;
                CMS_Options.Enabled = false;
            }
        }

        private void FRM_Events_Load(object sender, EventArgs e)
        {
            Referesh();
        }
    }
}
