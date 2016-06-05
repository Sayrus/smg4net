using System;
using System.Runtime.Serialization;

namespace itechart.smg.api.csharp.Model.Parameters
{
    [DataContract]
    public class GetAllDeparmentsUpdatedParameters : GetAllDeparmentsParameters
    {
        [DataMember(Name = "updatedDate", EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        public GetAllDeparmentsUpdatedParameters(int sessionId) : base(sessionId)
        {
        }

        public GetAllDeparmentsUpdatedParameters()
        {
        }
    }
}