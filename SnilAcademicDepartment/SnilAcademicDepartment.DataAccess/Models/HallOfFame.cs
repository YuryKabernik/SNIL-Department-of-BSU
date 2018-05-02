namespace SnilAcademicDepartment.DataAccess
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HallOfFame")]
    public partial class HallOfFame
    {
        public int GoodPersonId { get; set; }

        public int PersonId { get; set; }

        public uint Points { get; set; }

        public virtual Person Person { get; set; }
    }
}
