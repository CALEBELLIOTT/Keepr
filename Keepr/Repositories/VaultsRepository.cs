using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
      string sql = @"
        INSERT INTO vaults
        (name, description, img, isPrivate, creatorId)
        VALUES
        (@Name, @Description, @Img, @IsPrivate, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, vaultData);
      vaultData.Id = id;
      return vaultData;
    }

    internal Vault Get(int id)
    {
      string sql = @"
        SELECT
            v.*,
            a.*
        FROM
            vaults v
        JOIN
            accounts a ON v.creatorId = a.id
        WHERE
            v.id = @id
        ";
      Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, prof) =>
      {
        vault.Creator = prof;
        return vault;
      }, new { id }).FirstOrDefault();
      return vault;
    }

    internal Vault EditVault(int id, Vault vaultData)
    {
      string sql = @"
        UPDATE vaults SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate
        WHERE id = @id;
        ";
      _db.Execute(sql, vaultData);
      return this.Get(id);
    }

    internal string DeleteVault(int id)
    {
      string sql = @"
        DELETE FROM vaults WHERE id = @id LIMIT 1;
        ";
      _db.Execute(sql, new { id });
      return "delorted";
    }

  }
}