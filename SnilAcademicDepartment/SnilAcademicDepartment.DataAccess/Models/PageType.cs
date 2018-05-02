using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnilAcademicDepartment.DataAccess
{
    [Table("PageType")]
    public partial class PageType
    {
        public int PageTypeId { get; set; }

        public string PageTypeName { get; set; }

        public virtual ICollection<PreView> PreViews { get; set; } = new HashSet<PreView>();
    }
}
