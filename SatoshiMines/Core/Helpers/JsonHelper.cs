using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SatoshiMines.Core.Helpers
{
    // Thanks PeriodFatty.

    public static class JsonHelper
    {
        /// <summary>
        /// Serializes an object to the respectable JSON string.
        /// </summary>
        public static string Serialize<T>(T instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Deserializes a JSON string to the specified object.
        /// </summary>
        public static T Deserialize<T>(string json)
        {
            var deserializer = new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                return (T)deserializer.ReadObject(stream);
        }
    }
}