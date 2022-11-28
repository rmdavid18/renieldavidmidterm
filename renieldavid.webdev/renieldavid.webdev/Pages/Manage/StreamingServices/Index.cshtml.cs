using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using renieldavid.webdev.Infrastructure.Domain;
using renieldavid.webdev.Infrastructure.Domain.Models;
using System.Data;

namespace renieldavid.webdev.Pages.Manage.StreamingServices
{
    public class Index : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDbContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public Index(DefaultDbContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet(List<video> videos, int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Ascending, string? keyword = "")
        {
            var skip = (int)((pageIndex - 1) * pageSize);

            var query = _context.StreamingAndServices.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.Title != null && a.Title.ToLower().Contains(keyword.ToLower())
                        || a.Description != null && a.Description.ToLower().Contains(keyword.ToLower())
                        || a.Abbreviation != null && a.Abbreviation.ToLower().Contains(keyword.ToLower())
                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "title" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.Title);
                }
                else if (sortBy.ToLower() == "title" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Title);
                }
                else if (sortBy.ToLower() == "description" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.Description);
                }
                else if (sortBy.ToLower() == "description" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Description);
                }
                else if (sortBy.ToLower() == "abbreviation" && sortOrder == SortOrder.Ascending)
                {
                    query = _context.StreamingAndServices.OrderBy(a => a.Abbreviation);
                }
                else if (sortBy.ToLower() == "abbreviation" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Abbreviation);
                }
            }

            var streamingAndServices = query
                            .Skip(skip)
            .Take((int)pageSize)
                            .ToList();

            View.StreamingAndServices = new Paged<StreamingAndService>()
            {
                Items = streamingAndServices,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRows = totalRows,
                SortBy = sortBy,
                SortOrder = sortOrder,
                Keyword = keyword

            };

       
        }



        public class ViewModel
        {
            public Paged<StreamingAndService>? StreamingAndServices { get; set; }
            public Paged<video>? Videos { get; set; }
            
        }
    }
}

