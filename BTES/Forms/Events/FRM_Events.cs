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
        DataTable _Event = new DataTable();

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
            _Event = ClsEvent.GetAllRecord();

            _Event.Columns.Add("Month", typeof(int));
            _Event.Columns.Add("Year", typeof(int));

            dgvEvent.DataSource = _Event;

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


                foreach (DataRow row in _Event.Rows)
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
                CMS_Options.Items["UpdateToolStripMenuItem1"].Visible = true;
                CMS_Options.Items["RateEventToolStripMenuItem1"].Visible = false;
            }
            else
            {
                CMS_Options.Items["purchaseTicketToolStripMenuItem"].Visible = true;
                CMS_Options.Items["UpdateToolStripMenuItem1"].Visible = false;
                CMS_Options.Items["RateEventToolStripMenuItem1"].Visible = true;
            }
        }


        private void UpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClsEvent Event = new ClsEvent();

            if (dgvEvent.CurrentRow.Cells[4].Value.ToString() == "Sport")
            {
                Event = clsSportEvent.FindbyEvent_ID(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            }

            else if(dgvEvent.CurrentRow.Cells[4].Value.ToString() == "Concert")
            {
                Event = clsConcertEvent.FindbyEvent_ID(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            }

            FRM_AddEvent frm = new FRM_AddEvent(admin.adminID, Event);
            frm.ShowDialog();
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
                _Event.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "EventID")
                //in this case we deal with numbers not string.
                _Event.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            else
                _Event.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            dateTimePicker1.Visible = cbFilterBy.Text == "Date";
            cbDate.Visible = cbFilterBy.Text == "Date";


            if (dateTimePicker1.Visible)
            {
                txtFilterValue.Visible = false;
                dateTimePicker1.Focus();
            }

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
                _Event.DefaultView.RowFilter = "";
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

                FilterData(FilterColumn, dateTimePicker1.Value);
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
                _Event.DefaultView.RowFilter = $"Month = {filterValue.Month}";
            }
            else if (filterColumn == "Year")
            {
                _Event.DefaultView.RowFilter = $"Year = {filterValue.Year}";
            }
            else if (filterColumn == "Day")
            {
                _Event.DefaultView.RowFilter = $"Event_Date = '{filterValue.ToShortDateString()}'";
            }
        }

        private void RateEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_RaateEvent frm = new FRM_RaateEvent(Convert.ToInt32(dgvEvent.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
        }
    }
}
