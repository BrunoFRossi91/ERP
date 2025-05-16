using System;

namespace DBT.Utils.Paginations
{
    public class ResponseMetaData
    {
        public ResponseMetaData(int totalCount, int pageSize, int pageNumber)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public int CurrentPage { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
