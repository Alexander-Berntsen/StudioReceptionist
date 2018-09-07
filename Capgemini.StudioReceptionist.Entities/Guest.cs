using System;

namespace Capgemini.StudioReceptionist.Entities
{
    public class Guest
    {
        //Properties Define..
        private string firstName;
        private string lastName;
        private string mobileNumber;
        private string company;
        private bool allowSaveData;
        private bool checkedIn; 
        private DateTime checkedInDateTime;
        private DateTime checkedOutDateTime;
        private string host;
        private string eMailAddress;

        public Guest() { }

        //Constructor...
        public Guest(string firstName, string lastName, string mobileNumber, string company, bool allowSaveData,
            bool checkedIn, DateTime checkedInDateTime, DateTime checkedOutDateTime, string host, string eMailAddress)
        {
            //Initialization Of Properties..
           

            this.firstName = firstName; 
            this.lastName = lastName; 
            this.mobileNumber = mobileNumber;
            this.company = company;
            this.allowSaveData = allowSaveData;
            this.checkedIn = checkedIn;
            this.checkedInDateTime = checkedInDateTime;
            this.checkedOutDateTime = checkedOutDateTime;
            this.host = host;
            this.eMailAddress = eMailAddress;

        }

        //Get & Set
        public string FirstName { get => this.firstName; set => value = this.firstName; }
        public string LastName { get => this.lastName; set => value = this.lastName; }
        public string MobileNumber { get => this.mobileNumber; set => value = this.mobileNumber; }
        public string Company { get => this.company; set => value = this.company; }
        public bool AllowSaveData { get => this.allowSaveData; set => value = this.allowSaveData; }
        public bool CheckedIn { get => this.checkedIn; set => value = this.checkedIn; }
        public DateTime CheckedInDateTime { get => this.checkedInDateTime; set => value = this.checkedInDateTime; }
        public DateTime CheckedOutDateTime { get => this.checkedOutDateTime; set => value = this.checkedOutDateTime; }
        public string Host { get => this.host; set => value = this.host; }
        public string EmailAddress { get => this.eMailAddress; set => value = this.eMailAddress; }
       
    }

}
