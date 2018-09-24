using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.StudioReceptionist.ServiceConsumer.ACS
{
    public class AzureCognitiveServicesServiceConsumer
    {
        public class WrapperPerson
        {

            const string subscriptionKey = "f4c5e28550b54cf891c64ef51aa63203";
            const string uriBase = "https://northeurope.api.cognitive.microsoft.com/face/v1.0/";

            //Creating Group Persons Method

            public async void CreatePersonGroup()
            {
                HttpClient client = new HttpClient();

                // Headers 
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters = "";

                string uri = uriBase + "persongroups" + "/99" + "?" + requestParameters;

                HttpResponseMessage response;

                // Request body
                string jsonRequest = "{'name': 'malmostudio'}";
                byte[] byteData = Encoding.UTF8.GetBytes(jsonRequest);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Execute the REST API call.
                    response = await client.PutAsync(uri, content);

                    // Get the JSON response.
                    string contentString = await response.Content.ReadAsStringAsync();
                }
            }

            public async Task<string> AzureTrainPersonGroup()
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var uri = uriBase + "persongroups/99/train";

                Task<HttpResponseMessage> response = client.GetAsync(uri);
                response.Wait();

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = client.PostAsync(uri, content);
                    response.Wait();
                }

                return response.Result.StatusCode.ToString();
            }

            //CREATE PERSON IN GROUP
            public async Task<string> AzureCreatePersonInGroup(string name)
            {
                HttpClient client = new HttpClient();

                // Headers 
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters = "";

                string uri = uriBase + "persongroups" + "/99" + "/persons" + requestParameters;

                

                // Request body
                string jsonRequest = "{'name': '"+name+"'}";
                byte[] byteData = Encoding.UTF8.GetBytes(jsonRequest);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Execute the REST API call.
                    Task<HttpResponseMessage> response = client.PostAsync(uri, content);
                    response.Wait();

                    // Get the JSON response.
                    string contentString = await response.Result.Content.ReadAsStringAsync();

                    var output = JsonConvert.DeserializeObject<dynamic>(contentString);

                    return output.personId;
                }

            }

            //DETECT FACE
            public async Task<string> AzureDetectFace(string base64ImageString)
            {
                string exampleBase64ImageString = base64ImageString; 
                string base64StringWithoutHeader = exampleBase64ImageString.Split(',')[1];

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                    "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                    "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

                string uri = uriBase + "detect" + "?" + requestParameters;

                byte[] byteData = Convert.FromBase64String(base64StringWithoutHeader);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");//binary datta

                    // Execute the REST API call.
                    //TODO, The line below was used instead of Task<> before. Are there any drawbacks with the Task<> approach?
                    //HttpResponseMessage response = await client.PostAsync(uri, content);
                    Task<HttpResponseMessage> response = client.PostAsync(uri, content);
                    response.Wait();

                    // Get the JSON response.
                    string contentString = await response.Result.Content.ReadAsStringAsync();
                    
                    //Deserializing the json string.
                    var output = JsonConvert.DeserializeObject<List<dynamic>>(contentString);

                    //Returning only the faceId.
                    return output[0].faceId;
                }
            }

            public async Task<string> AzureAddFaceForPerson(string personId, string imageString)
            {
                string base64StringWithoutHeader = imageString.Split(',')[1];

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string uri = uriBase + "persongroups/" + 99 + "/" + "persons/" + personId + "/" + "persistedFaces";
                //https://[location].api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/persons/{personId}/persistedFaces[?userData][&targetFace]

                byte[] byteData = Convert.FromBase64String(base64StringWithoutHeader);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    // Execute the REST API call.
                    Task<HttpResponseMessage> response = client.PostAsync(uri, content);
                    response.Wait();

                    // Get the JSON response.
                    string contentString = await response.Result.Content.ReadAsStringAsync();

                    var output = JsonConvert.DeserializeObject<dynamic>(contentString);

                    return output.persistedFaceId;
                }
            }

            //Verify a face
            public async void VerifyPerson()
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string uri = uriBase + "verify";

                HttpResponseMessage response;

                // Request body
                // TODO Fix string interpolation
                string jsonRequest = "{'faceId': 'f620d863-0363-49d8-9538-45ba49d6aa3c', 'personGroupId': '99'}";
                byte[] byteData = Encoding.UTF8.GetBytes(jsonRequest);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Execute the REST API call.
                    response = await client.PostAsync(uri, content);

                    // Get the JSON response.
                    string contentString = await response.Content.ReadAsStringAsync();
                }
            }

            //Identify a face
            public async Task<string> AzureIdentifyPerson(string faceId)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string uri = uriBase + "identify";
                
                // Request body
                string jsonRequest = "{'faceIds': ['"+faceId+"'], 'personGroupId': '99', 'maxNumOfCandidatesReturned': 1}";
                byte[] byteData = Encoding.UTF8.GetBytes(jsonRequest);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // Execute the REST API call.
                    Task<HttpResponseMessage> response = client.PostAsync(uri, content);
                    response.Wait();
                    // Get the JSON response.
                    string contentString = await response.Result.Content.ReadAsStringAsync();

                    //Deserializing the json string.
                    var output = JsonConvert.DeserializeObject<List<dynamic>>(contentString);

                    //Return the personId.
                    if (output[0].candidates.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        string result =output[0].candidates[0].personId;
                        return result;
                    }
                }
            }

            //json Prettyfy....
            static string JsonPrettyPrint(string json)
            {
                if (string.IsNullOrEmpty(json))
                    return string.Empty;

                json = json.Replace(Environment.NewLine, "").Replace("\t", "");

                StringBuilder sb = new StringBuilder();
                bool quote = false;
                bool ignore = false;
                int offset = 0;
                int indentLength = 3;

                foreach (char ch in json)
                {
                    switch (ch)
                    {
                        case '"':
                            if (!ignore) quote = !quote;
                            break;
                        case '\'':
                            if (quote) ignore = !ignore;
                            break;
                    }

                    if (quote)
                        sb.Append(ch);
                    else
                    {
                        switch (ch)
                        {
                            case '{':
                            case '[':
                                sb.Append(ch);
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', ++offset * indentLength));
                                break;
                            case '}':
                            case ']':
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', --offset * indentLength));
                                sb.Append(ch);
                                break;
                            case ',':
                                sb.Append(ch);
                                sb.Append(Environment.NewLine);
                                sb.Append(new string(' ', offset * indentLength));
                                break;
                            case ':':
                                sb.Append(ch);
                                sb.Append(' ');
                                break;
                            default:
                                if (ch != ' ') sb.Append(ch);
                                break;
                        }
                    }
                }

                return sb.ToString().Trim();
            }

        }
    }
}
