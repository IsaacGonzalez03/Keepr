using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kr;

    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
    }
    public Keep Create(Keep newKeep)
    {
      var keep = _kr.Create(newKeep);
      return newKeep;
    }
  }
}