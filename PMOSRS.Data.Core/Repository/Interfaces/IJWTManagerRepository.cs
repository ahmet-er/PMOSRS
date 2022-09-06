using PMOSRS.Model.Models.Items;

namespace PMOSRS.Data.Core.Repository.Interfaces
{
	public interface IJWTManagerRepository
	{
		Tokens Authenticate(LoginItem loginItem);
	}
}
