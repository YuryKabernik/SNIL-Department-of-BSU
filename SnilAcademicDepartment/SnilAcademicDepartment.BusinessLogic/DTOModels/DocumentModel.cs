using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte[] Content { get; set; }
    }
}
