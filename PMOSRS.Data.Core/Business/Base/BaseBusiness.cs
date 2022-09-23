using PMOSRS.Model.Models.Base;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Business.Base
{
    public abstract class BaseBusiness<TEntity> 
        where TEntity : BaseEntity, new()
    {
        public abstract Task<ResultItem<TEntity>> Add(TEntity T);
        public abstract Task<ResultItem<TEntity>> Update(TEntity T);
        public abstract Task<ResultItem<TEntity>> Delete(Guid guid);
        public abstract Task<ResultItem<List<TEntity>>> List();
    }
}
