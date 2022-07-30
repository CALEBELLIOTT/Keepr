using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile Get(string id)
    {
      string sql = @"
        SELECT * FROM accounts WHERE id = @id LIMIT 1;
        ";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }
  }
}