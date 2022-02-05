using CryptoFinder.DataAccess.Abstract;
using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoFinder.DataAccess.Conctare
{

    //Implemented with ICryptoRepository in Abstract Folder
    public class CryptoRepository : ICryptoRepository
    {
        //Adding a new data is provided here
        public Crypto CreateCrypto(Crypto crypto)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                cryptoDbContext.Cryptos.Add(crypto);
                cryptoDbContext.SaveChanges();
                return crypto;
            }
        }
        //Line of code to delete selected data
        public void DeleteCrypto(int id)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                var deletedCrypto = GetCryptoById(id);
                cryptoDbContext.Cryptos.Remove(deletedCrypto);
                cryptoDbContext.SaveChanges();
            }
        }

        //Showing all added data
        public List<Crypto> GetAllCrypto()
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return cryptoDbContext.Cryptos.ToList();
            }
        }

        public List<Crypto> GetAllCryptos()
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return cryptoDbContext.Cryptos.ToList();
            }
        }

        public Crypto GetCryptoById(int id)
        {
            //Since ID is the primary key, we used the Find method
            using (var cryptoDbContext = new CryptoDbContext())
            {
                return cryptoDbContext.Cryptos.Find(id);
            }
        }

        //Where added data is updated
        public Crypto UpdateCrypto(Crypto crypto)
        {
            using (var cryptoDbContext = new CryptoDbContext())
            {
                cryptoDbContext.Cryptos.Update(crypto);
                cryptoDbContext.SaveChanges();
                return crypto;
            }
        }
    }
}
