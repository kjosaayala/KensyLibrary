using Domain.Main;
using Domain.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    [Table("Books", Schema = "data")]
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string InternationalStandardBookNumber { get; set; }
        public int Pages { get; set; }
        public int Inventory { get; set; }
        public int Available { get; set; }
        public int EditorialId { get; set; }
        [ForeignKey("EditorialId")]
        public virtual Editorial Editorial { get; set; }
        public int EditionYear { get; set; }
        public int LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public virtual ICollection<BookRequest> BookRequests { get; set; }

    }
}
