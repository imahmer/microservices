using System.Net;

namespace OrderService.Models.Common
{
    public class BaseAPIResponse
    {
        const string NotFound_RESULT_CODE = "404";
        const string NotFound__RESULT = "Not Found";

        const string Create_RESULT_CODE = "201";
        const string Create_RESULT = "Create";

        const string SUCCESS_RESULT_CODE = "200";
        const string SUCCESS_RESULT = "Success";

        const string FAULT_RESULT_CODE = "192";
        const string FAULT_RESULT = "Failed";


        public Response SuccessResponse()
        {
            return new Response
            {
                Result = SUCCESS_RESULT,
                StatusCode = HttpStatusCode.OK,
                ResultCode = SUCCESS_RESULT_CODE,
                ResultText = "Successful",
                AdditionalData = null
            };
        }

        public Response SuccessResponse(object entity)
        {
            return new Response
            {
                Result = SUCCESS_RESULT,
                StatusCode = HttpStatusCode.OK,
                ResultCode = SUCCESS_RESULT_CODE,
                ResultText = "Successful",
                AdditionalData = null,
                Data = entity
            };
        }

        public Response SuccessResponse(long id = 0, string resultText = "Successful", Dictionary<string, string> additionalData = null)
        {
            return new Response
            {
                Id = id,
                Result = SUCCESS_RESULT,
                StatusCode = HttpStatusCode.OK,
                ResultCode = SUCCESS_RESULT_CODE,
                ResultText = resultText,
                AdditionalData = additionalData
            };
        }
        public Response FaultResponse(string resultText = "Failed", Dictionary<string, IEnumerable<string>> errorList = null, Dictionary<string, string> additionalData = null, string ResultCode = FAULT_RESULT_CODE)
        {
            return new Response
            {
                Result = FAULT_RESULT,
                Errors = errorList,
                AdditionalData = additionalData,
                StatusCode = HttpStatusCode.BadRequest,
                ResultCode = ResultCode,
                ResultText = resultText
            };
        }
    }
}
