using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class SRSBusiness : BaseBusiness<t_SRSs>
    {
        private SRSRepository _sRSRepository;

        public SRSBusiness(SRSRepository sRSRepository)
        {
            _sRSRepository = sRSRepository;
        }

        public override async Task<ResultItem<t_SRSs>> Add(t_SRSs T)
        {
            return await _sRSRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_SRSs>> Delete(Guid guid)
        {
            var res = await _sRSRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _sRSRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_SRSs>>> Select()
        {
            return await _sRSRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_SRSs>> Update(t_SRSs T)
        {
            var res = await _sRSRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _sRSRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
