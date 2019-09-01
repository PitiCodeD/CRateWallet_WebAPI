using CRateWallet_WebAPI.DataAccess.Contexts;
using CRateWallet_WebAPI.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRateWallet_WebAPI.DataAccess.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly WalletContext _context;

        public BaseRepository(WalletContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task Create<T>(T obj) where T : class
        {
            _context.Entry(obj).State = EntityState.Added;
            await SaveAndChange();
        }

        public async Task Delete<T>(T obj, int id) where T : class
        {
            _context.Entry(obj).State = EntityState.Deleted;
            await SaveAndChange();
        }

        public async Task<List<T>> Read<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> ReadSingle<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update<T>(T obj, int id) where T : class
        {
            _context.Entry(obj).State = EntityState.Modified;
            await SaveAndChange();
        }
        private async Task SaveAndChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
