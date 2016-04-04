using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using App1.Model;

namespace App1.Data
{
    public class NewsManager
    {
        IRestService<NewsItem> resetService;
        public NewsManager(IRestService<NewsItem> service)
        {
            resetService = service;
        }
        /// <summary>
        ///  Получаем список новостей
        /// </summary>
        /// <returns>List<NewsItem> </returns>
        public Task<List<NewsItem>> GetTaskAsync()
        {
            return resetService.RefreshDataAsync();
        }
        /// <summary>
        ///  получаем данные конкретной новости
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        public Task<NewsItem> GetItem(NewsItem Item)
        {
            return resetService.GetItem(Item.id);
        }
    }
}
