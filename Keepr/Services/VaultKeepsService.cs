using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

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


    // TODO find a way to prevent multiple of the same keep being added to one vault
    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, Account userInfo)
    {
      Vault target = _vs.Get(vaultKeepData.VaultId, userInfo);
      if (target.CreatorId != userInfo.Id)
      {
        throw new System.Exception("cannot add a keep to someone else's vault");
      }
      // List<VaultKeepKeepViewModel> vaultKeeps = this.GetKeepsByVault(vaultKeepData.VaultId, userInfo);
      // vaultKeeps.ForEach(k => {
      //   if (k.)
      //   {

      //   }
      // });
      return _repo.CreateVaultKeep(vaultKeepData);
    }

    internal List<VaultKeepKeepViewModel> GetKeepsByVault(int id, Account userInfo)
    {
      Vault target = _vs.Get(id, userInfo);
      List<VaultKeepKeepViewModel> keeps = _repo.GetKeepsByVault(id);
      return keeps;
    }

    internal ActionResult<string> DeleteVaultKeep(int id, Account userInfo)
    {
      VaultKeep target = _repo.GetById(id);
      if (target.CreatorId != userInfo.Id)
      {
        throw new Exception("Not yours");
      }
      return _repo.DeleteVaultKeep(id);
    }
  }
}