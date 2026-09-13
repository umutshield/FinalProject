using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);              //istediğimiz data cache'te var mı
        void Remove(string key);             //cache'tan data silme
        void RemoveByPattern(string pattern);   //örneğin metot isminde category olanları sil

    }
}
