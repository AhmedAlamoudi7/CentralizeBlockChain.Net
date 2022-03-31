using CentralizeBlockChain.API.Models;
using CentralizeBlockChain.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CentralizeBlockChain.API.Controllers
{
    public class BlockChainController : BaseController
    {
        private readonly IBlockChainService _IBlockChainService;

        public BlockChainController(IBlockChainService iBlockChainService)
        {
            _IBlockChainService = iBlockChainService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRecordsAsync()
        {
            var records = await _IBlockChainService.GetAll();
            return Ok(records);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecordsAsync(Record model)
        {
            await _IBlockChainService.Create(model);
            return Ok("Done");
        }
    }
}
