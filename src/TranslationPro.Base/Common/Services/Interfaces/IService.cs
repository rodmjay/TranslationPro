#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using AutoMapper;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Common.Services.Interfaces;

public interface IService<TEntity> where TEntity : class, IObjectState
{
    public MapperConfiguration ProjectionMapping { get; }
    public IRepositoryAsync<TEntity> Repository { get; }
}