using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Filtering
{
    using Modules.Document.Models;

    public abstract class DocumentFilterBase
    {
        public abstract IEnumerable<Document> Filter(ICollection<Document> documents);
    }
}
