using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class AuthorityBusiness : BaseBusiness<t_Authorities>
    {
        private readonly AuthorityRepository _authorityRepository;

        public AuthorityBusiness(AuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
        }
        public override async Task<ResultItem<t_Authorities>> Add(t_Authorities T)
        {
            return await _authorityRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Authorities>> Delete(Guid guid)
        {
            var res = await _authorityRepository.AsyncGetir(x => x.Id == guid);
            if(res.Data != null)
            {
                return await _authorityRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Authorities>>> List()
        {
            return await _authorityRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Authorities>> Update(t_Authorities T)
        {
            var res = await _authorityRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _authorityRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
