using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using WebApiContrib.Formatting.Jsonp;
using WorldData.Formatters;

namespace WorldData.App_Start
{

    public class FormatterConfig
    {
        public static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            formatters.Remove(formatters.JsonFormatter);
            formatters.Insert(0, new Formatters.JsonpMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }
    }
    }