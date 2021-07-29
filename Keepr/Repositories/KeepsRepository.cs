using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Keep Create(Keep newKeep)
    {
      var sql = @"
      INSERT INTO 
      keeps(creatorId, name, description, img, views, shares, keeps)
      VALUES(@CreatorId, @Name, @Description, @Img, 0, 0, 0);
      SELECT LAST_INSERT_ID();
      ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }
    public List<Keep> GetAll()
    {
      var sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
       {
         k.Creator = p;
         return k;
       }, splitOn: "id").ToList();
    }

    public Keep GetById(int id)
    {
      var sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.id = @id;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
         {
           k.Creator = p;
           return k;
         }, new { id }).FirstOrDefault();
    }
    public List<Keep> GetKeepsByProfileId(string id)
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.creatorId = @id;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, p) =>
      {
        k.Creator = p;
        return k;
      }, new { id }).ToList();
    }

    public Keep Update(Keep updateData)
    {
      var sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps
      WHERE id = @Id;
      ";
      _db.Execute(sql, updateData);
      return updateData;
    }

    public int Delete(int id)
    {
      var sql = "DELETE FROM keeps WHERE id = @id;";
      int deletedKeep = _db.Execute(sql, new { id });
      return deletedKeep;
    }
  }
}

// public int Id { get; set; }
// public string CreatorId { get; set; }
// public string Name { get; set; }
// public string Description { get; set; }
// public string Img { get; set; }
// public int Views { get; set; } = 0;
// public int Shares { get; set; } = 0;
// public int Keeps { get; set; } = 0;
// public Profile Creator { get; set; }