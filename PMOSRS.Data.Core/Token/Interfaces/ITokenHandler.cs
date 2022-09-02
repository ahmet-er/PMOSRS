namespace PMOSRS.Data.Core.Token.Interfaces
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute);
    }
}
