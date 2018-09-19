using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SP = Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Xml;

using Capgemini.StudioReceptionist.Entities;
using System.IO;

namespace Capgemini.StudioReceptionist.ServiceConsumer.SPO
{
    public class SharePointOnlineServiceConsumer
    {
        public string username = string.Empty;
        public string password = string.Empty;
        // define client context 
        private ClientContext myClientContext;

        // constructor
        public SharePointOnlineServiceConsumer(string sharePointOnlineSiteURL, string userName, string password)
        {
            // ClienContext - Get the context for the SharePoint Online Site  
            using (myClientContext = new ClientContext(sharePointOnlineSiteURL))
            {

                SecureString secureString = new SecureString();

                foreach (char c in password)
                {
                    secureString.AppendChar(c);
                }


                // SharePoint Online Credentials  
                myClientContext.Credentials = new SharePointOnlineCredentials(userName, secureString);

            }
        }

        // Update guest
        public void UpdateGuestSPOnline(Guest guest)
        {


        }

        public void DeleteGuestSPOnline(string guestId)
        {
            // Get the SharePoint web  
            Web web = myClientContext.Web;

            List oList = this.myClientContext.Web.Lists.GetByTitle("Guests");

            myClientContext.Load(oList);

            ListItemCollection listItems = oList.GetItems(CamlQuery.CreateAllItemsQuery());
            myClientContext.Load(listItems);
            myClientContext.ExecuteQuery();

            Guest guest = new Guest();
            foreach (var listItem in listItems)
            {
                if (listItem["GuestId"].ToString() == guestId)
                {
                    listItem.DeleteObject();

                }
            }

            myClientContext.ExecuteQuery();
        }

        // Get guest by id
        public Guest GetGuest(string personId)
        {
            // Get the SharePoint web  
            Web web = myClientContext.Web;

            List oList = this.myClientContext.Web.Lists.GetByTitle("PersonList");

            myClientContext.Load(oList);

            ListItemCollection listItems = oList.GetItems(CamlQuery.CreateAllItemsQuery());
            myClientContext.Load(listItems);
            myClientContext.ExecuteQuery();

            Guest guest = new Guest();
            foreach (var listItem in listItems)
            {
                if (listItem["AzurePersonId"].ToString() == personId)
                {
                    guest = new Guest(
                    listItem["FirstName"].ToString(),
                    listItem["LastName"].ToString(),
                    listItem["MobileNumber"].ToString(),
                    listItem["Company"].ToString(),

                    // fix this
                    listItem["EmailAddress"].ToString(),
                    Convert.ToBoolean(listItem["SaveData"])
                    );

                }
            }

            return guest;
        }


        //Save guest
        //public void SaveGuestSPOnline(Guest guest, string faceId)
        //{

        //    // ClienContext - Get the context for the SharePoint Online Site  

        //    // Get the SharePoint web  
        //    Web web = myClientContext.Web;
        //    //Get the user
        //    User user = myClientContext.Web.EnsureUser(guest.EmailAddress);

        //    //load user properties
        //    myClientContext.Load(user);
        //    // Load the Web properties  
        //    myClientContext.Load(web);


        //    // Execute the query to the server.  
        //    myClientContext.ExecuteQuery();



        //    List oList = this.myClientContext.Web.Lists.GetByTitle("Guests");
        //    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
        //    ListItem oListItem = oList.AddItem(itemCreateInfo);


        //    //oListItem["GuestId"] = guest.EmailAddress;
        //    oListItem["GuestId"] = faceId;

        //    oListItem["First_x0020_Name"] = guest.FirstName;
        //    oListItem["Last_x0020_Name"] = guest.LastName;
        //    oListItem["Mobile_x0020_number"] = guest.MobileNumber;
        //    oListItem["Company"] = guest.Company;
        //    oListItem["SaveData"] = guest.AllowSaveData;
        //    oListItem["CheckedIn"] = guest.CheckedIn;
        //    oListItem["CheckedInDateTime"] = guest.CheckedInDateTime;
        //    oListItem["CheckedOutDateTime"] = guest.CheckedOutDateTime;
        //    oListItem["EmailAddress"] = guest.EmailAddress;


        //    // people picker field
        //    FieldUserValue[] users = new FieldUserValue[1];

        //    //Add the user to the first element of the FieldUserValue array.
        //    users[0] = new FieldUserValue();
        //    users[0].LookupId = user.Id;

        //    oListItem["Host"] = users;



        //    oListItem.Update();
        //    myClientContext.ExecuteQuery();

        //}

        public void SaveGuestSPOnline(Guest guest, string azurePersonId)
        {

            // ClienContext - Get the context for the SharePoint Online Site  

            // Get the SharePoint web  
            //Web web = myClientContext.Web;
            //Get the user
            //User user = myClientContext.Web.EnsureUser(guest.EmailAddress);

            //load user properties
            //myClientContext.Load(user);

            // Load the Web properties  
            //myClientContext.Load(web);

            // Execute the query to the server.  
            //myClientContext.ExecuteQuery();

            List oList = this.myClientContext.Web.Lists.GetByTitle("PersonList");
            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            ListItem oListItem = oList.AddItem(itemCreateInfo);

            oListItem["AzurePersonId"] = azurePersonId;

            oListItem["FirstName"] = guest.FirstName;
            oListItem["LastName"] = guest.LastName;
            oListItem["MobileNumber"] = guest.MobileNumber;
            oListItem["Company"] = guest.Company;
            oListItem["SaveData"] = guest.AllowSaveData;
            oListItem["EmailAddress"] = guest.EmailAddress;

            oListItem.Update();
            myClientContext.ExecuteQuery();
        }

        public void CreateLogEntrySPOnline(string email, string host)
        {
            List oList = this.myClientContext.Web.Lists.GetByTitle("LogBook");
            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            ListItem oListItem = oList.AddItem(itemCreateInfo);

            oListItem["EmailAddress"] = email;
            oListItem["CheckedIn"] = DateTime.Now;
            oListItem["CheckedOut"] = null;
            oListItem["Host"] = host;

            oListItem.Update();
            myClientContext.ExecuteQuery();
        }

        public void CheckOutLogEntrySPOnline(string email)
        {
            List oList = this.myClientContext.Web.Lists.GetByTitle("LogBook");
            var listItems = oList.GetItems(CamlQuery.CreateAllItemsQuery());
            myClientContext.Load(listItems);
            myClientContext.ExecuteQuery();

            foreach (var oListItem in listItems)
            {
                if (oListItem["EmailAddress"].ToString() == email && oListItem["CheckedOut"]?.ToString() == null)
                {
                    oListItem["CheckedOut"] = DateTime.Now;
                    oListItem.Update();
                }
            }
            myClientContext.ExecuteQuery();
        }
        public bool CheckIfGuestCheckedIn(string email)
        {
            List oList = this.myClientContext.Web.Lists.GetByTitle("LogBook");
            var listItems = oList.GetItems(CamlQuery.CreateAllItemsQuery());
            myClientContext.Load(listItems);
            myClientContext.ExecuteQuery();

            foreach (var oListItem in listItems)
            {
                if (oListItem["EmailAddress"].ToString() == email && oListItem["CheckedOut"]?.ToString() == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
