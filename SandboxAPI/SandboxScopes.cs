namespace SandboxAPI;

public static class SandboxScopes
{
    public const string ReadAbout = "read:about";
    public const string WriteAbout = "write:about";

    public static readonly string[] Scopes =
    {
        ReadAbout,
        WriteAbout
    };
}