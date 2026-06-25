namespace ArconBackend.Policies
{
    public enum ExtensionPolicyMode
    {
        AllowSelected,
        BlockSelected,
        BlockAll
    }

    public static class ExtensionPolicy
    {
        // Change this mode to control enforcement behavior.
        // AllowSelected = only listed extensions are allowed.
        // BlockSelected = only blocked extensions are disabled.
        // BlockAll = all extensions are disabled.
        public static readonly ExtensionPolicyMode Mode =
            ExtensionPolicyMode.AllowSelected;

        public static readonly HashSet<string> AllowedExtensions =
            new()
            {
                "majdfhpaihoncoakbjgbdhglocklcgno",
                "lmhkpmbekcpmknklioeibfkpmmfibljd"
            };

        public static readonly HashSet<string> BlockedExtensions =
            new()
            {
                "mmioliijnhnoblpgimnlajmefafdfilb"
            };

        public static bool IsAllowed(string extensionId)
        {
            if (string.IsNullOrWhiteSpace(extensionId))
            {
                return false;
            }

            return Mode switch
            {
                ExtensionPolicyMode.BlockAll => false,
                ExtensionPolicyMode.BlockSelected =>
                    !BlockedExtensions.Contains(extensionId),
                ExtensionPolicyMode.AllowSelected =>
                    AllowedExtensions.Contains(extensionId),
                _ => false
            };
        }
    }
}