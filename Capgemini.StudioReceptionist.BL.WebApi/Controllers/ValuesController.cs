using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using Newtonsoft.Json;

using Capgemini.StudioReceptionist.ServiceConsumer.SPO;

using Capgemini.StudioReceptionist.Entities;

namespace Capgemini.StudioReceptionist.BL.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private Credentials credentials = new Credentials();

        // api/values/id
        // GET api/values?id= [email address]S
        public string Get(string id)
        {
            SharePointOnlineServiceConsumer spoServiceConsumer = new SharePointOnlineServiceConsumer("https://capgemini.sharepoint.com/sites/StudioReceptionist", credentials.SharePointUsername , credentials.SharePointPassword);
       
            Guest guest = spoServiceConsumer.GetGuest(id);

            //object returnValue = JsonConvert.SerializeObject(guest);

            string returnValue = JsonConvert.SerializeObject(guest, Formatting.Indented);

            return returnValue;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Guest guest = JsonConvert.DeserializeObject<Guest>(value);

            SharePointOnlineServiceConsumer spoServiceConsumer = new SharePointOnlineServiceConsumer("https://capgemini.sharepoint.com/sites/StudioReceptionist", credentials.SharePointUsername, credentials.SharePointPassword);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(string id)
        {

            SharePointOnlineServiceConsumer spoServiceConsumer = new SharePointOnlineServiceConsumer("https://capgemini.sharepoint.com/sites/StudioReceptionist", credentials.SharePointUsername, credentials.SharePointPassword);

            spoServiceConsumer.DeleteGuestSPOnline(id);
        }
    }
}
