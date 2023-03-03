using System.Data;

namespace Domain.Repositories
{
    public interface ILaudoRepository : IRepository<Entities.Laudo, Filters.LaudoFilter>
    {
        DataTable ListDataTable(Filters.LaudoFilter filter);
    }
}
