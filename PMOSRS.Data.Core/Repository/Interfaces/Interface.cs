using PMOSRS.Model.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PMOSRS.Data.Core.Repository.Interfaces
{
    public interface IEFRepository<T> where T : class, new()
    {
        ResultItem<T> Getir(Expression<Func<T, bool>> filtre = null, bool isTracking = true);
        ResultItem<List<T>> Listele(Expression<Func<T, bool>> filtre = null, bool isTracking = true);
        ResultItem<T> Ekle(T ent);
        ResultItem<T> Ekle_Filtre(T ent, Expression<Func<T, bool>> filtre = null);
        ResultItem<T> Duzelt_Filtre(T ent, Expression<Func<T, bool>> filtre = null);
        ResultItem<T> Duzelt(T ent);
        ResultItem<T> Sil(T ent);

        #region Async Methodlar
        Task<ResultItem<T>> AsyncGetir(Expression<Func<T, bool>> filtre = null, bool isTracking = true);
        Task<ResultItem<List<T>>> AsyncListele(Expression<Func<T, bool>> filtre = null, bool isTracking = true);
        Task<ResultItem<T>> AsyncEkle(T ent);
        Task<ResultItem<T>> AsyncEkle_Filtre(T ent, Expression<Func<T, bool>> filtre = null);
        Task<ResultItem<T>> AsyncDuzelt(T ent);
        Task<ResultItem<T>> AsyncDuzelt_Filtre(T ent, Expression<Func<T, bool>> filtre = null);
        Task<ResultItem<T>> AsyncSil(T ent);

        #endregion
    }
}

