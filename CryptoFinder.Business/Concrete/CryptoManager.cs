using CryptoFinder.Business.Abstract;
using CryptoFinder.DataAccess.Abstract;
using CryptoFinder.DataAccess.Conctare;
using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoFinder.Business.Concrete
{
    
    public class CryptoManager : ICryptoService
    {
        private ICryptoRepository _cryptoRepository;

        public CryptoManager(ICryptoRepository cryptoRepository)
        {
            _cryptoRepository = cryptoRepository;
        }
        public Crypto CreateCrypto(Crypto crypto)
        {
            return _cryptoRepository.CreateCrypto(crypto);
        }

        public void DeletedCrypto(int id)
        {
            _cryptoRepository.DeleteCrypto(id);
        }

        public List<Crypto> GetAllCryptos()
        {
            return _cryptoRepository.GetAllCryptos();
        }

        public Crypto GetCryptoById(int id)
        {
            if (id>0)
            {
                return _cryptoRepository.GetCryptoById(id);
            }

            throw new Exception("id can not be lass than 1");
        }

        public Crypto UpdateCrypto(Crypto crypto)
        {
            return _cryptoRepository.UpdateCrypto(crypto);
        }
    }
}
