﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using XSockets.Client40.Common.Event.Arguments;
using XSockets.Client40.Model;
using XSockets.Client40.Utility.Storage;

namespace XSockets.Client40.Common.Interfaces
{
    public interface IXSocketClient
    {
        event EventHandler OnConnected;
        event EventHandler OnDisconnected;
        event EventHandler<OnErrorArgs> OnError;
        event EventHandler<Message> OnPing;
        event EventHandler<Message> OnPong;

        NameValueCollection QueryString { get; set; }
        NameValueCollection Headers { get; set; }
        CookieCollection Cookies { get; set; }
        
        IXSocketJsonSerializer Serializer { get; set; }
        Guid PersistentId { get; set; }

        RepositoryInstance<string, IController> Controllers { get; set; }
        IController Controller(string controller);    

        bool IsConnected { get; }
        bool IsHandshakeDone { get; }

        ISocketWrapper Socket { get; }
        string Url { get; }
                

        void Disconnect();
        void Open();
        void Reconnect();

        void SetProxy(IWebProxy proxy);
        void AddClientCertificate(X509Certificate2 certificate);

        void FireError(Exception ex);
        void FireError(OnErrorArgs args);
    }
}
