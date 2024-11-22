using BTES.Business_layer;
using BTES.Business_layer.Event_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Forms.Ticket
{
    public partial class FRM_PurchaseTicket : Form
    {
        private ClsEvent _event;

        public FRM_PurchaseTicket(ClsEvent Event)
        {
            InitializeComponent();
            _event = Event;
            _FillUpFormWithData();
        }

        private void _FillUpFormWithData()
        {
            LBL_Title.Text = _event.title;
            LBL_Location.Text = _event.location;
            
            if(_event is clsSportEvent SE)
            {
                LBL_EventType.Text = "Sports";
                LBL_TeamsOrArtist.Text = "Teams : ";
                TXT_TeamsOrArtists.Text = SE.Team_VS_Team;
            }
            else if(_event is clsConcertEvent CE)
            {
                LBL_EventType.Text = "Concerts";
                LBL_TeamsOrArtist.Text = "Band Or Artist : ";
                TXT_TeamsOrArtists.Text = CE.Band_Or_Artist;
            }

            TXT_Content.Text = _event.eventContent;
            LBL_Regular.Text = _event.regularTickets.ToString();
            LBL_RegularPrice.Text = _event.regularPrice.ToString();
            LBL_VIP.Text = _event.VIPTickets.ToString();
            LBL_VIPPrice.Text = _event.VIPprice.ToString();
            COB_PaymentGateway.SelectedIndex = 0;

            if (_event.regularTickets == 0)
            {
                BTN_Buy.Enabled = false;
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                TXT_Username.Enabled = false;
                TXT_UserPassword.Enabled = false;
                COB_PaymentGateway.Enabled = false;

            }
        }

        private void BTN_Buy_Click(object sender, EventArgs e)
        {
            ClsPurchasedTicket PT = new ClsPurchasedTicket();

            if (string.IsNullOrEmpty(TXT_AccountID.Text.Trim()) || string.IsNullOrEmpty(TXT_AccountPassword.Text.Trim()) || string.IsNullOrEmpty(TXT_Username.Text.Trim()) ||
                string.IsNullOrEmpty(TXT_UserPassword.Text.Trim()))
            {
                MessageBox.Show("Please Fill up All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ClsCustomer.Find(TXT_Username.Text.Trim(), TXT_UserPassword.Text.Trim()) == null)
            {
                MessageBox.Show("Wrong UserName Or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (RB_Regular.Checked)
                PT.Fees = _event.regularPrice;
            else
                PT.Fees = _event.VIPprice;

            PT.PaymentGateway = (ClsPurchasedTicket.enPaymentMethod)COB_PaymentGateway.SelectedIndex + 1;
            PT.Customer = ClsCustomer.Find(TXT_Username.Text.Trim(), TXT_UserPassword.Text.Trim());
            PT.Event = ClsEvent.FindEvent(_event.event_ID);
            if (RB_Regular.Checked)
                PT.TicketType = "Regular";
            else
                PT.TicketType = "VIP";

            if (PT.Purchase(TXT_AccountID.Text.Trim(), TXT_AccountPassword.Text.Trim()))
            {
                MessageBox.Show("Ticket Purchased Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RB_Regular.Enabled = false;
                RB_VIP.Enabled = false;
                LBL_PT_ID.Text = PT.PurchasedTicket_ID.ToString();
                BTN_Buy.Enabled = false;
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                TXT_Username.Enabled = false;
                TXT_UserPassword.Enabled = false;
                COB_PaymentGateway.Enabled = false;
            }
            else
                MessageBox.Show("Error Occurred During Processing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RB_Regular_CheckedChanged(object sender, EventArgs e)
        {
            if (_event.regularTickets == 0)
            {
                BTN_Buy.Enabled = false;
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                TXT_Username.Enabled = false;
                TXT_UserPassword.Enabled = false;
                COB_PaymentGateway.Enabled = false;

            }
            else
            {
                BTN_Buy.Enabled = true;
                TXT_AccountID.Enabled = true;
                TXT_AccountPassword.Enabled = true;
                TXT_Username.Enabled = true;
                COB_PaymentGateway.Enabled = true;
                TXT_UserPassword.Enabled = true;
            }
        }

        private void RB_VIP_CheckedChanged(object sender, EventArgs e)
        {
            if (_event.VIPTickets == 0)
            {
                BTN_Buy.Enabled = false;
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                TXT_Username.Enabled = false;
                TXT_UserPassword.Enabled = false;
                COB_PaymentGateway.Enabled = false;
            }
            else
            {
                BTN_Buy.Enabled = true;
                TXT_AccountID.Enabled = true;
                TXT_AccountPassword.Enabled = true;
                TXT_Username.Enabled = true;
                TXT_UserPassword.Enabled = true;
                COB_PaymentGateway.Enabled = true;
            }
        }

        private void LL_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This Feature is not implemented yet");
        }
    }
}
