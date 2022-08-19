using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class SettingBusiness : BaseBusiness<t_Settings>
    {
        private readonly SettingRepository _settingRepository;

        public SettingBusiness(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public override async Task<ResultItem<t_Settings>> Add(t_Settings T)
        {
            return await _settingRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Settings>> Delete(Guid guid)
        {
            var res = await _settingRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _settingRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Settings>>> Select()
        {
            return await _settingRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Settings>> Update(t_Settings T)
        {
            var res = await _settingRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _settingRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
