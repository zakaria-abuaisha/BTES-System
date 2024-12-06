using BTES.Business_layer;
using BTES.Business_layer.Event_Management;
using BTES.Forms.Ticket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Forms.Events
{
    public partial class FRM_Events : Form
    {
        private ClsAdmin admin;
        DataTable _Events = new DataTable();

        public FRM_Events(ClsAdmin Admin)
        {
            InitializeComponent();
            admin = Admin;
            if (admin != null)
            {
                //if this constructor is called when the system is used by (admin), this the button (BTN_AddEvent) which is the button that allow the admin to
                //add events will be enabled,
                BTN_AddEvent.Visible = true;
            }


        }

        private void Referesh()
        {
            _Events = ClsEvent.GetAllRecord();

            _Events.Columns.Add("Month", typeof(int));
            _Events.Columns.Add("Year", typeof(int));

            dgvEvent.DataSource = _Events;

            if (dgvEvent.Rows.Count > 0)
            {
                dgvEvent.Visible = true;
                LBL_NoRecords.Visible = false;
                CMS_Options.Enabled = true;
                cbFilterBy.SelectedIndex = 1;
                cbFilterBy.Enabled = true;

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


                foreach (DataRow row in _Events.Rows)
                {
                    DateTime date = DateTime.Parse(row["Event_Date"].ToString());
                    row["Month"] = date.Month;
                    row["Year"] = date.Year;
                }
                if (dgvEvent.Columns["Month"] != null)
                    dgvEvent.Columns["Month"].Visible = false;
                

                if (dgvEvent.Columns["Year"] != null)              
                    dgvEvent.Columns["Year"].Visible = false;

                
                
            }
            else
            {
                LBL_NoRecords.Visible = true;
                CMS_Options.Enabled = false;
                dgvEvent.Visible = false;
                cbFilterBy.Enabled = false;
                cbDate.Enabled = false;
                DTP_Date.Enabled = false;
            }
        }

        private void FRM_Events_Load(object sender, EventArgs e)
        {
            Referesh();
        }

        private void purchaseTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsEvent Event = new ClsEvent();

            if (dgvEvent.CurrentRow.Cells[4].Value.ToString() == "Sport")
            {
                Event = clsSportEvent.FindbyEvent_ID(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            }

            else if (dgvEvent.CurrentRow.Cells[4].Value.ToString() == "Concert")
            {
                Event = clsConcertEvent.FindbyEvent_ID(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            }


            FRM_PurchaseTicket frm = new FRM_PurchaseTicket(Event);
            frm.ShowDialog();
            Referesh();
        }

        private void BTN_AddEvent_Click(object sender, EventArgs e)
        {
            FRM_AddEvent frm = new FRM_AddEvent(admin.adminID);
            frm.ShowDialog();
            Referesh();
        }

        private void dgvEvent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvent.Rows.Count > 0 && admin == null)
            {
                DataGridViewCell cell = dgvEvent.CurrentRow.Cells[0];

                ToolTip tip = new ToolTip();
                tip.SetToolTip(dgvEvent, "Use (Right mouse click) to purchase");
            }
        }

        private void dgvEvent_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if(admin  != null)
            {
                CMS_Options.Items["purchaseTicketToolStripMenuItem"].Visible = false;
                CMS_Options.Items["RateEventToolStripMenuItem1"].Visible = false;
            }
            else
            {
                CMS_Options.Items["purchaseTicketToolStripMenuItem"].Visible = true;
                CMS_Options.Items["RateEventToolStripMenuItem1"].Visible = true;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Event ID":
                    FilterColumn = "Event_ID";
                    break;
                case "Event Name":
                    FilterColumn = "Title";
                    break;

                case "Date":
                    FilterColumn = "Event_Date";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _Events.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "Event_ID")
                //in this case we deal with numbers not string.
                _Events.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            else
                _Events.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            DTP_Date.Visible = cbFilterBy.Text == "Date";
            cbDate.Visible = cbFilterBy.Text == "Date";


            if (DTP_Date.Visible)
            {
                txtFilterValue.Visible = false;
                DTP_Date.Focus();
            }

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
                _Events.DefaultView.RowFilter = "";
            }
            else
                txtFilterValue.Enabled = true;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string FilterColumn = cbDate.Text;

                FilterData(FilterColumn, DTP_Date.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData(string filterColumn, DateTime filterValue)
        {
            if (filterColumn == "Month")
            {
                _Events.DefaultView.RowFilter = $"Month = {filterValue.Month}";
            }
            else if (filterColumn == "Year")
            {
                _Events.DefaultView.RowFilter = $"Year = {filterValue.Year}";
            }
            else if (filterColumn == "Day")
            {
                _Events.DefaultView.RowFilter = $"Event_Date = '{filterValue.ToShortDateString()}'";
            }
        }

        private void RateEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_RaateEvent frm = new FRM_RaateEvent(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
        }
    }
}
