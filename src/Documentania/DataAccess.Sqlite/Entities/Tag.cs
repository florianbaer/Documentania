// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tag.cs" company="BaerDev">
// Copyright (c) BaerDev. All rights reserved.
// </copyright>
// <summary>
// The file 'Tag.cs'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite.Entities
{
    public class Tag
    {
        public Tag()
        {
            DocumentTags = new HashSet<DocumentTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<DocumentTag> DocumentTags { get; set; }
    }
}