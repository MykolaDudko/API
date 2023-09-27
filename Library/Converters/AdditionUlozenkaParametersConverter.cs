using ClassLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibrary.Converters;

public class AdditionUlozenkaParametersConverter : JsonConverter<AdditionalParameters?>
{
    public override AdditionalParameters? ReadJson(JsonReader reader, Type objectType, AdditionalParameters? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JToken token = JToken.Load(reader);

        if (token.Type == JTokenType.Array && !token.HasValues)
        {
            return null;
        }

        return token.ToObject<AdditionalParameters?>(serializer);
    }

    public override void WriteJson(JsonWriter writer, AdditionalParameters? value, JsonSerializer serializer)
    {

    }
}
