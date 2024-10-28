using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{
    public abstract class clsPerson
    {

        public int Person_ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public int Age { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }



        public clsPerson()
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

 
        }

        protected clsPerson(int Person_ID, string FirstName, string LastName, string Phone, string Email, string Address, int Age, string Password, string UserName)
        {
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


    }
}
