﻿namespace Entities.RequestFeatures
{
    public class RequestParameters
    {
        private const int maxPageSize = 50;
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value <= 0) ? _pageNumber : value;
        }

        public string OrderBy { get; set; }

        public string SearchTerm { get; set; }

        public string SearchColumns { get; set; }

        public int Id { get; set; }
    }
}
