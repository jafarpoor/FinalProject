using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Services
{
    public class SmsService
    {
        // sms with KavehNegar
        public void Send(string PhoneNumber , string Code)
        {
            var client = new WebClient();
            string url = $"http://panel.kavenegar.com/v1/apikey/verify/lookup.json?receptor={PhoneNumber}&token={Code}&template=MyTemplate";
            var content = client.DownloadString(url);
        }
    }
}
