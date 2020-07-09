namespace SwaggerOAS3RestAPI.Security
{
    public interface ICredentials
    {
        string UserName { get; }
        string Password { get; }
    }
}