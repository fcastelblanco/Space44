namespace Fc.Infraestructure.Definitions
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string Token { get; }
    }
}
