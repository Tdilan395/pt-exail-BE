using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;

namespace tienda.Domain.Repositories
{
    public  interface IProductosRepository
    {
        Task AddAsync(Producto producto);
        Task DeleteAsync(int id);
        Task<Producto> Get(int id);
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<IEnumerable> getProductosAsync(List<int> list);
        Task UpdateAsync(Producto producto);
    }
}
