using CryptoFinder.DataAccess.Abstract;
using CryptoFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFinder.DataAccess.Conctare
{

    //Implemented with ICryptoRepository in Abstract Folder
    public class CryptoRepository : ICryptoRepository
    {
        //Adding a new data is provided here
        public async Task<Crypto> CreateCrypto(Crypto crypto)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                cryptoDbContext.Cryptos.Add(crypto);
                await cryptoDbContext.SaveChangesAsync();
                return crypto;
            }
        }
        //Line of code to delete selected data
        public async Task DeleteCrypto(int id)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                var deletedCrypto = await GetCryptoById(id);
                cryptoDbContext.Cryptos.Remove(deletedCrypto);
                await cryptoDbContext.SaveChangesAsync();
            }
        }

        //Showing all added data
        public async Task<List<Crypto>> GetAllCrypto()
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return await cryptoDbContext.Cryptos.ToListAsync();
            }
        }

        public async Task<List<Crypto>> GetAllCryptos()
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return await cryptoDbContext.Cryptos.ToListAsync();
            }
        }

        public async Task<Crypto> GetCryptoById(int id)
        {
            //Since ID is the primary key, we used the Find method
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return await cryptoDbContext.Cryptos.FindAsync(id);
            }
        }

        public async Task<Crypto> GetCryptoByName(string name)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return await cryptoDbContext.Cryptos.FirstOrDefaultAsync(x => x.Name.ToLower()==name.ToLower());
            }
        }

        //Where added data is updated
        public async Task<Crypto> UpdateCrypto(Crypto crypto)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                cryptoDbContext.Cryptos.Update(crypto);
                await cryptoDbContext.SaveChangesAsync();
                return crypto;
            }
        }
    }
}
