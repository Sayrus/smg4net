using System.Runtime.Serialization;

namespace itechart.smg.api.csharp.Model.Parameters
{
    [DataContract]
    public class GetAllEmployeesParameters : BaseSmgParameters
    {
        public GetAllEmployeesParameters(int sessionId) : base(sessionId)
        {
        }

        protected GetAllEmployeesParameters()
        {
        }
    }
}