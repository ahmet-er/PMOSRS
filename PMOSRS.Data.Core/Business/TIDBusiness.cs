using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class TIDBusiness : BaseBusiness<t_TIDs>
    {
        private readonly TIDRepository _tIDRepository;

        public TIDBusiness(TIDRepository tIDRepository)
        {
            _tIDRepository = tIDRepository;
        }

        public override async Task<ResultItem<t_TIDs>> Add(t_TIDs T)
        {
            return await _tIDRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_TIDs>> Delete(Guid guid)
        {
            var res = await _tIDRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _tIDRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_TIDs>>> List()
        {
            return await _tIDRepository.AsyncListele();
        }

        public async Task<ResultItem<List<t_TIDs>>> IliskiliList()
        {
            return await _tIDRepository.AsyncIliskiselListele();
        }

        public override async Task<ResultItem<t_TIDs>> Update(t_TIDs T)
        {
            var res = await _tIDRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _tIDRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
