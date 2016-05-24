using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Document.Filtering
{
    using Modules.Document.Models;
    using Modules.Document.ViewModels;

    public class AllDocumentsFilter : Filter
    {
        public override ICollection<DocumentViewModel> Execute(ICollection<DocumentViewModel> documents)
        {
            return documents;
        }
    }
}
