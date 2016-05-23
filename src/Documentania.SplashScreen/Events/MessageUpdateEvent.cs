// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MessageUpdateEvent.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'MessageUpdateEvent.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.SplashScreen.Events
{
    using Prism.Events;

    public class MessageUpdateEvent : PubSubEvent<MessageUpdateEvent>
    {
        public string Message { get; set; }
    }
}