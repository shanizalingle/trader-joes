using System.Collections.Generic;

namespace Template.Models
{
  public class PlaceHolder
  {
    public PlaceHolder()
    {
      this.JoinEntities = new HashSet<PlaceHolderPlaceHolder2>();
    }

    public int PlaceHolderId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<PlaceHolderPlaceHolder2> JoinEntities { get; set; }
  }
}