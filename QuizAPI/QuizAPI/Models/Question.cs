using QuizAPI.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuizAPI.Models
{
    public class Question
    {
        [Key]
        public int QuId { get; set; }

        [Column(TypeName ="nvarchar(250)")]
        public string QuInWords { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? QuImageName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option1 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option2 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option3 { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Option4 { get; set; }

        public int Answer { get; set; }
    }
}
