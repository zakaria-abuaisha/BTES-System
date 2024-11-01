using BTES.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BTES.Business_layer
{

    public class ClsAdmin : ClsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int adminID { set; get; }
        public int personID { set; get; }



        public ClsAdmin()
        {
            this.adminID = -1;
            this.personID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.Age = -1;
            this.Password = "";
            this.UserName = "";


            Mode = enMode.AddNew;
        }

        private ClsAdmin(int Admin_ID, int Person_ID, string FirstName, string LastName, string Phone, string Email, string Address, int Age, string Password, string UserName)
        {
            this.adminID = Admin_ID;
            this.personID = Person_ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.Age = Age;
            this.Password = Password;
            this.UserName = UserName;

            Mode = enMode.Update;
        }

        public static ClsAdmin FindbyAdmin_ID(int AdminID)
        {
            int Person_ID = -1; string FirstName = ""; string LastName = ""; string Phone = ""; string Email = ""; string Address = ""; int Age = -1; string Password = ""; string UserName = ""; ;
            if (ClsAdminData.FindByAdmin_ID(AdminID, ref Person_ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref Age, ref Password, ref UserName))

                return new ClsAdmin(AdminID, Person_ID, FirstName, LastName, Phone, Email, Address, Age, Password, UserName);
            else
                return null;
        }


        public static ClsAdmin Login(string Username, string Password)
        {

            int AdminID = -1; int Person_ID = -1; string FirstName = ""; string LastName = ""; string Phone = ""; string Email = ""; string Address = ""; int Age = -1;
            if (ClsAdminData.Login(ref AdminID, ref Person_ID, ref FirstName, ref LastName, ref Phone, ref Email, ref Address, ref Age, Password, Username))

                return new ClsAdmin(AdminID, Person_ID, FirstName, LastName, Phone, Email, Address, Age, Password, Username);
            else
                return null;
        }


    }

}


