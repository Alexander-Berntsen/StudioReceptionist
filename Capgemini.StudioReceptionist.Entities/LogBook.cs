using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.StudioReceptionist.Entities
{
    public class LogBook
    {
        //Properties

        private string _EmailAddress;
        private DateTime _CheckedIn;
        private DateTime _CheckedOut;
        private string _Host;
        //Constructor
        public LogBook()
        {

        }

        public LogBook(string EmailAddress, DateTime CheckedIn, DateTime CheckedOut, string Host)
        {
            this._EmailAddress = EmailAddress;
            this._CheckedIn = CheckedIn;
            this._CheckedOut = CheckedOut;
            this._Host = Host;
        }
        //GET & SET

        public string EmailAddress { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime CheckedOut { get; set; }
        public string Host { get; set; }
    }


}
