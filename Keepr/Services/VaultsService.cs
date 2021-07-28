using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;
    private readonly VaultKeepsRepository _vkr;

    public VaultsService(VaultsRepository vr, VaultKeepsRepository vkr)
    {
      _vr = vr;
      _vkr = vkr;
    }

    public Vault Create(Vault vaultData)
    {
      var newVault = _vr.Create(vaultData);
      return newVault;
    }
    public Vault GetById(int id)
    {
      Vault vault = _vr.GetById(id);
      if (vault == null)
      {
        throw new Exception("bad id g-bid vs");
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

    public List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      return _vkr.GetVaultKeeps(id);
    }

    public void Delete(int id, string creatorId)
    {
      Vault vault = GetById(id);
      if (vault?.CreatorId != creatorId)
      {
        throw new Exception("This does not belong to you!");
      }
      _vr.Delete(id);
    }

    internal List<Vault> GetVaultsByAccountId(string id)
    {
      return _vr.GetVaultsByAccountId(id);
    }

    internal List<Vault> GetVaultsByProfileId(string id)
    {
      return _vr.GetVaultsByProfileId(id);
    }
  }
}