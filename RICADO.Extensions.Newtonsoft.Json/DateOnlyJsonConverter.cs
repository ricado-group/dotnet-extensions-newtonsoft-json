﻿using System;
using Newtonsoft.Json;

namespace RICADO.Extensions.Newtonsoft.Json
{
    public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("O"));
        }

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateOnly.FromDateTime(reader.ReadAsDateTime().Value);
        }
    }
}
