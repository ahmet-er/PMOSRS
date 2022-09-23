using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class RoleUserMapBusiness : BaseBusiness<t_RoleUserMaps>
    {
        private readonly RoleUserMapRepository _roleUserMapRepository;

        public RoleUserMapBusiness(RoleUserMapRepository roleUserMapRepository)
        {
            _roleUserMapRepository = roleUserMapRepository;
        }

        public override async Task<ResultItem<t_RoleUserMaps>> Add(t_RoleUserMaps T)
        {
            return await _roleUserMapRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_RoleUserMaps>> Delete(Guid guid)
        {
            var res = await _roleUserMapRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _roleUserMapRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_RoleUserMaps>>> List()
        {
            return await _roleUserMapRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_RoleUserMaps>> Update(t_RoleUserMaps T)
        {
            var res = await _roleUserMapRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _roleUserMapRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
