using System.Runtime.Serialization;

namespace DOTNET_ASSIGNMENT_1.Repository
{
    [Serializable]
    internal class ConflictExcetion : Exception
    {
        public ConflictExcetion()
        {
        }

        public ConflictExcetion(string? message) : base(message)
        {

        }

        public ConflictExcetion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ConflictExcetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}