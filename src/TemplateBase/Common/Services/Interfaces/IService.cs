#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using AutoMapper;
using TemplateBase.Common.Data.Interfaces;

namespace TemplateBase.Common.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class, IObjectState
    {
        public MapperConfiguration ProjectionMapping { get; }
        public IRepositoryAsync<TEntity> Repository { get; }
    }
}