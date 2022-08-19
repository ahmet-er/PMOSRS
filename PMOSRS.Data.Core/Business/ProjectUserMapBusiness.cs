using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class ProjectUserMapBusiness : BaseBusiness<t_ProjectUserMaps>
    {
        private readonly ProjectUserMapRepository _projectUserMapRepository;

        public ProjectUserMapBusiness(ProjectUserMapRepository projectUserMapRepository)
        {
            _projectUserMapRepository = projectUserMapRepository;
        }

        public override async Task<ResultItem<t_ProjectUserMaps>> Add(t_ProjectUserMaps T)
        {
            return await _projectUserMapRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_ProjectUserMaps>> Delete(Guid guid)
        {
            var res = await _projectUserMapRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _projectUserMapRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_ProjectUserMaps>>> Select()
        {
            return await _projectUserMapRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_ProjectUserMaps>> Update(t_ProjectUserMaps T)
        {
            var res = await _projectUserMapRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _projectUserMapRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
