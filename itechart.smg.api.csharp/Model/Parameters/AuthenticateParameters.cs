using System.Runtime.Serialization;
using itechart.smg.api.csharp.SmgMobileService;

namespace itechart.smg.api.csharp.Model.Parameters
{
    [DataContract]
    public class AuthenticateParameters : IBaseApiParameters<PostAuthenticateInput>
    {
        [DataMember(Name = "username", EmitDefaultValue = false)]
        public string UserName { get; set; }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        public PostAuthenticateInput ToInput()
        {
            return new PostAuthenticateInput
            {
                Password = Password,
                Username = UserName
            };
        }
    }
}