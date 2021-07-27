using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;
    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }
    public Vault Create(Vault vaultData)
    {
      var newVault = _vr.Create(vaultData);
      return newVault;
    }
    public Vault GetById(int id, string userId)
    {
      Vault vault = _vr.GetById(id);
      if (vault.IsPrivate != true)
      {
        if (vault.CreatorId != userId)
        {
          throw new Exception("Private Vault");
        }
      }
      return vault;
    }
    public Vault Update(Vault updateData, string id)
    {
      Vault original = _vr.GetById(updateData.Id);
      if (original.CreatorId != id)
      {
        throw new Exception("Invalid Id");
      }
      updateData.CreatorId = id;
      return _vr.Update(updateData);
    }
    // public string Delete(int id, string userId)
    // {
    //   Vault vault = GetById(id, vault.CreatorId);
    //   if (vault?.CreatorId != userId)
    //   {
    //     throw new Exception("This does not belong to you!");
    //   }
    //   return _vr.Delete(id);
    // }
  }
}