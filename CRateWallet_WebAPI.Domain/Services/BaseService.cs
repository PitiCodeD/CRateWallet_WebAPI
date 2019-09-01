using CRateWallet_WebAPI.DataAccess.Interfaces;
using CRateWallet_WebAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.Domain.Services
{
    public class BaseService : IBaseService
    {
        private readonly IBaseRepository _baseRepository;
        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task Create<T>(T obj) where T : class
        {
            await _baseRepository.Create<T>(obj);
        }

        public async Task Delete<T>(T obj, int id) where T : class
        {
            await _baseRepository.Delete(obj, id);
        }

        public async Task<List<T>> Read<T>() where T : class
        {
            return await _baseRepository.Read<T>();
        }

        public async Task<T> ReadSingle<T>(int id) where T : class
        {
            return await _baseRepository.ReadSingle<T>(id);
        }

        public async Task Update<T>(T obj, int id) where T : class
        {
            await _baseRepository.Update<T>(obj, id);
        }
    }
}
