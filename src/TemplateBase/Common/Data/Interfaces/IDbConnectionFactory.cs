#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Data;

namespace TemplateBase.Common.Data.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection DbConnection { get; }
    }
}