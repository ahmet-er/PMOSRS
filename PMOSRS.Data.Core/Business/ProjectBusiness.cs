using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class ProjectBusiness : BaseBusiness<t_Projects>
    {
        private readonly ProjectRepository _projectRepository;
        public ProjectBusiness(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public override async Task<ResultItem<t_Projects>> Add(t_Projects T)
        {
            return await _projectRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Projects>> Delete(Guid guid)
        {
            var res = await _projectRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _projectRepository.AsyncSil(res.Data);
            }
                
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Projects>>> Select()
        {
            return await _projectRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Projects>> Update(t_Projects T)
        {
            var res = await _projectRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _projectRepository.AsyncSil(res.Data);
            }

            else
            {
                return res;
            }
        }
    }
}
