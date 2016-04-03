using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using App1.Model;

namespace App1.Data
{
    public class NewsManager
    {
        IRestService resetService;
        public NewsManager(IRestService service)
        {
            resetService = service;
        }
        public Task<List<NewsItem>> GetTaskAsync()
        {
            return resetService.RefreshDataAsync();
        }
    }
}
