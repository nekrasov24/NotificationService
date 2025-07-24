using Newtonsoft.Json;
using NotificationService.Models;
using RestSharp;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vonage;
using Vonage.Common;
using Vonage.Messaging;
using Vonage.Request;

namespace NotificationService.Services.NotificationService
{
    public class Sender : ISender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Sender> _logger;
        private readonly VonageClient _vonageClient;

        public Sender(IConfiguration configuration, ILogger<Sender> logger, VonageClient vonageClient)
        {
            _configuration = configuration;
            _logger = logger;
            _vonageClient = vonageClient;
        }

        public async Task SendMessageByMailAsync(string publisherAdress, string recieverAdress, string topic, string content)
        {
            using var client = new SmtpClient(_configuration["smtphostconnectionstring:smtphost"],
                int.Parse(_configuration["smtphostconnectionstrin:port"]))
            {
                Credentials = new NetworkCredential(_configuration["smtpcredentials:auth"],
                _configuration["smtpcredentials:bearertoken"]),
                EnableSsl = true
            };
            await client.SendMailAsync("hello@demomailtrap.co", "d.a.04nekrasov@gmail.com", "Hello world", "testbody");
            var message = $"mail is sent to adress {recieverAdress}";
            _logger.LogInformation(message);
        }

        public async Task SendMessageBySmsAsync(RequestSmsNotificationModel requestSmsNotificationModel)
        {

            var apiKey = _configuration["Vonage:apiKey"];
            var apiSecret = _configuration["Vonage:apiSecret"];
            var credentials = Credentials.FromApiKeyAndSecret(apiKey, apiSecret);

                
            var client = new VonageClient(credentials);
                var response = await client.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest()
                {
                    To = requestSmsNotificationModel.RecieverAdress,
                    From = requestSmsNotificationModel.PublisherAdress,
                    Text = requestSmsNotificationModel.Text
                });
                var message = $"sms is sent to adress {requestSmsNotificationModel.RecieverAdress}";

                _logger.LogInformation(message);
            



        }




    }

}