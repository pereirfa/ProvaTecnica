using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CourseSignUP.DTO
{
    public class ResponseDTO<T>
    {
      [JsonProperty("data", Required= Required.Default , NullValueHandling = NullValueHandling.Ignore )]
      public T Data { get; set; }

      [JsonProperty("exceptionMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
      public string ExceptionMessage { get; set; }

      [JsonProperty("hostName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
      public string HostName { get; set; }

      [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
      public string Message { get; set; }

      [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
      public bool Status { get; set; }

    }
}
