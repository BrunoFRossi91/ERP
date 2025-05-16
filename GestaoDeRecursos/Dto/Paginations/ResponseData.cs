namespace DBT.Utils.Paginations
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
        public ResponseMetaData MetaData { get; set; }
    }
}
