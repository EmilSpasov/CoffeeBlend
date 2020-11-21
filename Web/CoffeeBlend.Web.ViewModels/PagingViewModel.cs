namespace CoffeeBlend.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PageCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PageCount => (int)Math.Ceiling((double)this.BlogsCount / this.ItemsPerPage);

        public int BlogsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
