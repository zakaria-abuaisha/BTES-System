using BTES.Data_Access.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer.Discounts
{
    public class ClsDiscount
    {

        public int DiscountOrder_ID { private set; get; }
        public int Customer_ID { set; get; }
        public string Proof_Of_Identity { set; get; }
        public int DiscountType { set; get; }
        public bool Status { private set; get; }

        public ClsDiscount()
        {
            DiscountOrder_ID = -1;
            Customer_ID = -1;
            Proof_Of_Identity = null;
            DiscountType = -1;
            Status = false;
        }        
        
        private ClsDiscount(int discountOrder_ID, int customer_id, string proof, int discountType, bool status)
        {
            DiscountOrder_ID = discountOrder_ID;
            Customer_ID = customer_id;
            Proof_Of_Identity = proof;
            DiscountType = discountType;
            Status = status;
        }

        private bool Check_Proof_Of_Identity()
        {
            //..
            // verify proof of identity
            //..
            return true;
        }

        public bool OrderDiscount()
        {
            this.Status = Check_Proof_Of_Identity();

            this.DiscountOrder_ID = ClsDiscountsData.AddNewDiscount_Orders(this.Customer_ID, this.Proof_Of_Identity, this.DiscountType, this.Status);

            return (this.DiscountOrder_ID != -1) && (this.Status);
        }

        public static bool IsDiscountExist(int Customer_ID)
        {
            return ClsDiscountsData.IsDiscountExist(Customer_ID);
        }

        public static ClsDiscount Find(int Customer_ID)
        {
            int DiscountOrder_ID = -1;
            string Proof_Of_Identity = "";
            int DiscountType = -1;
            bool Status = false;

            if (ClsDiscountsData.GetDiscount_By_CustomerID(Customer_ID, ref DiscountOrder_ID, ref Proof_Of_Identity, ref DiscountType, ref Status))
                return new ClsDiscount(DiscountOrder_ID, Customer_ID, Proof_Of_Identity, DiscountType, Status);
            else
                return null;
        }

    }
}
