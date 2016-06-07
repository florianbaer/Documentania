namespace Document.Model.Models
{
    using Documentania.Infrastructure.Interfaces;

    public class Tag : IStorable
    {
        public virtual string Id { get; set; } = string.Empty;
        public string Name { get; set; }

        public string Value { get; set; }
    }
}