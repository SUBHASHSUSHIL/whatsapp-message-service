using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WhatsApp_VMS_Service.Model;

namespace WhatsApp_VMS_Service.Services
{
    public class WhatsAppService
    {
        public static async Task<string> OptIn(WhatsAppModel wModel)
        {


            // Construct the URL with query parameters
            string url = $"{wModel.APIURL}?method={wModel.Method}&format={wModel.Format}&userid={wModel.UserId}&password={wModel.Password}" +
                         $"&phone_number={wModel.SendTo}&v={wModel.Version}&auth_scheme={wModel.AuthSchema}&channel={wModel.Channel}";

            using (var client = new HttpClient())
            {
                try
                {
                    // Send GET request
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Response:");
                        Console.WriteLine(responseContent);
                        return responseContent;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                        return response.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                    return ex.ToString();
                }
            }
        }


        public static async Task<string> SendTemplate(WhatsAppModel wModel)
        {
            //string apiUrl = "https://media.smsgupshup.com/GatewayAPI/rest";

            // Adjusted parameters with supported data_encoding
            var requestData = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("send_to", wModel.SendTo),
        //new KeyValuePair<string, string>("msg_type", "HSM"),
        new KeyValuePair<string, string>("userid", wModel.UserId),
        new KeyValuePair<string, string>("auth_scheme", wModel.AuthSchema),
        new KeyValuePair<string, string>("password", wModel.Password),
        new KeyValuePair<string, string>("method", wModel.Method),
        new KeyValuePair<string, string>("v", wModel.Version),
        //new KeyValuePair<string, string>("format", "json"),
        new KeyValuePair<string, string>("msg", wModel.Message),
        //new KeyValuePair<string, string>("data_encoding", "TEXT"),
        //new KeyValuePair<string, string>("isHSM", "false"),
        //new KeyValuePair<string, string>("isTemplate", "false"),
        //new KeyValuePair<string, string>("data_encoding", "TEXT"),
        // Use TEXT or UNICODE_TEXT
    };
            try
            {
                using (var client = new HttpClient())
                {
                    // Create form content with request data
                    var formContent = new FormUrlEncodedContent(requestData);

                    // Set the Content-Type header explicitly
                    formContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    // Send the POST request
                    var response = await client.PostAsync(wModel.APIURL, formContent);

                    // Check if successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Response:");
                        Console.WriteLine(responseContent);
                        return responseContent;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                        return response.StatusCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public static async Task<string> SendMessage(WhatsAppModel wModel)
        {
            //string apiUrl = "https://media.smsgupshup.com/GatewayAPI/rest";
            //string userId = "2000241495"; // Replace with your actual user ID
            //string password = "nB$yvp4U"; // Replace with your actual password

            //string authScheme = "plain";
            //string version = "1.1";
            //string format = "text";
            //string method = "SendMessage";

            var formData = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("send_to", wModel.SendTo),
            new KeyValuePair<string, string>("msg_type", wModel.MessageType),
            new KeyValuePair<string, string>("userid", wModel.UserId),
            new KeyValuePair<string, string>("auth_scheme", wModel.AuthSchema),
            new KeyValuePair<string, string>("password", wModel.Password),
            new KeyValuePair<string, string>("v", wModel.Version),
            //new KeyValuePair<string, string>("format", format),
            new KeyValuePair<string, string>("isHSM", wModel.IsHSM.ToString()),
            new KeyValuePair<string, string>("data_encoding", wModel.DataEncoding),
            new KeyValuePair<string, string>("method", wModel.Method),
            //new KeyValuePair<string, string>("media_url", mediaUrl)
            new KeyValuePair<string, string>("msg", wModel.Message)
        };

            using (var client = new HttpClient())
            {
                try
                {
                    // Create form content with request data
                    var formContent = new FormUrlEncodedContent(formData);

                    // Set the Content-Type header explicitly
                    formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(wModel.APIURL, formContent);

                    // Check if request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Response:");
                        Console.WriteLine(responseContent);
                        return responseContent;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                        return response.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occurred: {ex.Message}");
                    return ex.ToString();
                }
            }
        }
    }
}
