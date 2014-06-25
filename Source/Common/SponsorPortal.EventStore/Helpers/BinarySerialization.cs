using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SponsorPortal.Infrastructure;
using EventStore.ClientAPI;

namespace SponsorPortal.EventStore.Helpers
{
    public static class BinarySerialization
    {
        public static byte[] ToBinaryArray(this object obj)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        public static TEvent ParseTo<TEvent>(this ResolvedEvent eventData) where TEvent : IEvent
        {
            var dataBytes = eventData.Event.Data;
            var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(dataBytes, 0, dataBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            return (TEvent)binForm.Deserialize(memStream);
        }
    }
}
