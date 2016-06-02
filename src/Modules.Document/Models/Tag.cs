namespace Modules.Document.Models
{
    using Documentania.Infrastructure.Interfaces;
    public class Tag : IStorable
    {
        public virtual string Id { get; set; } = string.Empty;

        public string Value { get; set; }
    }
}