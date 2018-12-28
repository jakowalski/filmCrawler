using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace FilmCrawler.Converters
{
    public class SingleValueArrayConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = new Object();
            if (reader.TokenType == JsonToken.StartObject)
            {
                T instance = (T)serializer.Deserialize(reader, typeof(T));
                retVal = new List<T>() { instance };
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                retVal = serializer.Deserialize(reader, objectType);
            }
            else if( reader.TokenType==JsonToken.String)
            {
                var localValue=(T)serializer.Deserialize(reader, typeof(T));
                retVal = new List<T>() { localValue };

            }
            else if (reader.TokenType == JsonToken.Boolean)
            {
                retVal = serializer.Deserialize(reader, typeof(bool));
            }
            else if (reader.TokenType == JsonToken.Float)
            {
                retVal = serializer.Deserialize(reader, typeof(float));
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                retVal = serializer.Deserialize(reader,typeof(Int32));
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
