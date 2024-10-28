using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public class clsCustomer : clsPerson
    {

        public int Customer_ID { set; get; }


        public clsCustomer() : base()
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

        private clsCustomer(int Customer_ID, int Person_ID, string FirstName, string LastName,  string Phone,  string Email,  string Address,  int Age,  string Password,  string UserName)
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

        public static clsCustomer Find(int Customer_ID)
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

            if (clsCustomerDA.GetCustomer_Info_By_In_Customer(Customer_ID, ref Person_ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref Age, ref Password, ref UserName))
                return new clsCustomer(Customer_ID, Person_ID, FirstName, LastName, Phone, Email, Address,  Age,  Password,  UserName);
            else
                return null;
        }
    }
}
