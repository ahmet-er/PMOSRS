using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class TSBusiness : BaseBusiness<t_TSs>
    {
        private readonly TSRepository _tSRepository;

        public TSBusiness(TSRepository tSRepository)
        {
            _tSRepository = tSRepository;
        }

        public override async Task<ResultItem<t_TSs>> Add(t_TSs T)
        {
            return await _tSRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_TSs>> Delete(Guid guid)
        {
            var res = await _tSRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _tSRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_TSs>>> Select()
        {
            return await _tSRepository.AsyncListele();
        }

        public async Task<ResultItem<List<t_TSs>>> IliskiliSelect()
        {
            return await _tSRepository.AsyncIliskiselListele();
        }

        public override async Task<ResultItem<t_TSs>> Update(t_TSs T)
        {
            var res = await _tSRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _tSRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
