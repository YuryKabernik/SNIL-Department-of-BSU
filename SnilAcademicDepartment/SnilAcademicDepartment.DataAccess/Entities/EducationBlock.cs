using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Entity of the education block.
    /// </summary>
    public class EducationBlock
    {
        public Image Picture { get; set; }
        public string ShortDiscription { get; set; }
        public ICollection<string> Theses { get; set; }
    }
}
