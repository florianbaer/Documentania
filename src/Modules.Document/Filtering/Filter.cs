using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Filtering
{
    using Modules.Document.Models;
    using Modules.Document.ViewModels;

    public abstract class Filter
    {
        public abstract ICollection<DocumentViewModel> Execute(ICollection<DocumentViewModel> documents);
    }
}
