using DataLayer.ResponseClasses;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DataLayer.APIDataFetch
{
    public class BSEMethods
    {
        public List<BSEScrips> BSEGetTickers()
        {
            //BSEScrips scripsData = new BSEScrips();
            //List<object> scripsDataList = new List<object>();

            var options = new RestClientOptions("https://api.bseindia.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
            };
            var client = new RestClient(options);
            var request = new RestRequest("/BseIndiaAPI/api/ListofScripData/w?Group=&Scripcode=&industry=&segment=Equity&status=", Method.Get);
            request.AddHeader("authority", "api.bseindia.com");
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "en-GB,en-US;q=0.9,en;q=0.8,hi;q=0.7");
            request.AddHeader("origin", "https://www.bseindia.com");
            request.AddHeader("referer", "https://www.bseindia.com/");
            request.AddHeader("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            //RestResponse response = Task.Run(()=> { await client.ExecuteAsync(request); });
            RestResponse response = client.Execute(request);

            //foreach(var content in response.Content)
            var list = JsonConvert.DeserializeObject<List<BSEScrips>>(response.Content);

            //Console.WriteLine(response.Content);

            using (var db = new StockContext())
            {
                //db.RemoveRange(0, list.Count());
                db.Database.ExecuteSqlRawAsync("TRUNCATE TABLE bseScris");
                //db.bseScrips.RemoveRange(db.bseScrips);
                db.AddRangeAsync(list);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

                return list;
        }

        public List<BSEEqtyMarketWatch> BSEEquityMarketWatch(int pageNo, string flag, string ddlVal1, string ddlVal2, string srts, int srtb)
        {
            var options = new RestClientOptions("https://api.bseindia.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 Edg/121.0.0.0",
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/BseIndiaAPI/api/GetStkCurrMain_new/w?flag={flag}&ddlVal1={ddlVal1}&ddlVal2={ddlVal2}&m=0&pgN={pageNo}&srts={srts}&srtb={srtb}", Method.Get);
            request.AddHeader("authority", "api.bseindia.com");
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("origin", "https://www.bseindia.com");
            request.AddHeader("referer", "https://www.bseindia.com/");
            request.AddHeader("sec-ch-ua", "\"Not A(Brand\";v=\"99\", \"Microsoft Edge\";v=\"121\", \"Chromium\";v=\"121\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            //RestResponse response = await client.ExecuteAsync(request);
            RestResponse response = client.Execute(request);

            List<BSEEqtyMarketWatch> list2 = new List<BSEEqtyMarketWatch>();

            if (response.Content != null)
                list2 = JsonConvert.DeserializeObject<List<BSEEqtyMarketWatch>>(response.Content);

            //Console.WriteLine(response.Content);

            /*using (var db = new StockContext())
            {
                //db.RemoveRange(0, list.Count());
                db.AddRangeAsync(list2);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }*/

            return list2;
        }

        public BSEStockInfo BSEStockInformation(int scripCode)
        {
            var options = new RestClientOptions("https://api.bseindia.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 Edg/121.0.0.0",
            };
            var client = new RestClient(options);
            var request = new RestRequest($"/BseIndiaAPI/api/ComHeadernew/w?quotetype=EQ&scripcode={scripCode}&seriesid=", Method.Get);
            request.AddHeader("authority", "api.bseindia.com");
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("if-modified-since", "Tue, 13 Feb 2024 07:05:21 GMT");
            request.AddHeader("origin", "https://www.bseindia.com");
            request.AddHeader("referer", "https://www.bseindia.com/");
            request.AddHeader("sec-ch-ua", "\"Not A(Brand\";v=\"99\", \"Microsoft Edge\";v=\"121\", \"Chromium\";v=\"121\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            //RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);

            RestResponse response = client.Execute(request);

            var temp3 = JsonConvert.DeserializeObject<BSEStockInfo>(response.Content);

            return temp3;
        }
    }
}
