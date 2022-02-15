using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFinder.Business.Abstract
{
    public interface ICryptoService
    {
        Task<List<Crypto>> GetAllCryptos();
        Task<Crypto> GetCryptoById(int id);
        Task<Crypto> GetCryptoByName(string name);
        Task<Crypto> CreateCrypto(Crypto crypto);
        Task<Crypto> UpdateCrypto(Crypto crypto);
        Task DeletedCrypto(int id);
    }
}
