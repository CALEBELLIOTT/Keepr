using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vs;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vs)
    {
      _repo = repo;
      _vs = vs;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, Account userInfo)
    {
      Vault target = _vs.Get(vaultKeepData.VaultId, userInfo);
      if (target.CreatorId != userInfo.Id)
      {
        throw new System.Exception("cannot add a keep to someone else's vault");
      }
      return _repo.CreateVaultKeep(vaultKeepData);
    }
  }
}