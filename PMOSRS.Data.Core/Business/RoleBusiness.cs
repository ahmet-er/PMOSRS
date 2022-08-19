using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class RoleBusiness : BaseBusiness<t_Roles>
    {
        private RoleRepository _roleRepository;

        public RoleBusiness(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public override async Task<ResultItem<t_Roles>> Add(t_Roles T)
        {
            return await _roleRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Roles>> Delete(Guid guid)
        {
            var res = await _roleRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _roleRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Roles>>> Select()
        {
            return await _roleRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Roles>> Update(t_Roles T)
        {
            var res = await _roleRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _roleRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
