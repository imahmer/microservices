using System.Net;

namespace OrderService.Models.Common
{
    public class Response
    {
        /// <summary>
        /// Transaction Result 0,1,2,3,4
        /// </summary>       
        public string Result { get; set; } = default!;
        /// <summary>
        /// Response text could be anything mostly SUCCESS,FAILED,DECLINED,ERROR
        /// </summary>
        public string ResultText { get; set; } = default!;
        /// <summary>
        /// Populate decline code if payment is declined
        /// </summary>        
        public string ResultCode { get; set; } = default!;
        /// <summary>
        /// Additional information for call back
        /// </summary>                
        public Dictionary<string, string> AdditionalData { get; set; } = default!;
        /// <summary>
        /// Api Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        public long Id { get; set; }
        public Dictionary<string, IEnumerable<string>> Errors { get; set; } = default!;
        /// <summary>
        /// Entity object which recently inserted
        /// </summary>
        public object? Data { get; set; } = null;
    }
}
