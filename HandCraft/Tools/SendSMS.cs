using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools
{
    public class SendSMS
    {
        public bool SendRegisterSMS(string mobileNo, string username, string pass)
        {

            var smsText = "نام کاربری و کلمه عبور شما در بازارچه اینترنتی صنایع دستی به شرح زیر می باشد:";
            smsText += "\\n";
            smsText += "نام کاربری: ";
            smsText += username;
            smsText += "\\n";
            smsText += "کلمه عبور: ";
            smsText += pass;
            smsText += "\\n";
            smsText += "لطفا به منظور ورود به فروشگاه ، به آدرس زیر مراجعه نمایید:";
            smsText += "\\n";
            smsText += "tabrizhandicrafts.com";

            var client = new RestClient("http://188.0.240.110/api/select");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"send\"" +
                                              ",\"uname\" : \"09144198583\"" +
                                              ",\"pass\":  \"1375989081\"" +
                                              ",\"message\" :"+
                                              $" \"{smsText}\"" +
                                              ",\"from\": \" +98500010407308865\"" +
                                              $",\"to\" : [\"{mobileNo}\"]}}"
                    , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response.IsSuccessful;
        }

        public bool SendSuccessOrderPayment(string mobileNo, string orderNo, long orderId)
        {

            var smsText = "سفارش شما با شماره ";
            smsText += orderNo;
            smsText += "در بازارچه اینترنتی صنایع دستی در حال آماده سازی می باشد.";
            smsText += "\\n";
            smsText += "tabrizhandicrafts.com/Home/CoustomerOrderTrace/";
            smsText += orderId;
            smsText += "\\n";


            var client = new RestClient("http://188.0.240.110/api/select");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"op\" : \"send\"" +
                                              ",\"uname\" : \"09144198583\"" +
                                              ",\"pass\":  \"1375989081\"" +
                                              ",\"message\" :" +
                                              $" \"{smsText}\"" +
                                              ",\"from\": \" +98500010407308865\"" +
                                              $",\"to\" : [\"{mobileNo}\"]}}"
                    , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response.IsSuccessful;
        }
    }
}
