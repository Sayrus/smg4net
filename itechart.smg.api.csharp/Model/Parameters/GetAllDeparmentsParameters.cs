using System.Runtime.Serialization;

namespace itechart.smg.api.csharp.Model.Parameters
{
    [DataContract]
    public class GetAllDeparmentsParameters : BaseSmgParameters
    {
        public GetAllDeparmentsParameters(int sessionId) : base(sessionId)
        {
        }

        public GetAllDeparmentsParameters()
        {
        }
    }
}