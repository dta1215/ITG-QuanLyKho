using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace QuanLyKho.Services.DTO
{
    public class SearchModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(50)]
        public string SearchTerm { get; set; }
    }
}
