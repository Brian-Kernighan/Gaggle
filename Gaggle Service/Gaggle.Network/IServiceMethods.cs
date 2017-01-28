namespace GaggleService.Network
{
    public interface IServiceMethods
    {
        void Logoff();

        void Register(string email, string password, string name);

        byte[] Authorize(string email, string password);
    }
}
