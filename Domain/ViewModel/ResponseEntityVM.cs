namespace Domain.ViewModel
{
    public class ResponseEntityVM
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
