namespace DBT.Utils.Paginations
{
    public class RequestData<T> : PaginationParams
        where T : class
    {
        public T Filter { get; set; }
    }
}
