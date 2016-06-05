using System.Runtime.Serialization;
using itechart.smg.api.csharp.SmgMobileService;

namespace itechart.smg.api.csharp.Model.Result
{
    [DataContract]
    public class GetEmployeeDetailsResult : BaseApiResult<GetEmployeeDetailsOutput>
    {
        [DataMember(Name = "Profile", EmitDefaultValue = false)]
        public EmployeeFullResult Profile { get; set; }

        public override void InitializeFromOutput(GetEmployeeDetailsOutput output)
        {
            base.InitializeFromOutput(output);

            if (output.Profile != null)
            {
                var employee = new EmployeeFullResult();
                employee.InitializeFromOutput(output.Profile);
                Profile = employee;
            }
        }
    }
}