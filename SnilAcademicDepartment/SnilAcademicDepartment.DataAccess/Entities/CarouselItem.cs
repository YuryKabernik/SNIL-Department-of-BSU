using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Entity of the home page preroles.
    /// </summary>
    public class CarouselItem
    {
        public Image Picture { get; set; }
        public string Header { get; set; }
        public string ShortDiscription { get; set; }
    }
}
