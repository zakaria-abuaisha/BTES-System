using BTES.Business_layer;
using BTES.Business_layer.Discounts;
using BTES.Business_layer.Tickets;
using BTES.Data_Access.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Forms.Ticket
{
    public partial class FRM_Refund : Form
    {
        private ClsPurchasedTicket purchasedTicket;
        public FRM_Refund(ClsPurchasedTicket PT)
        {
            InitializeComponent();

            purchasedTicket = PT;
            _Refresh();
        }

        private void _Refresh()
        {

            LBL_Title.Text = purchasedTicket.Event.title;
            LBL_Fees.Text = purchasedTicket.Fees.ToString();
            LBL_Location.Text = purchasedTicket.Event.location;
            LBL_PT_ID.Text = purchasedTicket.PurchasedTicket_ID.ToString();
            switch (purchasedTicket.Event.eventType)
            {
                case ClsEvent.enEventType.Sport:
                    LBL_EventType.Text = "Sports";
                    break;
                case ClsEvent.enEventType.Concert:
                    LBL_EventType.Text = "Concerts";
                    break;
                default:
                    LBL_EventType.Text = "Unknown";
                    break;
            }
            TXT_Content.Text = purchasedTicket.Event.eventContent;

            if (purchasedTicket.TicketType == "Regular")
                RB_Regular.Checked = true;
            else
                RB_VIP.Checked = true;

            TXT_Username.Text = purchasedTicket.Customer.UserName;
            TXT_UserPassword.Text = purchasedTicket.Customer.Password;

            COB_PaymentGateway.SelectedIndex = (int)purchasedTicket.PaymentGateway - 1;

            if (!purchasedTicket.IsRefundAllowed())
            {
                MessageBox.Show("The maximum refund period has expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                BTN_Refund.Enabled = false;
                return;
            }

            if (!purchasedTicket.Status)
            {
                MessageBox.Show("This ticket is already Refunded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXT_AccountID.Enabled = false;
                TXT_AccountPassword.Enabled = false;
                BTN_Refund.Enabled = false;
            }
        }

        private void BTN_Refund_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_AccountID.Text.Trim()) || string.IsNullOrEmpty(TXT_AccountPassword.Text.Trim()))
            {
                MessageBox.Show("Please Fill up Account ID and PIN(Password).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (purchasedTicket.Refund(TXT_AccountID.Text.Trim(), TXT_AccountPassword.Text.Trim()))
                {
                    MessageBox.Show("The Process ended successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BTN_Refund.Enabled = false;
                    TXT_AccountID.Enabled = false;
                    TXT_AccountPassword.Enabled = false;

                    clsWaitingList WaitingList = clsWaitingList.GetFirstRecordBy(purchasedTicket.Event.event_ID, purchasedTicket.TicketType);

                    if (WaitingList != null)
                    {
                        ClsPurchasedTicket newpurchasedTicket = new ClsPurchasedTicket();
                        ClsDiscount discount = ClsDiscount.Find(purchasedTicket.Customer.Customer_ID);

                        newpurchasedTicket.Event = purchasedTicket.Event;
                        newpurchasedTicket.Customer = ClsCustomer.Find(purchasedTicket.Customer.Customer_ID);
                        newpurchasedTicket.Purchase_Date = DateTime.Now;

                        newpurchasedTicket.TicketType = purchasedTicket.TicketType;
                        if (newpurchasedTicket.TicketType == "Regular")
                        {
                            newpurchasedTicket.Fees = discount != null ?
                                purchasedTicket.Event.regularPrice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value : purchasedTicket.Event.regularPrice;
                        }
                        else
                        {
                            newpurchasedTicket.Fees = discount != null ?
                                purchasedTicket.Event.VIPprice * ClsDiscountTypes.DiscountTypes[discount.DiscountType - 1].value : purchasedTicket.Event.VIPprice;
                        }
                        if (newpurchasedTicket.Purchase(WaitingList.AccountID, WaitingList.Password))
                            clsWaitingList.DeleteRecord(WaitingList.WaitingListID);
                    }

                }
                else
                {
                    MessageBox.Show("Error Occurred During Processing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error Occurred During Processing .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
