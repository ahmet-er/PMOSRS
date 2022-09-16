using Microsoft.EntityFrameworkCore;
using PMOSRS.Model.Models.Context;
using PMOSRS.Model.Models.Entities;
using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Repository
{
    public class TSRepository : EFRepository<t_TSs, PMOSRSContext>
    {
        public async Task<ResultItem<List<t_TSs>>> AsyncIliskiselListele(Expression<Func<t_TSs, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<List<t_TSs>> m = new ResultItem<List<t_TSs>>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new PMOSRSContext())
                    {
                        var ns = cnt.Set<t_TSs>();

                        if (filtre == null)
                            m.Data = await ns.Include(x => x.Projects).ToListAsync();
                        else
                            m.Data = await ns.Include(x => x.Projects).Where(filtre).ToListAsync();

                        m.Data = m.Data ?? new List<t_TSs>();
                    }

                }
                else
                {

                    using (var cnt = new PMOSRSContext())
                    {
                        var ns = cnt.Set<t_TSs>();

                        if (filtre == null)
                            m.Data = await ns.AsNoTracking().Include(x => x.Projects).ToListAsync();
                        else
                            m.Data = await ns.Include(x => x.Projects).Where(filtre).AsNoTracking().ToListAsync();

                        m.Data = m.Data ?? new List<t_TSs>();
                    }
                }

                m.Message = "Kayıt listelendi.";
                m.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
    }
}
