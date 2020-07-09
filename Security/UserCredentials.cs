namespace SwaggerOAS3RestAPI.Security
{
    public class UserCredentials : ICredentials
    {
        public UserCredentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}