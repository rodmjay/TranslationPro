#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

namespace TemplateBase.Common.Models
{
    public class PagingQuery
    {
        public string Sort { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}