using CryptoFinder.Business.Abstract;
using CryptoFinder.DataAccess.Abstract;
using CryptoFinder.DataAccess.Conctare;
using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFinder.Business.Concrete
{
    
    public class CryptoManager : ICryptoService
    {
        private ICryptoRepository _cryptoRepository;

        public CryptoManager(ICryptoRepository cryptoRepository)
        {
             _cryptoRepository = cryptoRepository;
        }
        public async Task<Crypto> CreateCrypto(Crypto crypto)
        {
            return await _cryptoRepository.CreateCrypto(crypto);
        }

        public async Task DeletedCrypto(int id)
        {
           await _cryptoRepository.DeleteCrypto(id);
        }

        public async Task<List<Crypto>> GetAllCryptos()
        {
            return await _cryptoRepository.GetAllCryptos();
        }

        public async Task<Crypto> GetCryptoById(int id)
        {
            if (id>0)
            {
                return await _cryptoRepository.GetCryptoById(id);
            }

            throw new Exception("id can not be lass than 1");
        }

        public async Task<Crypto> GetCryptoByName(string name)
        {
            return await _cryptoRepository.GetCryptoByName(name);
        }

        public async Task<Crypto> UpdateCrypto(Crypto crypto)
        {
            return await _cryptoRepository.UpdateCrypto(crypto);
        }
    }
}
