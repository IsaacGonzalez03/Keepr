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

    public VaultKeepViewModel GetById(int id)
    {
      var sql = @"
      SELECT
      k.*,
      vk.id AS vaultKeepId,
      k.id AS keepId,
      vk.vaultId AS vaultId,
      profile.*,
      profile.id AS creatorId
      FROM vault_keeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN accounts profile ON vk.creatorId = profile.id
      WHERE vk.id = @id;
      ";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }



    public VaultKeep Create(VaultKeep newVK)
    {
      var sql = @"
      INSERT INTO
      vault_keeps(vaultId,keepId,creatorId)
      VALUES(@VaultId, @KeepId,@CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newVK.Id = _db.ExecuteScalar<int>(sql, newVK);
      return newVK;
    }



    public int Delete(int id)
    {
      var sql = "DELETE FROM vault_keeps WHERE id = @Id;";
      return _db.Execute(sql, new { id });
    }


    public List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      var sql = @"
      SELECT
      k.*,
      vk.id AS vaultKeepId,
      vk.keepId AS keepId,
      vk.vaultId AS vaultId,
      profile.*
      FROM
      vault_keeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN accounts profile ON k.creatorId = profile.id
      WHERE vk.vaultId = @id;
      ";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (v, p) =>
      {
        v.Creator = p;
        return v;
      }, new { id }, splitOn: "id").ToList();
    }
  }
}