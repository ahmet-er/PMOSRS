using PMOSRS.Data.Core.Business.Base;
using PMOSRS.Data.Core.Repository;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business
{
    public class FileBusiness : BaseBusiness<t_Files>
    {
        private FileRepository _fileRepository;

        public FileBusiness(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public override async Task<ResultItem<t_Files>> Add(t_Files T)
        {
            return await _fileRepository.AsyncEkle(T);
        }

        public override async Task<ResultItem<t_Files>> Delete(Guid guid)
        {
            var res = await _fileRepository.AsyncGetir(x => x.Id == guid);
            if (res.Data != null)
            {
                return await _fileRepository.AsyncSil(res.Data);
            }
            else
            {
                return res;
            }
        }

        public override async Task<ResultItem<List<t_Files>>> List()
        {
            return await _fileRepository.AsyncListele();
        }

        public override async Task<ResultItem<t_Files>> Update(t_Files T)
        {
            var res = await _fileRepository.AsyncGetir(x => x.Id == T.Id);
            if(res.Data != null)
            {
                res.Data = T;
                return await _fileRepository.AsyncDuzelt(res.Data);
            }
            else
            {
                return res;
            }
        }
    }
}
