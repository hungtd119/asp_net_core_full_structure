using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos.Common
{
    public class FilterDto
    {
        private string _keyword;
        [FromQuery(Name = "keyword")]
        public string Keyword { get { return _keyword; } set { _keyword = value?.Trim(); } }

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; }

        public int Skip()
        {
            return (PageIndex - 1) * PageSize;
        }
    }
}
