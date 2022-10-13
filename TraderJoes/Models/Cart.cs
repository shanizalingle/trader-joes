using System.Collections.Generic;

namespace TraderJoes.Models
{
  public class Cart
  {
    public Cart()
    {
      this.JoinProdCart = new HashSet<ProductCart>();
    }
    public int CartId { get; set; }
    public virtual ICollection<ProductCart> JoinProdCart { get; set; }
  }
}