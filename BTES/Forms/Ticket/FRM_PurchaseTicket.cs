using BTES.Business_layer;
using BTES.Business_layer.Discounts;
using BTES.Business_layer.Event_Management;
using BTES.Business_layer.Tickets;
using BTES.Data_Access.Discounts;
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

            
            //if (_event.regularTickets == 0)
            //{
            //    BTN_Buy.Enabled = false;
            //    TXT_AccountID.Enabled = false;
            //    TXT_AccountPassword.Enabled = false;
            //    TXT_Username.Enabled = false;
            //    TXT_UserPassword.Enabled = false;
            //    COB_PaymentGateway.Enabled = false;
            //}
        }

        private void _PrepareWaitingListTicket(ClsCustomer customer)
        {
            clsWaitingList WaitingList = new clsWaitingList();

            WaitingList.CustomerID = customer.Customer_ID;
            WaitingList.EventID = _event.event_ID;
            WaitingList.JoinDate = DateTime.Now;
            WaitingList.PaymentMethod = (int)(ClsPurchasedTicket.enPaymentMethod)COB_PaymentGateway.SelectedIndex + 1;
            WaitingList.AccountID = TXT_AccountID.Text.Trim();
            WaitingList.Password = TXT_AccountPassword.Text.Trim();

            if (RB_Regular.Checked)
                WaitingList.TicketType = "Regular";
            else
                WaitingList.TicketType = "VIP";


            if (WaitingList.Save())
            {
                MessageBox.Show("This Event is Full. we Added you to Waiting List.", "Event is Full", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RB_Regular.Enabled = false;
                RB_VIP.Enabled = false;
                BTN_Buy.Enabled = false;
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                TXT_Username.Enabled = false;
                TXT_UserPassword.Enabled = false;
                COB_PaymentGateway.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error Occurred During Processing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _PreparePurchasedTicket(ClsCustomer customer, ClsDiscount discount)
        {
            ClsPurchasedTicket PT = new ClsPurchasedTicket();

            if (RB_Regular.Checked)
                PT.Fees = (_event.regularPrice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value);
            else
                PT.Fees = (_event.VIPTickets * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value);

            PT.PaymentGateway = (ClsPurchasedTicket.enPaymentMethod)COB_PaymentGateway.SelectedIndex + 1;
            PT.Customer = customer;
            PT.Event = _event;
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


        private void BTN_Buy_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TXT_AccountID.Text.Trim()) || string.IsNullOrEmpty(TXT_AccountPassword.Text.Trim()) || string.IsNullOrEmpty(TXT_Username.Text.Trim()) ||
                string.IsNullOrEmpty(TXT_UserPassword.Text.Trim()))
            {
                MessageBox.Show("Please Fill up All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClsCustomer customer = ClsCustomer.Find(TXT_Username.Text.Trim(), TXT_UserPassword.Text.Trim());
            if (customer == null)
            {
                MessageBox.Show("Wrong UserName Or Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClsDiscount discount = ClsDiscount.Find(customer.Customer_ID);
            if(discount != null)
            {
                LBL_RegularPrice.Text = (_event.regularPrice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value).ToString();
                LBL_RegularPrice.ForeColor = Color.Green;
                LBL_VIPPrice.Text = (_event.VIPprice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value).ToString();
                LBL_VIPPrice.ForeColor = Color.Green;
            }

            else
            {
                LBL_RegularPrice.ForeColor = Color.Black;
                LBL_VIPPrice.ForeColor = Color.Black;
            }

            if (ClsPurchasedTicket.IsEventFull(_event.event_ID, RB_Regular.Checked ? "Regular_Tickets" : "VIP_Tickets"))
            {
                _PrepareWaitingListTicket(customer);
            }
            else
            {
                _PreparePurchasedTicket(customer, discount);
                
            }
        }

        private void RB_Regular_CheckedChanged(object sender, EventArgs e)
        {
            //if (_event.regularTickets == 0)
            //{
            //    BTN_Buy.Enabled = false;
            //    TXT_AccountID.Enabled = false;
            //    TXT_AccountPassword.Enabled = false;
            //    TXT_Username.Enabled = false;
            //    TXT_UserPassword.Enabled = false;
            //    COB_PaymentGateway.Enabled = false;

            //}
            //else
            //{
            //    BTN_Buy.Enabled = true;
            //    TXT_AccountID.Enabled = true;
            //    TXT_AccountPassword.Enabled = true;
            //    TXT_Username.Enabled = true;
            //    COB_PaymentGateway.Enabled = true;
            //    TXT_UserPassword.Enabled = true;
            //}
        }

        private void RB_VIP_CheckedChanged(object sender, EventArgs e)
        {
            //if (_event.VIPTickets == 0)
            //{
            //    BTN_Buy.Enabled = false;
            //    TXT_AccountID.Enabled = false;
            //    TXT_AccountPassword.Enabled = false;
            //    TXT_Username.Enabled = false;
            //    TXT_UserPassword.Enabled = false;
            //    COB_PaymentGateway.Enabled = false;
            //}
            //else
            //{
            //    BTN_Buy.Enabled = true;
            //    TXT_AccountID.Enabled = true;
            //    TXT_AccountPassword.Enabled = true;
            //    TXT_Username.Enabled = true;
            //    TXT_UserPassword.Enabled = true;
            //    COB_PaymentGateway.Enabled = true;
            //}
        }

        private void LL_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This Feature is not implemented yet");
        }
    }
}
