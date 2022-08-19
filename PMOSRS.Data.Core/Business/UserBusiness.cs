using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class UserBusiness : BaseBusiness<t_Users>
    {
        private readonly UserRepository _userRepository;

        public UserBusiness(UserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public override async Task<ResultItem<t_Users>> Add(t_Users T)
        {
            return await _userRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Users>> Delete(Guid guid)
        {
            var res = await _userRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _userRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Users>>> Select()
        {
            return await _userRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Users>> Update(t_Users T)
        {
            var res = await _userRepository.AsyncGetir(x => x.Id == T.Id);
            if (res.Data != null)
            {
                res.Data = T;
                return await _userRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
