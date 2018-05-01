using System;
using System.Runtime.Serialization;

namespace SnilAcademicDepartment.Common.CustomExceptions
{
    [Serializable]
    public class PreviewTypeNotFoundException : Exception
    {
        public PreviewTypeNotFoundException() : base()
        {

        }

        public PreviewTypeNotFoundException(string message) : base(message)
        {

        }

        public PreviewTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public PreviewTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
