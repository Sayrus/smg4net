using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using itechart.smg.api.csharp.Model.Parameters;
using itechart.smg.api.csharp.Model.Result;
using itechart.smg.api.csharp.SmgMobileService;

namespace itechart.smg.api.csharp.Proxy
{
    public class SmgMobileServiceProxy
    {
        #region constants

        public const string AuthenticateUrl = "/Authenticate";
        public const string PostAuthenticateUrl = "/PostAuthenticate";
        public const string GetAllDepartmentsUrl = "/GetAllDepartments";
        public const string GetAllDepartmentsUpdatedUrl = "/GetAllDepartmentsUpdated";
        public const string GetAllEmployeesUrl = "/GetAllEmployees";
        public const string GetEmployeesByDeptIdUrl = "/GetEmployeesByDeptId";
        public const string GetEmployeesByDeptIdUpdatedUrl = "/GetEmployeesByDeptIdUpdated";
        public const string GetEmployeeDetailsUrl = "/GetEmployeeDetails";
        public const string GetEmployeeDetailsUpdatedUrl = "/GetEmployeeDetailsUpdated";
        public const string GetEmployeeShortInfoUrl = "/GetEmployeeShortInfo";
        public const string GetEmployeeDetailsListByDeptIdUrl = "/GetEmployeeDetailsListByDeptId";

        public const string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

        #endregion

        #region members

        private const string ServiceUrlConfigKey = "SmgServiceUrl";
        private readonly Uri serviceUri;

        public SmgMobileServiceProxy()
        {
            var serviceUrlFromConfig = ConfigurationManager.AppSettings[ServiceUrlConfigKey];
            if (!String.IsNullOrEmpty(serviceUrlFromConfig))
            {
                serviceUri = new Uri(serviceUrlFromConfig);
            }
            else
            {
                throw new SettingsPropertyNotFoundException("SmgServiceUrl not found!");
            }
        }

        #endregion

        #region api implementation members

        public async Task<AuthenticateResult> Authenticate(AuthenticateParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"username", parameters.UserName},
                {"password", parameters.Password}
            };

            return
                await
                    ExecuteRequestAsync<AuthenticateResult, AuthenticateOutput>(AuthenticateUrl, HttpMethod.Get,
                        paramsDictionary);
        }

        public Task<AuthenticateResult> PostAuthenticate(AuthenticateParameters parameters)
        {
            //TODO: something wrong with PostAuthenticate on the server-side
            //The exception message is 'Object reference not set to an instance of an object.'
            throw new NotImplementedException();
        }

        public async Task<GetAllDepartmentsResult> GetAllDepartments(GetAllDeparmentsParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId}
            };

            return
                await
                    ExecuteRequestAsync<GetAllDepartmentsResult, GetAllDepartmentsOutput>(GetAllDepartmentsUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetAllDepartmentsResult> GetAllDepartmentsUpdated(GetAllDeparmentsUpdatedParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"updatedDate", parameters.UpdatedDate.ToString("O")}
            };

            return
                await
                    ExecuteRequestAsync<GetAllDepartmentsResult, GetAllDepartmentsOutput>(GetAllDepartmentsUpdatedUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetAllEmployeesResult> GetAllEmployees(GetAllEmployeesParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId}
            };

            return
                await
                    ExecuteRequestAsync<GetAllEmployeesResult, GetEmployeesListOutput>(GetAllEmployeesUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeesByDeptIdResult> GetEmployeesByDeptId(GetEmployeesByDeptIdParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"departmentId", parameters.DepartmentId.ToString()}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeesByDeptIdResult, GetEmployeesListOutput>(GetEmployeesByDeptIdUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeesByDeptIdUpdatedResult> GetEmployeesByDeptIdUpdated(
            GetEmployeesByDeptIdUpdatedParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"updatedDate", parameters.UpdatedDate.ToString("O")},
                {"initialRequest", parameters.OnlyActive.ToString()},
                {"departmentId", parameters.DepartmentId.ToString()}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeesByDeptIdUpdatedResult, GetEmployeesListOutput>(
                        GetEmployeesByDeptIdUpdatedUrl, HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeeDetailsResult> GetEmployeeDetails(GetEmployeeDetailsParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"profileId", parameters.ProfileId.ToString()}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeeDetailsResult, GetEmployeeDetailsOutput>(GetEmployeeDetailsUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeeDetailsUpdatedResult> GetEmployeeDetailsUpdated(
            GetEmployeeDetailsUpdatedParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"profileId", parameters.ProfileId.ToString()},
                {"updatedDate", parameters.UpdatedDate.ToString("O")}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeeDetailsUpdatedResult, GetEmployeeDetailsOutput>(
                        GetEmployeeDetailsUpdatedUrl, HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeesShortInfoResult> GetEmployeesShortInfo(GetEmployeesShortInfoParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"updatedDate", parameters.UpdatedDate.ToString("O")},
                {"initialRequest", parameters.OnlyActive.ToString()}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeesShortInfoResult, GetEmployeeShortOutput>(GetEmployeeShortInfoUrl,
                        HttpMethod.Get, paramsDictionary);
        }

        public async Task<GetEmployeeDetailsListByDeptIdResult> GetEmployeeDetailsListByDeptId(
            GetEmployeeDetailsListByDeptIdParameters parameters)
        {
            var paramsDictionary = new Dictionary<string, string>
            {
                {"sessionId", parameters.SessionId},
                {"departmentId", parameters.DepartmentId.ToString()}
            };

            return
                await
                    ExecuteRequestAsync<GetEmployeeDetailsListByDeptIdResult, GetEmployeeDetailsListOutput>(
                        GetEmployeeDetailsListByDeptIdUrl, HttpMethod.Get, paramsDictionary);
        }

        #endregion

        #region helpers

        private static string ParametersToString(Dictionary<string, string> postParameters)
        {
            var postData = postParameters.Keys.Select(key => String.Join("=", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(postParameters[key])));

            return String.Join("&", postData);
        }

        private async Task<TModel> ExecuteRequestAsync<TModel, TOutput>(string relativeUrl, HttpMethod method = null,
            Dictionary<string, string> parameters = null)
            where TModel : class, IBaseApiResult<TOutput>, new()
            where TOutput : BaseResponse
        {
            if (method == null)
            {
                method = HttpMethod.Get;
            }

            var url = new Uri(serviceUri.AbsoluteUri + relativeUrl);

            HttpWebRequest httpRequest;

            var parametersString = String.Empty;
            if (parameters != null && parameters.Count > 0)
            {
                parametersString = ParametersToString(parameters);
            }

            if (method == HttpMethod.Post)
            {
                httpRequest = WebRequest.CreateHttp(url);

                if (!string.IsNullOrEmpty(parametersString))
                {
                    var data = Encoding.ASCII.GetBytes(parametersString);

                    httpRequest.ContentType = "application/x-www-form-urlencoded";
                    httpRequest.ContentLength = data.Length;
                    httpRequest.UserAgent = UserAgent;

                    using (var requestStream = httpRequest.GetRequestStream())
                    {
                        await requestStream.WriteAsync(data, 0, data.Length);
                        requestStream.Flush();
                        requestStream.Close();
                    }
                }
            }
            else
            {
                //TODO: add params to Uri
                httpRequest = WebRequest.CreateHttp(url.AbsoluteUri + "?" + parametersString);
            }

            httpRequest.Method = method.Method;

            using (var response = await httpRequest.GetResponseAsync())
            {
                var responseStream = response.GetResponseStream();
                if (responseStream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(responseStream))
                {
                    var jsSerializer = new JavaScriptSerializer();
                    var resultObject = reader.ReadToEnd();

                    var outputObject = jsSerializer.Deserialize(resultObject, typeof(TOutput)) as TOutput;

                    var result = new TModel();
                    result.InitializeFromOutput(outputObject);

                    var baseApiResult = result as BaseApiResult<TOutput>;
                    if (baseApiResult != null)
                    {
                        ValidateErrorCode(baseApiResult);
                    }

                    return result;
                }
            }
        }

        private void ValidateErrorCode<TOutput>(BaseApiResult<TOutput> baseApiResult) where TOutput : BaseResponse
        {
            baseApiResult.ErrorCode.Validate();
        }

        #endregion
    }
}