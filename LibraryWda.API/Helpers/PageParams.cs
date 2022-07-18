namespace LibraryWda.API.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize 
        { 
            get { return pageSize; } 
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

    }
}
