using System.Net;

namespace PMOSRS.Model.Models.Items
{
    // ResultItem - Global dönüş objesidir -helalmis
    public class ResultItem<T> where T : class, new()
    {
        public bool IsOk { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string ProcessCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResultItem(bool isOk = true, T data = null, string message = "", HttpStatusCode httpStatusCode = HttpStatusCode.OK, string processCode = "")
        {
            this.IsOk = isOk;
            this.Data = data;
            this.Message = message;
            this.StatusCode = httpStatusCode;
            this.ProcessCode = processCode;
        }
    }
}
