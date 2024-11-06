using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public class ClsCustomer : ClsPerson
    {

        public int Customer_ID { set; get; }


        public ClsCustomer() : base()
        {
            this.Person_ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.Age = -1;
            this.Password = "";
            this.UserName = "";

            this.Customer_ID = -1;
        }

        private ClsCustomer(int Customer_ID, int Person_ID, string FirstName, string LastName,  string Phone,  string Email,  string Address,  int Age,  string Password,  string UserName)
        {
            this.Customer_ID = Customer_ID;
            this.Person_ID = Person_ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.Age = Age;
            this.Password = Password;
            this.UserName = UserName;
        }

        public static ClsCustomer Find(int Customer_ID)
        {
            int Person_ID = -1;
            string FirstName = "";
            string LastName = "";
            string Phone = "";
            string Email = "";
            string Address = "";
            int Age = -1;
            string Password = "";
            string UserName = "";

            if (ClsCustomerDA.GetCustomer_Info_By_CustomerID(Customer_ID, ref Person_ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref Age, ref Password, ref UserName))
                return new ClsCustomer(Customer_ID, Person_ID, FirstName, LastName, Phone, Email, Address,  Age,  Password,  UserName);
            else
                return null;
        }

        public static ClsCustomer Find(string UserName, string Password)
        {
            int Customer_ID = -1;
            int Person_ID = -1;
            string FirstName = "";
            string LastName = "";
            string Phone = "";
            string Email = "";
            string Address = "";
            int Age = -1;


            if (ClsCustomerDA.GetCustomer_Info_By_UserNameANDPassword(UserName, Password, ref Customer_ID, ref Person_ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref Age))
                return new ClsCustomer(Customer_ID, Person_ID, FirstName, LastName, Phone, Email, Address, Age, Password, UserName);
            else
                return null;
        }
    }
}
