using CentralizeBlockChain.API.Data;
using CentralizeBlockChain.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralizeBlockChain.API.Services
{
    public class BlockChainService : IBlockChainService
    {
        private readonly ApplicationDbContext _db;

        public BlockChainService(ApplicationDbContext db)
        {

            _db = db;
        }



        public async Task<List<Record>> GetAll()
        {
            var Records = await _db.Records.ToListAsync();
            return Records;
        }




        public async Task<int> Create(Record model)
        {
            var record = new Record();
            //record.ContractType = model.BlockNumer;
            record.Timestamp = model.Timestamp;
            record.pervious_hash = model.pervious_hash;
            record.proof = model.proof;
            await _db.Records.AddAsync(record);
            await _db.SaveChangesAsync();
            return record.BlockNumer;
        }



        //public async Task<UpdateBuyContractDto> Get(int Id)
        //{
        //    var buycontract = await _db.BuyContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
        //    if (buycontract == null)
        //    {
        //        throw new EntityNotFoundException();
        //    }
        //    return _mapper.Map<UpdateBuyContractDto>(buycontract);
        //}










    }
}
