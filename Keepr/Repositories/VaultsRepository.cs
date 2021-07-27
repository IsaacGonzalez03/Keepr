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
    public Vault Create(Vault newVault)
    {
      var sql = @"
      INSERT INTO
      vaults(name, description, img, isPrivate, creatorId)
      VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }




    // v.creatorId switch with a.id
    //Account instead of profile p to a
    public Vault GetById(int id)
    {
      var sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @id;
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (v, p) =>
       {
         v.Creator = p;
         return v;
       }, new { id }).FirstOrDefault();
    }
    public Vault Update(Vault updateData)
    {
      var sql = @"
      UPDATE vaults
      SET
      name = @Name,
      description = @Description,
      img = @Img,
      isPrivate = @IsPrivate,
      creatorId = @CreatorId
      WHERE id = @Id;
      ";
      _db.Execute(sql, updateData);
      return updateData;
    }

    // public int Delete(int id)
    // {
    //   var sql = @"
    //   DELETE FROM vaults 
    //   WHERE id = @Id 
    //   LIMIT 1;
    //   ";
    //   return _db.Execute(sql, new { id });
    // }
  }
}
// public int Id { get; set; }
// public string CreatorId { get; set; }
// public string Name { get; set; }
// public string Description { get; set; }
// public string Img { get; set; }
// public bool IsPrivate { get; set; }
// public Profile Creator { get; set; }