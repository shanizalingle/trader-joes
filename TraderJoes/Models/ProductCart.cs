namespace TraderJoes.Models
{
  public class ProductCart
  {       
    public int ProductCartId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public virtual Product Product { get; set; }
    public virtual  Cart Cart { get; set; }
  }
}