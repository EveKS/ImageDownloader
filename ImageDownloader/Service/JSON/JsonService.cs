﻿using Newtonsoft.Json;

namespace ImageDownloader.Service.JSON
{
    class JsonService : IJsonService
    {
        T IJsonService.JsonConvertDeserializeObjectWithNull<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
            }
            catch
            {
                return default(T);
            }
        }

        T IJsonService.JsonConvertDeserializeObject<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
