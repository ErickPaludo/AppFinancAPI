namespace WebApplication1.Objetos
{

    public class Response<T>
    {
        public List<T> response { get; set; }

        public Response()
        {
            response = new List<T>();
        }
    }
    public class ResPonseList
    {
        public int code { get; set; }
        public string desc { get; set; }
    }
}
