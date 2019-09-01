using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.DataAccess.Interfaces
{
    public interface IBaseRepository
    {
        Task Create<T>(T obj) where T : class;
        Task<List<T>> Read<T>() where T : class;
        Task<T> ReadSingle<T>(int id) where T : class;
        Task Update<T>(T obj, int id) where T : class;
        Task Delete<T>(T obj, int id) where T : class;
    }
}
