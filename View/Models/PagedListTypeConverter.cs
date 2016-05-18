using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class PagedListTypeConverter<T> : ITypeConverter<IPagedList<T>, PagedViewModel<T>>
    {
        public PagedViewModel<T> Convert(ResolutionContext context)
        {
            var source = (IPagedList<T>)context.SourceValue;
            return new PagedViewModel<T>()
            {
                FirstItemOnPage = source.FirstItemOnPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                IsFirstPage = source.IsFirstPage,
                IsLastPage = source.IsLastPage,
                LastItemOnPage = source.LastItemOnPage,
                PageCount = source.PageCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalItemCount = source.TotalItemCount,
                rows = source
            };
        }
    }
}