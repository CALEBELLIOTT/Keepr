using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
      string sql = @"
        INSERT INTO vaultKeeps
        (creatorId, keepId, vaultId)
        VALUES
        (@CreatorId, @KeepId, @VaultId);
        SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }

    internal List<VaultKeepKeepViewModel> GetKeepsByVault(int id)
    {
      string sql = @"
        SELECT 
            a.*,
            k.*,
            vk.id AS vaultKeepId
        FROM
            vaultKeeps vk
        JOIN
            keeps k ON k.id = vk.keepId
        JOIN
            accounts a on a.id = k.creatorId
        WHERE vk.vaultId = @id;
        ";
      List<VaultKeepKeepViewModel> keeps = _db.Query<Profile, VaultKeepKeepViewModel, VaultKeepKeepViewModel>(sql, (prof, vkkvm) =>
      {
        vkkvm.Creator = prof;
        return vkkvm;
      }, new { id }).ToList();
      return keeps;
    }
  }
}