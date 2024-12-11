using BTES.Business_layer;
using BTES.Business_layer.Event_Management;
using BTES.Data_Access.Factory;
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
    public partial class FRM_AddEditEvent : Form
    {


        private int admin_ID;

        private ClsEvent Event;

        public FRM_AddEditEvent(int Admin_ID)
        {
            InitializeComponent();
            admin_ID = Admin_ID;
            this.Event = EventFactory.CreateEvent(EventFactory.enEventType.Regular);

        }
        public FRM_AddEditEvent(int Admin_ID, ClsEvent Event)
        {
            InitializeComponent();
            admin_ID = Admin_ID;

            this.Event = Event;
        
        }

        private void FillUpForm()
        {


            LBL_Title.Text = "Edit Event";
            this.Text = "Edit Event";
            cbmEventType.Enabled = false;
            txtContent.Text = Event.eventContent;
            txtLocation.Text = Event.location;
            txtNumberofRegularTicket.Text = Event.regularTickets.ToString();
            txtNumberOfVipTicket.Text = Event.VIPTickets.ToString();
            txtPriceOfRegularTicket.Text = Event.regularPrice.ToString();
            txtPriceOfVipTicket.Text = Event.VIPprice.ToString();
            DTP_EventDate.MinDate = DateTime.Now.AddDays(1);
            DTP_EventDate.Value = Event.eventDate.Date;
            txtTitle.Text = Event.title;

            if (Event.eventType == ClsEvent.enEventType.Sport)
            {
                txt_variableTXT.Text = (Event as clsSportEvent).Team_VS_Team;
                cbmEventType.Text = "Sport";
                lblEventType.Text = "Team Vs Team :";

            }
            else if (Event.eventType == ClsEvent.enEventType.Concert)
            {
                txt_variableTXT.Text = (Event as clsConcertEvent).Band_Or_Artist;
                cbmEventType.Text = "Concert";

            }
        }

        private void BTN_Save_Click(object sender, EventArgs e) 
        {
            bool isSaved = false;
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()) || string.IsNullOrEmpty(txtPriceOfVipTicket.Text.Trim()) || string.IsNullOrEmpty(txtPriceOfRegularTicket.Text.Trim())
                || string.IsNullOrEmpty(txtNumberOfVipTicket.Text.Trim()) || string.IsNullOrEmpty(txtNumberofRegularTicket.Text.Trim()) || string.IsNullOrEmpty(txtLocation.Text.Trim()) ||
                string.IsNullOrEmpty(txtContent.Text.Trim()) || string.IsNullOrEmpty(txt_variableTXT.Text.Trim()))
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Please Fill Up All The fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(Event.Mode == ClsEvent.enMode.AddNew)
            {
                Event = (cbmEventType.Text == "Sport" ? EventFactory.CreateEvent(EventFactory.enEventType.Sport) : EventFactory.CreateEvent(EventFactory.enEventType.Concerts));


            }
            Event.eventContent = txtContent.Text;
            Event.eventDate = DTP_EventDate.Value;
            Event.title = txtTitle.Text;
            Event.VIPprice = (float)Convert.ToDouble(txtPriceOfVipTicket.Text);
            Event.VIPTickets = Convert.ToInt32(txtNumberOfVipTicket.Text);
            Event.regularTickets = Convert.ToInt32(txtNumberofRegularTicket.Text);
            Event.regularPrice = (float)Convert.ToDouble(txtPriceOfRegularTicket.Text);
            Event.location = txtLocation.Text;
            Event.createdByUserID = admin_ID;




            if (cbmEventType.Text == "Sport")
            {
                clsSportEvent SportEvent = Event as clsSportEvent;

                SportEvent.Team_VS_Team = txt_variableTXT.Text;
                SportEvent.eventType = ClsEvent.enEventType.Sport;

                isSaved = SportEvent.Save();
            }
            else if (cbmEventType.Text == "Concert")
            {
                clsConcertEvent ConcertEvent = Event as clsConcertEvent;

                ConcertEvent.Band_Or_Artist = txt_variableTXT.Text;
                ConcertEvent.eventType = ClsEvent.enEventType.Concert;

                isSaved = ConcertEvent.Save();
            }

            if (isSaved)
            {
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
            if (Event.Mode == ClsEvent.enMode.Update)
            {
                FillUpForm();
            }
            else
                cbmEventType.SelectedIndex = 0;


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

        private void cbmEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmEventType.Text == "Sport")
            {
                lblEventType.Text = "Team Vs Team :";
            }

            else if (cbmEventType.Text == "Concert")
            {
                lblEventType.Text = "Artist Or Band :";

            }

        }

        private void txt_variableTXT_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }
    }
}
