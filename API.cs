using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPI_Inlämning_1;

namespace webAPI_inlämning_2
{
    class API
    {
        static HttpClient client = new HttpClient();


        public async Task<HttpStatusCode> DeleteResourceAsync(Uri resourceUri,int Id)
        {

           var response = await client.DeleteAsync($"{resourceUri}/{Id}");

           return response.StatusCode;

        }

        public async Task<HttpResponseMessage> PostResourceAsync<T>(Uri resourceUri, T resource)
        {


            HttpResponseMessage response = await client.PostAsJsonAsync(
                resourceUri, resource);

            response.EnsureSuccessStatusCode();


            return response;

        }


        public async Task<List<T>> GetResourceAsync<T>(Uri resourceUri)
        {

            HttpResponseMessage response = await client.GetAsync(resourceUri);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<T> deserializedResource = JsonConvert.DeserializeObject<List<T>>(responseBody);

            return deserializedResource;

        }
    }
}
