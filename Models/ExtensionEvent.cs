using System.Text.Json;

namespace ArconBackend.Models
{
    public class ExtensionEvent
    {
        public string Event { get; set; }

        public string Timestamp { get; set; }

        public JsonElement Extension { get; set; }
    }
}