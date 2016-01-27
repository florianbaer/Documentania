using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Sqlite.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Document
    {

        public Document()
        {
            this.DocumentTags = new HashSet<DocumentTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string Path { get; set; }

        public virtual ICollection<DocumentTag> DocumentTags { get; set; }

        public DateTime Imported { get; set; }
    }
}