using System.Data;

namespace CreditCard_Transactions.Repositories
{
    public interface IHelper
    {
        IDbConnection Connection { get; }
    }
}
