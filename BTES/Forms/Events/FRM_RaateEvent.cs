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

namespace BTES.Forms.Events
{
    public partial class FRM_RaateEvent : Form
    {
        int _EventID;
        int _CustomerID;
        public FRM_RaateEvent(int EventID)
        {
            InitializeComponent();
            _EventID = EventID;
        }

        private bool IsRequired(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, "This field is required!");

                Temp.Select(0, 0);

                return false;
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
                return true;
            }
        }

        private void FRM_RaateEvent_Load(object sender, EventArgs e)
        {
            lblEventID.Text = _EventID.ToString();
        }

        private void txtLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            _CustomerID = ClsCustomer.GetCustomer_ID_By_UserName(txtUsername.Text.Trim());

            if (IsRequired(sender, e))
            {
                if (clsEventRate.IsEventRateExist(_EventID, _CustomerID))
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUsername, "This username is already Rated this Event!");
                }
                else
                {
                    //e.Cancel = false;
                    errorProvider1.SetError(txtUsername, null);
                }
            }
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void txtComent_Validating(object sender, CancelEventArgs e)
        {
            IsRequired(sender, e);
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtRate.Text.Trim()) || string.IsNullOrEmpty(txtComent.Text.Trim()))
            {
                MessageBox.Show("Please Fill up All the Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsEventRate EventRate =   new clsEventRate();

            EventRate.Event_ID = _EventID;
            EventRate.Customer_ID = _CustomerID;
            EventRate.Rate = Convert.ToInt32(txtRate.Text.Trim());
            EventRate.Comment = txtComent.Text.Trim();

            if(EventRate.Save())
            {
                MessageBox.Show("Event Rated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to Rate Event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
