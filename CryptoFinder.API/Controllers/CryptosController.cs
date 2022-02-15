using CryptoFinder.Business.Abstract;
using CryptoFinder.Business.Concrete;
using CryptoFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//I installed NSwag.AspNetCore

//IMPORTANT INFORMATION : The program, which was working synchronously before,
//is now made to work asynchronously.

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

        //In order to be able to read this information, 
        //I came to the Build tab from the Properties section of the project and activated 
        //it so that it could have the XML document.


        /// <summary>
        /// Get All Cryptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cryptos = await _cryptoService.GetAllCryptos();
            //Return the response 200 and append to the body data.
            return Ok(cryptos); //200 + data 
        }


        /// <summary>
        /// Get Crypto By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]

        //A 404 error is thrown when non-existent data is called.
        public async Task<IActionResult> GetCryptoById(int id)
        {
            var crypto = await _cryptoService.GetCryptoById(id);
            if (crypto != null)
            {
                return Ok(crypto);//200 + data
            }
            return NotFound();// return 404 Error

        }

        [HttpGet]
        [Route("[action]/{name}")]

        public async Task<IActionResult> GetCryptoByName(string name)
        {
            var crypto = await _cryptoService.GetCryptoByName(name);
            if (crypto != null)
            {
                return Ok(crypto); //200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Create an Crypto
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCrypto([FromBody] Crypto crypto)
        {
            var createdCrypto = await _cryptoService.CreateCrypto(crypto);
            return CreatedAtAction("Get", new { id = createdCrypto.Id }, createdCrypto); //201 + data
        }

        /// <summary>
        /// Update the Crypto
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCrypto([FromBody] Crypto crypto)
        {
            if (await _cryptoService.GetCryptoById(crypto.Id) != null)
            {
                return Ok(await _cryptoService.UpdateCrypto(crypto));//200 + data
            }
            return NotFound();  //If Crypto is null so return "NotFound"
        }

        /// <summary>
        /// Delete the Crypto
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/(id)")]
        public async Task<IActionResult> DeleteCrypto(int id)
        {
            if (await _cryptoService.GetCryptoById(id) != null)
            {
                await _cryptoService.DeletedCrypto(id);
                return Ok();//200
            }
            return NotFound();
        }
    }
}
