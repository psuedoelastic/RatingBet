using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App1.Model;

namespace App1.Data
{
    public interface IRestService<T> where T:Items
    {
        Task<List<T>> RefreshDataAsync();
        Task<T> GetItem(int id);
        
    }
}
