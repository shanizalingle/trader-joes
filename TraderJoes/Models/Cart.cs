using System.Collections.Generic;

namespace TraderJoes.Models
{
  public class Cart
  {
    public Cart()
    {
      this.Products = new HashSet<Product>();
    }

    public int CartId { get; set; }
    public virtual ICollection<Product> Products { get; set; }
  }
}