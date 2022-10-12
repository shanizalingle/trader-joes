using System.Collections.Generic;
using System;

namespace Template.Models
{
  public class PlaceHolder2
  {
    public PlaceHolder2()
    {
      this.JoinEntities = new HashSet<PlaceHolderPlaceHolder2>();
    }

    public int PlaceHolder2Id { get; set; }
    public string Description { get; set; }
    public virtual ICollection<PlaceHolderPlaceHolder2> JoinEntities { get;}
  }
}