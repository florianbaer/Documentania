using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Model.TemplateEngine
{
    using System.Collections.Concurrent;

    public class DocumentTemplate
    {
        private DocumentTemplate(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public IDictionary<string, ICustomType> Properties { get; set; } = new ConcurrentDictionary<string, ICustomType>();


        public class DocumentTemplateBuilder : IDocumentTemplateBuilder
        {
            private DocumentTemplate documentTemplate;

            public DocumentTemplateBuilder(string name)
            {
                this.documentTemplate = new DocumentTemplate(name);
            }

            public IDocumentTemplateBuilder AddProperty<T>(string name, T defaultValue)
            {
                this.documentTemplate.Properties.Add(name, new Type<T>(defaultValue));
                return this;
            }

            public DocumentTemplate Construct()
            {
                return this.documentTemplate;
            }
        }
    }

    public interface IDocumentTemplateBuilder
    {
        IDocumentTemplateBuilder AddProperty<T>(string name, T defaultValue);

        DocumentTemplate Construct();
    }

    public interface ICustomType
    {
    }
}
