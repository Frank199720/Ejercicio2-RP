
using RP.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Interfaces.Managment
{
    public interface IDataShapeHelper<T>
    {
        ShapedEntityDTO ShapeData(T entity, string? fieldsString = null);
        IEnumerable<ShapedEntityDTO> ShapeData(IEnumerable<T> entities, string? fieldsString = null);
        Task<IEnumerable<ShapedEntityDTO>> ShapeDataAsync(IEnumerable<T> entities, string? fieldsString = null);
    }
}
