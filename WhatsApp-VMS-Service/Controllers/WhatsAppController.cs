using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsApp_VMS_Service.AppCode;
using WhatsApp_VMS_Service.Model;
using WhatsApp_VMS_Service.Services;

namespace WhatsApp_VMS_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        [HttpGet("opt-in")]
        public async Task<string> WhatsappOptIn(string mobile, string secretkey)
        {
            if (secretkey != GlobalModel.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";
            wModel.Channel = "WHATSAPP";
            wModel.Version = "1.1";
            wModel.Format = "json";
            wModel.Method = "OPT_IN";
            return await WhatsAppService.OptIn(wModel);

        }

        [HttpGet("send-template")]
        public async Task<string> WhatsappSendTemplate(string mobile, string templateId, string secretkey)
        {
            if (secretkey != GlobalModel.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";

            wModel.Version = "1.1";

            wModel.Method = "SendMessage";
            wModel.Message = "this is test template message";
            return await WhatsAppService.SendTemplate(wModel);

        }

        [HttpGet("send-message")]
        public async Task<string> WhatsappSendMessage(string mobile, string message, string secretkey)
        {
            if (secretkey != GlobalModel.SecretKey)
            {
                return "secret key not valid";
            }

            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";

            wModel.Version = "1.1";
            wModel.MessageType = "DATA_TEXT";
            wModel.Method = "SendMessage";
            wModel.Message = message;
            return await WhatsAppService.SendMessage(wModel);

        }

        [HttpGet]
        [Route("/default/api/start-cronjob")]
        public string StartCronJob()
        {
            if (GlobalModel.IsCronJobRunning)
            {
                return "CronJob Already Running";
            }
            else
            {
                CronJob cs = new CronJob();
                GlobalModel.IsCronJobRunning = true;
                return "Cronjob Started";
            }
        }
    }
}
