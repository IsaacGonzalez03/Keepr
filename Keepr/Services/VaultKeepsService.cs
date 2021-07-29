using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    private readonly KeepsRepository _kr;
    private readonly VaultsRepository _vr;

    public VaultKeepsService(VaultKeepsRepository vkr, KeepsRepository kr, VaultsRepository vr)
    {
      _vkr = vkr;
      _kr = kr;
      _vr = vr;
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      Vault vault = _vr.GetById(newVaultKeep.vaultId);
      if (vault.CreatorId != newVaultKeep.CreatorId)
      {
        throw new Exception("Unable to add to Vault");
      }
      VaultKeep newVK = _vkr.Create(newVaultKeep);
      return newVK;
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

    public string Delete(int id, string userId)
    {
      VaultKeepViewModel vaultKeep = _vkr.GetById(id);
      if (vaultKeep.CreatorId != userId)
      {
        throw new Exception("not yours to delete");
      }
      int deletedVK = _vkr.Delete(id);
      return "she gone";
    }
  }
}