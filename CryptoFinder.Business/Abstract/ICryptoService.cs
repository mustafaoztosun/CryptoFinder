using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoFinder.Business.Abstract
{
    public interface ICryptoService
    {
        List<Crypto> GetAllCryptos();
        Crypto GetCryptoById(int id);
        Crypto CreateCrypto(Crypto crypto);
        Crypto UpdateCrypto(Crypto crypto);
        void DeletedCrypto(int id);
    }
}
