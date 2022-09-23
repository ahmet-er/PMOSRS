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
    public class SRSRepository : EFRepository<t_SRSs, PMOSRSContext>
    {
        public async Task<ResultItem<List<t_SRSs>>> AsyncIliskiselListele(Expression<Func<t_SRSs, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<List<t_SRSs>> m = new ResultItem<List<t_SRSs>>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new PMOSRSContext())
                    {
                        var ns = cnt.Set<t_SRSs>();

                        if (filtre == null)
                        {
                            m.Data = await ns.Include(x => x.TID).ToListAsync();
                            m.Data = await ns.Include(x => x.SRSState).ToListAsync();
                        }
                        else
                        {
                            m.Data = await ns.Include(x => x.TID).Where(filtre).ToListAsync();
                            m.Data = await ns.Include(x => x.SRSState).Where(filtre).ToListAsync();
                        }

                        m.Data = m.Data ?? new List<t_SRSs>();
                    }

                }
                else
                {

                    using (var cnt = new PMOSRSContext())
                    {
                        var ns = cnt.Set<t_SRSs>();

                        if (filtre == null)
                        {
                            m.Data = await ns.AsNoTracking().Include(x => x.TID).ToListAsync();
                            m.Data = await ns.AsNoTracking().Include(x => x.SRSState).ToListAsync();
                        }
                        else
                        {
                            m.Data = await ns.Include(x => x.TID).Where(filtre).AsNoTracking().ToListAsync();
                            m.Data = await ns.Include(x => x.SRSState).Where(filtre).AsNoTracking().ToListAsync();
                        }

                        m.Data = m.Data ?? new List<t_SRSs>();
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
