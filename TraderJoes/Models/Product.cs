using System.Collections.Generic;
using System;

namespace TraderJoes.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinEntities = new HashSet<DepartmentProduct>();
    }

    public int ProductId { get; set; }
    public string Description { get; set; }
    public virtual ICollection<DepartmentProduct> JoinEntities { get;}
  }
}