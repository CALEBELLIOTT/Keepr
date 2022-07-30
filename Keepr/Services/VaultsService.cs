using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }



    internal Vault CreateVault(Account userInfo, Vault vaultData)
    {
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _repo.CreateVault(vaultData);
      vault.Creator = userInfo;
      return vault;
    }

    internal Vault
    Get(int id, Account userInfo)
    {
      Vault targetVault = _repo.Get(id);
      if (targetVault.IsPrivate == true && targetVault.CreatorId != userInfo.Id)
      {
        throw new Exception("That Vault is Private");
      }
      return targetVault;
    }

    internal Vault EditVault(int id, Account userInfo, Vault vaultData)
    {
      Vault target = this.Get(id, userInfo);
      return _repo.EditVault(id, vaultData);
    }

    internal string DeleteVault(int id, Account userInfo)
    {
      Vault target = this.Get(id, userInfo);
      if (target.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your Vault to delete");
      }
      return _repo.DeleteVault(id);
    }

    internal ActionResult<List<Vault>> GetProfileVaults(string id, Account userInfo)
    {
      List<Vault> vaults = _repo.GetProfileVaults(id);
      if (userInfo.Id == id)
      {
        return vaults;
      }
      int index = 0;
      vaults.ForEach(v =>
      {
        if (v.IsPrivate)
        {
          vaults.RemoveAt(index);
          index++;
        }
      });
      return vaults;
    }
  }
}