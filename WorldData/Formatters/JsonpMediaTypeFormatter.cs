﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;

namespace WorldData.Formatters
{
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private readonly HttpRequestMessage _request;
        private string _callbackQueryParameter;

        public JsonpMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(DefaultMediaType);
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));

            MediaTypeMappings.Add(new UriPathExtensionMapping("jsonp", "application/json"));
        }

        public JsonpMediaTypeFormatter(HttpRequestMessage request)
            : this()
        {
            _request = request;
        }

        public string CallbackQueryParameter
        {
            get { return _callbackQueryParameter ?? "callback"; }
            set { _callbackQueryParameter = value; }
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (request == null)
                throw new ArgumentNullException("request");

            return new JsonpMediaTypeFormatter(request) { SerializerSettings = SerializerSettings };
            
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            string callback;
            if (IsJsonpRequest(_request, out callback))
            {

                var writer = new StreamWriter(stream);
                writer.Write(callback + "(");
                writer.Flush();

                return base.WriteToStreamAsync(type, value, stream, content, transportContext).ContinueWith(_ =>
                {

                    //TODO: Inspecting the task status and acting on that is better
                    writer.Write(")");
                    writer.Flush();
                });
            }

            return base.WriteToStreamAsync(type, value, stream, content, transportContext);
        }

        private bool IsJsonpRequest(HttpRequestMessage request, out string callback)
        {
            callback = null;

            if (request == null || request.Method != HttpMethod.Get)
            {
                return false;
            }

            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);
            callback = query[CallbackQueryParameter];

            return !string.IsNullOrEmpty(callback);
        }
    }
}