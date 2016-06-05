using System;
using System.Runtime.Serialization;

namespace itechart.smg.api.csharp.Model.Parameters
{
    [DataContract]
    public class GetEmployeeDetailsUpdatedParameters : GetEmployeeDetailsParameters
    {
        [DataMember(Name = "updatedDate", EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        public GetEmployeeDetailsUpdatedParameters(int sessionId) : base(sessionId)
        {
        }
    }
}