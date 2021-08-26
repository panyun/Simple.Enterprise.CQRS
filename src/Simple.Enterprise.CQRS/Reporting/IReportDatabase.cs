using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Enterprise.CQRS.Reporting
{
    public interface IReportDatabase<T>
    {
        T GetById(Guid id);
        void Add(T item);
        void Delete(Guid id);
        List<T> GetItems();
    }
}
