using CryptoFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoFinder.DataAccess.Abstract
{
    public interface ICryptoRepository
    {
        List<Crypto> GetAllCrypto();

        Crypto GetCryptoById(int id);

        Crypto CreateCrypto(Crypto crypto);

        Crypto UpdateCrypto(Crypto crypto);

        void DeleteCrypto(int id);
        List<Crypto> GetAllCryptos();
    }
}
