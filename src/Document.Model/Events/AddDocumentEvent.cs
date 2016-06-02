// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddDocumentEvent.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'AddDocumentEvent.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Document.Model.Events
{
    using Prism.Events;

    using Document = Document.Model.Models.Document;
    using Tag = Document.Model.Models.Tag;

    public class AddDocumentEvent : PubSubEvent<Document>
    {
        public Document Document { get; private set; }

        public AddDocumentEvent(Document document)
        {
            this.Document = document;
        }
         
    }
}