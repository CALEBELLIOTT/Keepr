using System;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal ActionResult<Profile> Get(string id)
    {
      Profile target = _repo.Get(id);
      if (target == null)
      {
        throw new Exception("invalid profile Id");
      }
      return target;
    }
  }
}