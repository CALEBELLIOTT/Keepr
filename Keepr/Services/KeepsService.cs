using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public Keep CreateKeep(Keep keepData, Account userInfo)
    {
      keepData.CreatorId = userInfo.Id;
      keepData.Creator = userInfo;
      Keep keep = _repo.CreateKeep(keepData);
      return keep;
    }

    internal List<Keep> Get()
    {
      List<Keep> keeps = _repo.Get();
      return keeps;
    }

    internal Keep Get(int id)
    {
      Keep keep = _repo.Get(id);
      if (keep == null)
      {
        throw new Exception("invalid keep ID");
      }
      return keep;
    }

    internal Keep Edit(int id, Account userInfo, Keep updated)
    {
      Keep target = this.Get(id);
      if (target.CreatorId != userInfo.Id)
      {
        throw new Exception("Unauthorized to edit that Keep");
      }
      updated.Id = id;
      return _repo.Edit(id, updated);
    }

    internal ActionResult<string> DeleteKeep(int id, Account userInfo)
    {
      Keep target = this.Get(id);
      if (target.CreatorId != userInfo.Id)
      {
        throw new Exception("Unauthorized to delete that Keep");
      }
      return _repo.DeleteKeep(id);
    }
  }
}