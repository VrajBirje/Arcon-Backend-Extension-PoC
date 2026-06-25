namespace ArconBackend.Models
{
    public class ExtensionValidationResponse
    {
        public bool Allowed { get; set; }

        public string ExtensionId { get; set; }

        public string ExtensionName { get; set; }

        public string Message { get; set; }
    }
}