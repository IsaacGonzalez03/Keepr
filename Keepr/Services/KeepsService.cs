using System;
using System.Collections.Generic;
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
    public Keep Create(Keep keepData)
    {
      var newKeep = _kr.Create(keepData);
      return newKeep;
    }


    public List<Keep> GetAll()
    {
      return _kr.GetAll();
    }


    public Keep GetById(int id)
    {
      //NOTE view count 
      Keep keep = _kr.GetById(id);
      return keep;
    }

    public Keep Update(Keep updateData, string id)
    {
      Keep original = GetById(updateData.Id);
      if (original == null)
      {
        throw new Exception("nope Bad Id");
      }
      if (original.CreatorId != id)
      {
        throw new Exception("Not your Keep Invalid Id");
      }
      original.Name = updateData.Name ?? original.Name;
      original.Description = updateData.Description ?? original.Description;
      original.Img = updateData.Img ?? original.Img;
      // NOTE how to handle views shares and keeps
      updateData.CreatorId = id;
      return _kr.Update(updateData);
    }

    public List<Keep> GetKeepsByProfileId(string id)
    {
      return _kr.GetKeepsByProfileId(id);
    }

    public void Delete(int id, string creatorId)
    {
      Keep keep = GetById(id);
      if (keep.CreatorId != creatorId)
      {
        throw new Exception("not the creator");
      }
      _kr.Delete(id);
    }


  }
}