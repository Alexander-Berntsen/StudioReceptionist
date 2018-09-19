using Capgemini.StudioReceptionist.Entities;
using Capgemini.StudioReceptionist.ServiceConsumer.SPO;
using Newtonsoft.Json;
using System.Web.Http;

namespace Capgemini.StudioReceptionist.BL.WebApi.Controllers
{
    public class SPOController : ApiController
    {
        private static Credentials credentials = new Credentials();
        SharePointOnlineServiceConsumer spoServiceConsumer = new SharePointOnlineServiceConsumer("https://capgemini.sharepoint.com/sites/StudioReceptionist",
            credentials.SharePointUsername, credentials.SharePointPassword);


        public Guest SaveUser(Guest guest, string faceId)
        {
            spoServiceConsumer.SaveGuestSPOnline(guest, faceId);
            return guest;
        }
        public void CreateLogEntry(string email, string host)
        {
            spoServiceConsumer.CreateLogEntrySPOnline( email, host);
        }
        public void CheckOutLogEntry(string email)
        {
            spoServiceConsumer.CheckOutLogEntrySPOnline(email);
        }
        public bool GuestCheckedIn(string email)
        {
            return spoServiceConsumer.CheckIfGuestCheckedIn(email);
        }

        public Guest FetchUserData(string faceId)
        {
            Guest guest = spoServiceConsumer.GetGuest(faceId);
            return guest;
        }
        //Print Message To be used or not used Later
        public string WelcomeMessage(Guest guest)
        {
            return $"Welcome {guest.FirstName} {guest.LastName}!";
        }

    }
}