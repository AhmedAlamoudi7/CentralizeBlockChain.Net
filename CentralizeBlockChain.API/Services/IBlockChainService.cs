using CentralizeBlockChain.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizeBlockChain.API.Services
{
    public interface IBlockChainService
    {
        Task<List<Record>> GetAll();
        Task<int> Create(Record model);
    }
}
