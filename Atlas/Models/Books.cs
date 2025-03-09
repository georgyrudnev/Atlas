using Atlas.Interfaces;
using SQLite;
using DataAnnotations = System.ComponentModel.DataAnnotations;


namespace Atlas.Models
{
    [SQLite.Table("Books")]  // Explicit table name
    public class Book : IEntity
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [DataAnnotations.Required(ErrorMessage = "Title is required")]
        [MaxLength(200)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [DataAnnotations.Required(ErrorMessage = "Author is required")]
        [MaxLength(100)]
        [Column("author")]
        public string Author { get; set; } = "Unknown";

        [Column("current_page")]
        public int CurrentPage { get; set; }

        [DataAnnotations.Range(1, int.MaxValue)]
        [Column("total_pages")]
        public int TotalPages { get; set; } = 1;

        [Column("is_finished")]
        public bool IsFinished { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // Calculated property (not stored in DB)
        [Ignore]
        public double ProgressPercentage
        {
            get
            {
                if (TotalPages <= 0 || CurrentPage <= 0)
                    return 0;

                return Math.Round((double)CurrentPage / TotalPages * 100, 1);
            }
        }

        // Helper method for progress display
        public string ProgressString =>
            $"{CurrentPage} / {TotalPages} ({ProgressPercentage}%)";
    }
}