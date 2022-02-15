using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFinder.DataAccess.Abstract
{
    public interface ICryptoRepository
    {
        //All Methods are made asynchronous
        Task<List<Crypto>> GetAllCrypto();
        
        Task<Crypto> GetCryptoById(int id);

        Task<Crypto> GetCryptoByName(string name);

        Task<Crypto> CreateCrypto(Crypto crypto);

        Task<Crypto> UpdateCrypto(Crypto crypto);

        Task DeleteCrypto(int id);
        Task<List<Crypto>> GetAllCryptos();
    }
}
