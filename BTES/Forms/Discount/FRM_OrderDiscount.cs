using BTES.Business_layer;
using BTES.Business_layer.Discounts;
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

namespace BTES.Forms.Discount
{
    public partial class FRM_OrderDiscount : Form
    {
        public FRM_OrderDiscount()
        {
            InitializeComponent();

            _FillComboBox();
        }

        private void _FillComboBox()
        {
            foreach (DiscountType item in ClsDiscountTypes.DiscountTypes)
            {
                COB_DiscountTypes.Items.Add(item.typeName);
            }
            COB_DiscountTypes.SelectedIndex = 0;
            
        }

        private void BTN_Request_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TXT_UserName.Text.Trim()) || string.IsNullOrEmpty(TXT_Password.Text.Trim()) || string.IsNullOrEmpty(TXT_Proof.Text.Trim()))
            {
                LBL_Error.Text = "Please Fill up All Fields.";
                LBL_Error.Visible = true;
                return;
            }

            ClsCustomer customer = ClsCustomer.Find(TXT_UserName.Text.Trim(), TXT_Password.Text.Trim());
            if (customer == null)
            {
                LBL_Error.Text = "Wrong Username Or Password.";
                LBL_Error.Visible = true;

                return;
            }

            if (ClsDiscount.IsDiscountExist(customer.Customer_ID))
            {
                LBL_Error.Text = "Already have a Discount.";
                LBL_Error.Visible = true;

                return;
            }

            ClsDiscount discount = new ClsDiscount();
            discount.Customer_ID = customer.Customer_ID;
            discount.Proof_Of_Identity = TXT_Proof.Text;
            discount.DiscountType = COB_DiscountTypes.SelectedIndex + 1;

            if(discount.OrderDiscount())
            {
                LBL_Error.Text = "Request Approved.";
                LBL_Error.ForeColor = Color.Green;
                LBL_Error.Visible = true;
                BTN_Request.Enabled = false;
            }
            else
            {
                LBL_Error.Text = "Request Rejected.";
                LBL_Error.ForeColor = Color.Red;
            }

        }
    }
}
