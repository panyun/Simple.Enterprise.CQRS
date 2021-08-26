using Simple.Enterprise.CQRS.Domain.Imp;

namespace Simple.Enterprise.CQRS.Reporting.Imp
{
    public class ReportDatabase<T> : IReportDatabase<T> where T : PrimeKey<Guid>
    {
        static List<T> items = new List<T>();

        public T GetById(Guid id)
        {
            return items.FirstOrDefault(a => a.Id == id);
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Delete(Guid id)
        {
            items.RemoveAll(i => i.Id == id);
        }

        public List<T> GetItems()
        {
            return items;
        }
    }
}
