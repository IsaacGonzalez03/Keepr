using System;
using System.Collections.Generic;

namespace Keepr.Models
{
  public class Account : Profile
  {
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}