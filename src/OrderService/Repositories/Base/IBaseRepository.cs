using System.Data.Common;

namespace OrderService.Repositories.Base
{
    public interface IBaseRepository<TObj, TKey>
    {
        Task<TKey> InsertAsync(TObj obj);
        Task<TKey> InsertAsync(TObj obj, DbTransaction dbTransaction);
        Task<bool> UpdateAsync(TObj obj);
        bool Upsert(TObj obj);
        bool HardDelete(TObj obj);
        bool HardDelete(object columnCriteria);
        Task<bool> DeleteAsync(TKey id);
        bool DeleteByColumnName(object columns);
        Task<bool> DeleteModifiedAsync(TObj obj);
        bool DeleteByColumnCriteria(TObj obj, object columns);
        bool Restore(TKey id);
        bool RestoreModified(TObj obj);
        IEnumerable<TObj> GetAll();
        IEnumerable<TObj> GetAllByColumns(object columns);
        TKey GetCount();
        TKey GetCountByColumns(object columns);
        TObj GetById(TKey id);
        TObj GetByColumns(object columns);
        bool IsExists(TKey id);
        bool IsExists(object whereColumns, TKey idNotEqualTo = default(TKey));
        IEnumerable<TObj> GetDistinctColumnByName(string columnName);
        IEnumerable<TObj> GetDistinctColumnByName(string columns, object whereClause);
    }
}
