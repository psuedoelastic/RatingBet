using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using App1.Model;

namespace App1.Data
{
    public class NewsService : IRestService<NewsItem>
    {
        HttpClient client;
        public List<NewsItem> Items { get; set; }
        private static int LastId { get; set; }
        public NewsService()
        {
            client = new HttpClient();


        }
        public async Task<List<NewsItem>> RefreshDataAsync()
        {
            Items = new List<NewsItem>();
            LastId = 0;
            Uri uri;
            if (LastId == 0)
            {
                 uri = new Uri(string.Format(Constant.RestURL, "apinews/list?limit=10"));
            }
            else
            {
                 uri = new Uri(string.Format(Constant.RestURL, string.Format("apinews/list?limit=10&id={0}",LastId)));
            }
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var contet = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResultReqest<NewsItem>>(contet);
                    if(result.status == 200)
                    {
                        if (LastId == 0)
                        {
                            Items = result.result;
                        }else
                        {
                            Items.AddRange(result.result);
                        }
                        foreach(NewsItem item in Items)
                        {
                            if(LastId == 0)
                            {
                                LastId = item.id;
                            }else
                            {
                                if(LastId > item.id)
                                {
                                    LastId = item.id;
                                }
                            }
                            
                        }
                    }
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Items;
        }

        public async Task<NewsItem> GetItem(int id)
        {
            var Item = new NewsItem();
            var uri = new Uri(string.Format(Constant.RestURL, "apinews/get/"+id));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var contet = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResultItemReqest<NewsItem>>(contet);
                    if (result.status == 200)
                    {
                        Item = result.result;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Item;

        }
    }
}
