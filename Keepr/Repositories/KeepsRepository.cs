using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Keep CreateKeep(Keep keepData)
    {
      string sql = @"
        insert into keeps
        (name, description, img, views, kept, creatorId)
        VALUES
        (@Name, @Description, @Img, @Views, @Kept, @CreatorId);
        SELECT LAST_INSERT_ID();
        ";
      int keepId = _db.ExecuteScalar<int>(sql, keepData);
      keepData.Id = keepId;
      return keepData;
    }



    internal List<Keep> Get()
    {
      string sql = @"
        SELECT 
            k.*,
            a.*
        FROM 
            keeps k
        JOIN accounts a ON k.creatorId = a.id
        ";
      List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, prof) =>
      {
        keep.Creator = prof;
        return keep;
      }).ToList();
      return keeps;
    }



    internal Keep Get(int id)
    {
      string sql = @"
    SELECT
        k.*,
        a.*
    FROM
        keeps k
    JOIN
        accounts a ON k.creatorId = a.id
    WHERE
        k.id = @id
    ";
      Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, prof) =>
      {
        keep.Creator = prof;
        return keep;
      }, new { id }).FirstOrDefault();
      return keep;
    }



    internal Keep Edit(int id, Keep updated)
    {
      string sql = @"
        UPDATE keeps SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            kept = @Kept
        Where id = @Id;
        ";
      _db.Execute(sql, updated);
      Keep updatedKeep = this.Get(id);
      return updatedKeep;
    }

    internal Keep KeepIncrement(int id, Keep updated)
    {
      string sql = @"
        UPDATE keeps SET
            kept = @Kept
        Where id = @Id;
        ";
      _db.Execute(sql, updated);
      Keep updatedKeep = this.Get(id);
      return updatedKeep;
    }

    internal Keep ViewIncrement(int id, Keep updated)
    {
      string sql = @"
        UPDATE keeps SET
            views = @Views
        Where id = @Id;
        ";
      _db.Execute(sql, updated);
      Keep updatedKeep = this.Get(id);
      return updatedKeep;
    }

    internal ActionResult<string> DeleteKeep(int id)
    {
      string sql = @"
        DELETE FROM keeps WHERE id = @id LIMIT 1;
        ";
      _db.Execute(sql, new { id });
      return "delorted";
    }

    internal List<Keep> GetProfileKeeps(string id)
    {
      string sql = @"
      SELECT * FROM keeps WHERE creatorId = @id;
      ";
      return _db.Query<Keep>(sql, new { id }).ToList();
    }

  }





}