// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="AddDocumentEvent.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'AddDocumentEvent.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Modules.Document.Event
{
    using Prism.Events;
    public class AddDocumentEvent : PubSubEvent<Document>
    {
        public Document Document { get; private set; }

        public AddDocumentEvent(Document document)
        {
            this.Document = document;
        }
         
    }
}