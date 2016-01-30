// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentTag.cs" company="BaerDev">
// Copyright (c) BaerDev. All rights reserved.
// </copyright>
// <summary>
// The file 'DocumentTag.cs'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Sqlite.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DocumentTag
    {
        public int DocumentId { get; set; }

        public Document Document { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}