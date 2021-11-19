using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;

namespace ClientBlazor.Data.Pictures
{
    public class PicturesService : IPicturesService
    {
        private IPicturesService _picturesServiceImplementation;
        private string _privateKey = "682fb1282501c1857dfd409f0daa8285";
        private HttpClient client;

        public PicturesService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<string> UploadImage(IBrowserFile file)
        {
            byte[] array;
            string base64;
            using(var memoryStream = new MemoryStream())
            {
                var openReadStream = file.OpenReadStream();
                await openReadStream.CopyToAsync(memoryStream);
                array = memoryStream.ToArray();
                base64 = Convert.ToBase64String(array);
            }
            MultipartFormDataContent form = new MultipartFormDataContent();
            var formUrlEncodedContent = new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("image", base64)});
            form.Add(formUrlEncodedContent);
            var httpResponseMessage = await client.PostAsync($"https://api.imgbb.com/1/upload/?key={_privateKey}", formUrlEncodedContent);
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            var data = JObject.Parse(json);
            return data.SelectToken("url").Value<String>();
        }
    }
}