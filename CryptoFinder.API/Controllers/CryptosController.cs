using CryptoFinder.Business.Abstract;
using CryptoFinder.Business.Concrete;
using CryptoFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoFinder.API.Controllers
{
    [Route("api/[controller]")]

    //Validation are done automatically
    [ApiController]
    public class CryptosController : ControllerBase
    {
        private ICryptoService _cryptoService;

        public CryptosController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var cryptos = _cryptoService.GetAllCryptos();
            //Return the response 200 and append to the body data.
            return Ok(cryptos); //200 + data
        }
        [HttpGet("{id}")]

        //A 404 error is thrown when non-existent data is called.
        public IActionResult Get(int id)
        {
            var crypto = _cryptoService.GetCryptoById(id);
            if (crypto != null)
            {
                return Ok(crypto);
            }
            return NotFound();// return 404 Error

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns></returns>

        [HttpPost]
        public Crypto Post([FromBody] Crypto crypto)
        {
            return _cryptoService.CreateCrypto(crypto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Crypto crypto)
        {
            if (_cryptoService.GetCryptoById(crypto.Id) != null)
            {
                return Ok(_cryptoService.UpdateCrypto(crypto));//200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_cryptoService.GetCryptoById(id) != null)
            {
                return Ok();//200
            }
            return NotFound();
        }
    }
}
