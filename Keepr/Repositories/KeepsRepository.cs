using System.Data;
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
      INSERT INTO keeps (id, creatorId, name, description, img);
      VALUES (@Id, @CreatorId, @Name, @Description, @Img);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }
  }
}