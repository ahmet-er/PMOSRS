using Microsoft.EntityFrameworkCore;
using PMOSRS.Data.Core.Repository.Interfaces;
using PMOSRS.Model.Enums;
using PMOSRS.Model.Models.Base;
using PMOSRS.Model.Models.Items;
using PMOSRS.Model.Models.Items.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Repository
{
    public class EFRepository<TEntity, TContext> : IEFRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        ILog log = new TextLog();

        public async Task<ResultItem<TEntity>> AsyncDuzelt(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Modified;
                    await cnt.SaveChangesAsync();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt düzeltildi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Düzeltme Hatası ID:{ent.Id}", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncDuzelt_Filtre(TEntity ent, Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                int count = 0;
                if (filtre != null)
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        var res = await ns.Where(filtre).AsNoTracking().ToListAsync();
                        count = res.Count;
                    }
                }

                if (count <= 1)
                {

                    using (var cnt = new TContext())
                    {
                        var addEntity = cnt.Entry(ent);
                        addEntity.State = EntityState.Added;
                        await cnt.SaveChangesAsync();

                        m.Data = addEntity.Entity;
                    }

                    m.IsOk = true; ;
                    m.Message = "Kayıt düzeltildi.";
                }
                else
                {
                    m.Message = "Bu kaydın özelliklerinde bir kayıt var. Bu nedenle kayıt düzeltilemedi.";
                }
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Düzeltme Filtre Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncEkle(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Added;
                    await cnt.SaveChangesAsync();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt eklendi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Ekleme Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncEkle_Filtre(TEntity ent, Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                int count = 0;
                if (filtre != null)
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        var res = await ns.Where(filtre).AsNoTracking().ToListAsync();
                        count = res.Count;
                    }
                }

                if (count <= 1)
                {

                    using (var cnt = new TContext())
                    {
                        var addEntity = cnt.Entry(ent);
                        addEntity.State = EntityState.Added;
                        await cnt.SaveChangesAsync();

                        m.Data = addEntity.Entity;
                    }

                    m.IsOk = true; ;
                    m.Message = "Kayıt eklendi.";
                }
                else
                {
                    m.Message = "Bu kaydın özelliklerinde bir kayıt var. Bu nedenle kayıt eklenemedi.";
                }
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Ekleme Filtre Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncGetir(Expression<Func<TEntity, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        m.Data = await ns.FirstOrDefaultAsync(filtre);

                    }
                }
                else
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        m.Data = await ns.AsNoTracking().FirstOrDefaultAsync(filtre);

                    }
                }

                m.IsOk = true;
                m.Message = "Kayıt görüntülendi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Getirme Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<List<TEntity>>> AsyncListele(Expression<Func<TEntity, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<List<TEntity>> m = new ResultItem<List<TEntity>>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        if (filtre == null)
                            m.Data = await ns.ToListAsync();
                        else
                            m.Data = await ns.Where(filtre).ToListAsync();

                        m.Data = m.Data ?? new List<TEntity>();
                    }

                }
                else
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        if (filtre == null)
                            m.Data = await ns.AsNoTracking().ToListAsync();
                        else
                            m.Data = await ns.Where(filtre).AsNoTracking().ToListAsync();

                        m.Data = m.Data ?? new List<TEntity>();
                    }
                }

                m.Message = "Kayıt listelendi.";
                m.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Listeleme Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<TEntity>> AsyncSil(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                using (var cnt = new TContext())
                {
                    ent.IsDeleted = (int)IsDeletedEnum.Deleted;

                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Modified;
                    await cnt.SaveChangesAsync();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt bilgileri silindi.";
            }
            catch (Exception ex)
            {
                m.IsOk = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

                log.Add($"Kayıt Silme Hatası ID: {ent.Id} ", ex.StackTrace);
            }
            return m;
        }
		// todo: InterFaceye Ekle Eklenmeyenleri -oten

		//public async Task<ResultItem<TEntity>> AsyncGetToken(Expression<Func<TEntity, bool>> filtre = null, bool isTracking = true)
		//{
		//	ResultItem<List<TEntity>> m = new ResultItem<List<TEntity>>();
		//	try
		//	{

		//	}
		//	catch (Exception ex)
		//	{
		//		m.StatusCode = System.Net.HttpStatusCode.Unauthorized;
		//		m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
		//		log.Add(($"JWT Token Oluşturma Hatası"), ex.StackTrace);
		//	}
		//	return m;
		//}

		public async Task<ResultItem<List<TEntity>>> AsyncEkleListe(List<TEntity> ent)
        {
            ResultItem<List<TEntity>> m = new ResultItem<List<TEntity>>();
            try
            {
                using (var cnt = new TContext())
                {
                    await cnt.AddRangeAsync(ent);
                    await cnt.SaveChangesAsync();

                    m.Data = ent;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt Liste eklendi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Liste Ekleme Hatası", ex.StackTrace);
            }
            return m;
        }
        public async Task<ResultItem<List<TEntity>>> AsyncDuzeltListe(List<TEntity> ent)
        {
            ResultItem<List<TEntity>> m = new ResultItem<List<TEntity>>();
            try
            {
                using (var cnt = new TContext())
                {
                    cnt.UpdateRange(ent);
                    await cnt.SaveChangesAsync();

                    m.Data = ent;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt Liste düzeltildi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Liste Düzeltme Hatası", ex.StackTrace);
            }
            return m;
        }


        public ResultItem<TEntity> Duzelt(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Modified;
                    cnt.SaveChanges();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt düzeltildi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Düzeltme Hatası ID:{ent.Id}", ex.StackTrace);
            }
            return m;
        }
        public ResultItem<TEntity> Duzelt_Filtre(TEntity ent, Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                int count = 0;
                if (filtre != null)
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();
                        count = ns.Where(filtre).AsNoTracking().Count();
                    }
                }

                if (count <= 1)
                {

                    using (var cnt = new TContext())
                    {
                        var addEntity = cnt.Entry(ent);
                        addEntity.State = EntityState.Added;
                        cnt.SaveChanges();

                        m.Data = addEntity.Entity;
                    }

                    m.IsOk = true; ;
                    m.Message = "Kayıt düzeltildi.";
                }
                else
                {
                    m.Message = "Bu kaydın özelliklerinde bir kayıt var. Bu nedenle kayıt düzeltilemedi.";
                }
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Düzeltme Filtre Hatası", ex.StackTrace);
            }
            return m;
        }

        public ResultItem<TEntity> Ekle(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Added;
                    cnt.SaveChanges();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt eklendi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Ekleme Hatası", ex.StackTrace);
            }
            return m;
        }

        public ResultItem<TEntity> Ekle_Filtre(TEntity ent, Expression<Func<TEntity, bool>> filtre = null)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();
            try
            {
                int count = 0;
                if (filtre != null)
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();
                        count = ns.Where(filtre).AsNoTracking().Count();
                    }
                }

                if (count <= 1)
                {

                    using (var cnt = new TContext())
                    {
                        var addEntity = cnt.Entry(ent);
                        addEntity.State = EntityState.Added;
                        cnt.SaveChanges();

                        m.Data = addEntity.Entity;
                    }

                    m.IsOk = true; ;
                    m.Message = "Kayıt eklendi.";
                }
                else
                {
                    m.Message = "Bu kaydın özelliklerinde bir kayıt var. Bu nedenle kayıt eklenemedi.";
                }
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Ekleme Filtre Hatası", ex.StackTrace);
            }
            return m;
        }

        public ResultItem<TEntity> Getir(Expression<Func<TEntity, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        m.Data = ns.FirstOrDefault(filtre);

                    }
                }
                else
                {
                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        m.Data = ns.AsNoTracking().FirstOrDefault(filtre);

                    }
                }

                m.IsOk = true;
                m.Message = "Kayıt görüntülendi.";

            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Getirme Hatası", ex.StackTrace);
            }
            return m;
        }

        public ResultItem<List<TEntity>> Listele(Expression<Func<TEntity, bool>> filtre = null, bool isTracking = true)
        {
            ResultItem<List<TEntity>> m = new ResultItem<List<TEntity>>();

            try
            {
                if (isTracking)
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        if (filtre == null)
                            m.Data = ns.ToList();
                        else
                            m.Data = ns.Where(filtre).ToList();

                        m.Data = m.Data ?? new List<TEntity>();
                    }

                }
                else
                {

                    using (var cnt = new TContext())
                    {
                        var ns = cnt.Set<TEntity>();

                        if (filtre == null)
                            m.Data = ns.AsNoTracking().ToList();
                        else
                            m.Data = ns.Where(filtre).AsNoTracking().ToList();

                        m.Data = m.Data ?? new List<TEntity>();
                    }
                }

                m.Message = "Kayıt listelendi.";
                m.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                m.StatusCode = System.Net.HttpStatusCode.NoContent;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
                log.Add($"Kayıt Listeleme Hatası", ex.StackTrace);
            }
            return m;
        }

        public ResultItem<TEntity> Sil(TEntity ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                using (var cnt = new TContext())
                {
                    ent.IsDeleted = (int)IsDeletedEnum.Deleted;

                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Modified;
                    cnt.SaveChanges();

                    m.Data = addEntity.Entity;
                }

                m.IsOk = true; ;
                m.Message = "Kayıt bilgileri silindi.";
            }
            catch (Exception ex)
            {
                m.IsOk = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

                log.Add($"Kayıt Silme Hatası ID: {ent.Id} ", ex.StackTrace);
            }
            return m;
        }

        public async Task<ResultItem<TEntity>> HardDelete(List<TEntity> ent)
        {
            ResultItem<TEntity> m = new ResultItem<TEntity>();

            try
            {
                using (var cnt = new TContext())
                {
                    cnt.RemoveRange(ent);
                    await cnt.SaveChangesAsync();

                }

                m.IsOk = true; ;
                m.Message = "Kayıt bilgileri silindi.";
            }
            catch (Exception ex)
            {
                m.IsOk = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

                log.Add($"Kayıt Silme Hatası ", ex.StackTrace);
            }
            return m;
        }


    }
}
