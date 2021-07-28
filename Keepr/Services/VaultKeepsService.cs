using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    private readonly KeepsRepository _kr;

    public VaultKeepsService(VaultKeepsRepository vkr, KeepsRepository kr)
    {
      _vkr = vkr;
      _kr = kr;
    }
    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      Keep keep = _kr.GetById(newVaultKeep.keepId);
      keep.Keeps++;
      _kr.Update(keep);
      return _vkr.Create(newVaultKeep);
    }

    public VaultKeepViewModel GetById(int id)
    {
      VaultKeepViewModel keep = _vkr.GetById(id);
      if (keep == null)
      {
        throw new Exception("bad id g-bid vkvm");
      }
      return keep;
    }












    public void Delete(int id, string creatorId)
    {
      VaultKeepViewModel vaultKeep = _vkr.GetById(id);
      Keep keep = _kr.GetById(vaultKeep.Id);
      keep.Keeps--;
      _kr.Update(keep);
      _vkr.Delete(id);
    }
  }
}