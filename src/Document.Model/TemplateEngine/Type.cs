namespace Document.Model.TemplateEngine
{
    using System;

    public class Type<T> : ICustomType
    {
        public Type(T defaultValue)
        {
            this.Value = defaultValue;
        }

        public T Value { get; set; }
    }
}