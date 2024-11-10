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

namespace BTES.Forms.Events
{
    public partial class FRM_AddEvent : Form
    {
        private ClsEvent NewEvent = new ClsEvent();
        private int admin_ID;
        public FRM_AddEvent(int Admin_ID)
        {
            InitializeComponent();
            admin_ID = Admin_ID;

        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()) || string.IsNullOrEmpty(txtPriceOfVipTicket.Text.Trim()) || string.IsNullOrEmpty(txtPriceOfRegularTicket.Text.Trim())
                || string.IsNullOrEmpty(txtNumberOfVipTicket.Text.Trim()) || string.IsNullOrEmpty(txtNumberofRegularTicket.Text.Trim()) || string.IsNullOrEmpty(txtLocation.Text.Trim()) ||
                string.IsNullOrEmpty(txtContent.Text.Trim()))
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Please Fill Up All The fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            NewEvent.eventContent = txtContent.Text;
            NewEvent.eventDate = DTP_EventDate.Value;
            NewEvent.title = txtTitle.Text;
            NewEvent.VIPprice = Convert.ToInt32(txtPriceOfVipTicket.Text);
            NewEvent.VIPTickets = Convert.ToInt32(txtNumberOfVipTicket.Text);
            NewEvent.regularTickets = Convert.ToInt32(txtNumberofRegularTicket.Text);
            NewEvent.regularPrice = Convert.ToInt32(txtPriceOfRegularTicket.Text);
            NewEvent.location = txtLocation.Text;
            NewEvent.createdByUserID = admin_ID;
            NewEvent.eventTypeID = cbmEventType.FindString(cbmEventType.Text) + 1;

            if (NewEvent.Save())
            {
                lblEventID.Text = NewEvent.event_ID.ToString();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_AddEvent_Load(object sender, EventArgs e)
        {
            DataTable allEventType = ClsEventType.GetAllRecord();

            foreach (DataRow row in allEventType.Rows)
            {
                cbmEventType.Items.Add(row[1]);
            }
            DTP_EventDate.MinDate = DateTime.Now.AddDays(1);
        }

        //Event to handle the required fields
        private void IsRequired(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, "This field is required!");

                Temp.Select(0, 0);
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtLocation_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtContent_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtPriceOfVipTicket_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtPriceOfRegularTicket_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtNumberOfVipTicket_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtNumberofRegularTicket_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtNumberofRegularTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtNumberOfVipTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtPriceOfRegularTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtPriceOfVipTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
