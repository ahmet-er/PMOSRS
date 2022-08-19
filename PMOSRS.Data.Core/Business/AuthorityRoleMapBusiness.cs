using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class AuthorityRoleMapBusiness : BaseBusiness<t_AuthorityRoleMaps>
    {
        private AuthorityRoleMapRepository _authorityRoleMapRepository;
        public AuthorityRoleMapBusiness(AuthorityRoleMapRepository authorityRoleMapRepository)
        {
            _authorityRoleMapRepository = authorityRoleMapRepository;
        }

        public override async Task<ResultItem<t_AuthorityRoleMaps>> Add(t_AuthorityRoleMaps T)
        {
            return await _authorityRoleMapRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_AuthorityRoleMaps>> Delete(Guid guid)
        {
            var res = await _authorityRoleMapRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _authorityRoleMapRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_AuthorityRoleMaps>>> Select()
        {
            return await _authorityRoleMapRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_AuthorityRoleMaps>> Update(t_AuthorityRoleMaps T)
        {
            var res = await _authorityRoleMapRepository.AsyncGetir(x => x.Id == T.Id);
            if(res.Data != null)
            {
                res.Data = T;
                return await _authorityRoleMapRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
