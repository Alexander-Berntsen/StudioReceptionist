using System;

namespace Capgemini.StudioReceptionist.Entities
{
    public class Guest
    {
        //Properties
        private string _FirstName;
        private string _LastName;
        private string _MobileNumber;
        private string _Company;
        private string _EmailAddress;
        private bool _AllowSaveData;

        public Guest()
        {

        }

        //Constructor
        public Guest(string _FirstName, string _LastName, string _MobileNumber,
            string _Company, string _EmailAddress, bool _AllowSaveData)
        {
            this.FirstName = _FirstName;
            this.LastName = _LastName;
            this.MobileNumber = _MobileNumber;
            this.Company = _Company;
            this.EmailAddress = _EmailAddress;
            this.AllowSaveData = _AllowSaveData;
        }
        //GET & SET
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public bool  AllowSaveData { get; set; }
        ////Properties Define..
        //private string firstName;
        //private string lastName;
        //private string mobileNumber;
        //private string company;
        //private bool allowSaveData;
        //private bool checkedIn; 
        //private DateTime checkedInDateTime;
        //private DateTime checkedOutDateTime;
        //private string host;
        //private string eMailAddress;

        //public Guest() { }

        ////Constructor...
        //public Guest(string firstName, string lastName, string mobileNumber, string company, bool allowSaveData,
        //    bool checkedIn, DateTime checkedInDateTime, DateTime checkedOutDateTime, string host, string eMailAddress)
        //{
        //    //Initialization Of Properties..


        //    this.firstName = firstName; 
        //    this.lastName = lastName; 
        //    this.mobileNumber = mobileNumber;
        //    this.company = company;
        //    this.allowSaveData = allowSaveData;
        //    this.checkedIn = checkedIn;
        //    this.checkedInDateTime = checkedInDateTime;
        //    this.checkedOutDateTime = checkedOutDateTime;
        //    this.host = host;
        //    this.eMailAddress = eMailAddress;

        //}

        ////Get & Set

        ////public string FirstName { get => this.firstName; set => value = this.firstName; }
        ////public string LastName { get => this.lastName; set => value = this.lastName; }
        ////public string MobileNumber { get => this.mobileNumber; set => value = this.mobileNumber; }
        ////public string Company { get => this.company; set => value = this.company; }
        ////public bool AllowSaveData { get => this.allowSaveData; set => value = this.allowSaveData; }
        ////public bool CheckedIn { get => this.checkedIn; set => value = this.checkedIn; }
        ////public DateTime CheckedInDateTime { get => this.checkedInDateTime; set => value = this.checkedInDateTime; }
        ////public DateTime CheckedOutDateTime { get => this.checkedOutDateTime; set => value = this.checkedOutDateTime; }
        ////public string Host { get => this.host; set => value = this.host; }
        ////public string EmailAddress { get => this.eMailAddress; set => value = this.eMailAddress; }

        //public string FirstName
        //{
        //    get { return firstName; }
        //    set { firstName = value; }
        //}
        //public string LastName
        //{
        //    get { return lastName; }
        //    set { lastName = value; }
        //}
        //public string MobileNumber
        //{
        //    get { return mobileNumber; }
        //    set { mobileNumber = value; }
        //}
        //public string Company
        //{
        //    get { return company; }
        //    set { company = value; }
        //}
        //public bool AllowSaveData
        //{
        //    get { return allowSaveData; }
        //    set { allowSaveData = value; }
        //}
        //public bool CheckedIn
        //{
        //    get { return checkedIn; }
        //    set { checkedIn = value; }
        //}
        //public DateTime CheckedInDateTime
        //{
        //    get { return checkedInDateTime; }
        //    set { checkedInDateTime = value; }
        //}
        //public DateTime CheckedOutDateTime
        //{
        //    get { return checkedOutDateTime; }
        //    set { checkedOutDateTime = value; }
        //}
        //public string Host
        //{
        //    get { return host; }
        //    set { host = value; }
        //}
        //public string EmailAddress
        //{
        //    get { return eMailAddress; }
        //    set { eMailAddress = value; }
        //}

    }

}
