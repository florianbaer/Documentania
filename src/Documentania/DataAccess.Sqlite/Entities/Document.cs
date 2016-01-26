namespace DataAccess.Sqlite.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Document
    {
        public Document()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; } 
    }
}