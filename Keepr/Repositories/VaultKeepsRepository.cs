// using System.Data;
// using Dapper;
// using Keepr.Models;

// namespace Keepr.Repositories
// {
//   public class VaultKeepsRepository
//   {
//     private readonly IDbConnection _db;
//     public VaultKeepsRepository(IDbConnection db)
//     {
//       _db = db;
//     }


//     public VaultKeepsRepository Create(VaultKeep newVK)
//     {
//       string sql = @"
//       INSERT INTO
//       vault_keeps(vaultId,keepId,creatorId)
//       VALUES(@VaultId, @KeepId,@CreatorId);
//       SELECT LAST_INSERT_ID();
//       ";
//       newVK.Id = _db.ExecuteScalar<int>(sql, newVK);
//       return newVK;
//     }
//   }
// }