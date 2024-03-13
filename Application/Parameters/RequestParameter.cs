namespace Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 1500;

        }

        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 1500 ? 1500 : pageSize;
        }
    }
}
