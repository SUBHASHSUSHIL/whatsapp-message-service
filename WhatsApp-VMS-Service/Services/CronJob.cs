using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WhatsApp_VMS_Service.AppCode;
using WhatsApp_VMS_Service.Model;

namespace WhatsApp_VMS_Service.Services
{
    public class CronJob
    {
        private Timer timer;
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiUrl = "http://mpexcise.ecosmartdc.com:6004/api/CameraTrackingData/Pagination";

        public CronJob()
        {        // Create a timer that runs the CheckSchedule method every second
            timer = new Timer(CheckSchedule, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        }

        private void CheckSchedule(object state)
        {
            DateTime now = DateTime.Now;

            //if(now.Second.ToString().Contains("0"))
            //{
            //    Console.WriteLine("Task executed every 10 seconds: " + now);
            //}

            if (now.Second == 0)
            {
                Task.Run(() => ExecuteTask());
            }

        }

        private async Task ExecuteTask()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(_apiUrl + "?FromData=" + DateTime.Now.AddMinutes(-1).ToString() + "&ToDate" + DateTime.Now.ToString());
                cmtdata cmtdadsad = JsonSerializer.Deserialize<cmtdata>(response);

                List<CameraTrackingModel> cameraList = cmtdadsad.cameraTrackingData;

                if(cameraList!=null && cameraList.Count()>0)
                {
                    WhatsAppModel wModel = new WhatsAppModel();

                    wModel.SendTo = GlobalModel.MobileNumber; // Replace with the phone number you want to opt in
                    wModel.AuthSchema = "plain";
                    wModel.Channel = "WHATSAPP";
                    wModel.Version = "1.1";
                    wModel.Format = "json";
                    wModel.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel);

                    WhatsAppModel wModel2 = new WhatsAppModel();

                    wModel2.SendTo = GlobalModel.MobileNumber2; // Replace with the phone number you want to opt in
                    wModel2.AuthSchema = "plain";
                    wModel2.Channel = "WHATSAPP";
                    wModel2.Version = "1.1";
                    wModel2.Format = "json";
                    wModel2.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel2);

                    WhatsAppModel wModel3 = new WhatsAppModel();

                    wModel3.SendTo = GlobalModel.MobileNumber3; // Replace with the phone number you want to opt in
                    wModel3.AuthSchema = "plain";
                    wModel3.Channel = "WHATSAPP";
                    wModel3.Version = "1.1";
                    wModel3.Format = "json";
                    wModel3.Method = "OPT_IN";
                    await WhatsAppService.OptIn(wModel3);
                    Thread.Sleep(1000);
                }

                foreach (var rdata in cameraList)
                {



                    WhatsAppModel wModel2 = new WhatsAppModel();

                    wModel2.SendTo = GlobalModel.MobileNumber; // Replace with the phone number you want to opt in
                    wModel2.AuthSchema = "plain";

                    wModel2.Version = "1.1";

                    wModel2.Method = "SendMessage";
                    //wModel2.Message = "this is test template message";
                    wModel2.Message = "Vehicle detected from Ajeevi VMS Camera.";
                    await WhatsAppService.SendTemplate(wModel2);


                    WhatsAppModel wModel3 = new WhatsAppModel();

                    wModel3.SendTo = GlobalModel.MobileNumber2; // Replace with the phone number you want to opt in
                    wModel3.AuthSchema = "plain";

                    wModel3.Version = "1.1";

                    wModel3.Method = "SendMessage";
                    wModel2.Message = "this is test template message";
                    //wModel3.Message = "Vehicle detected from Ajeevi VMS Camera.";
                    await WhatsAppService.SendTemplate(wModel3);

                    WhatsAppModel wModel4 = new WhatsAppModel();

                    wModel4.SendTo = GlobalModel.MobileNumber3; // Replace with the phone number you want to opt in
                    wModel4.AuthSchema = "plain";

                    wModel4.Version = "1.1";

                    wModel4.Method = "SendMessage";
                    wModel4.Message = "this is test template message";
                    //wModel3.Message = "Vehicle detected from Ajeevi VMS Camera.";
                    await WhatsAppService.SendTemplate(wModel4);



                    //WhatsAppModel wModel2 = new WhatsAppModel();

                    //wModel2.SendTo = GlobalModel.MobileNumber; // Replace with the phone number you want to opt in
                    //wModel2.AuthSchema = "plain";

                    //wModel2.Version = "1.1";
                    //wModel2.MessageType = "DATA_TEXT";
                    //wModel2.Method = "SendMessage";
                    //wModel2.Message = "ANPR Alert from Ajeevi VMS";
                    //await WhatsAppService.SendMessage(wModel2);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //var rdata = "http://mpexcise.ecosmartdc.com:6004/api/CameraTrackingData/Pagination";
            //if (rdata != null)
            //{

            //    WhatsAppModel wModel = new WhatsAppModel();

            //    wModel.SendTo = "919818476105"; // Replace with the phone number you want to opt in
            //    wModel.AuthSchema = "plain";
            //    wModel.Channel = "WHATSAPP";
            //    wModel.Version = "1.1";
            //    wModel.Format = "json";
            //    wModel.Method = "OPT_IN";
            //    await WhatsAppService.OptIn(wModel);

            //    Thread.Sleep(1000);

            //    WhatsAppModel wModel2 = new WhatsAppModel();

            //    wModel2.SendTo = "919818476105"; // Replace with the phone number you want to opt in
            //    wModel.AuthSchema = "plain";

            //    wModel.Version = "1.1";

            //    wModel.Method = "SendMessage";
            //    wModel.Message = "this is test template message";
            //    await WhatsAppService.SendTemplate(wModel);
            //}


        }

        public void Stop()
        {
            timer?.Change(Timeout.Infinite, 0);
        }
    }


    public class cmtdata
    {
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public List<CameraTrackingModel> cameraTrackingData { get; set; }


    }

    public class CameraTrackingModel
    {
        public int Id { get; set; }
     
        public int CameraId { get; set; }
        public string VichelImage { get; set; }
        public string NoPlateImage { get; set; }
        public string VichelNo { get; set; }
        public bool Status { get; set; }
        public DateTime RegDate { get; set; }
    }
}
