using ArconBackend.Models;

namespace ArconBackend.Services
{
    public static class ViolationService
    {
        private static readonly List<ExtensionViolation>
            Violations =
                new List<ExtensionViolation>();

        public static void AddViolation(
            ExtensionViolation violation)
        {
            Violations.Add(
                violation);
        }

        public static List<ExtensionViolation>
            GetViolations()
        {
            return Violations;
        }
    }
}