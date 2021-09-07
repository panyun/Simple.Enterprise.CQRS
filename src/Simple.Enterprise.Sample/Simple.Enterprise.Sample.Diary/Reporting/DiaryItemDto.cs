using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Simple.Enterprise.Sample.Diary.Reporting
{
    public class DiaryItemDto
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Version { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
