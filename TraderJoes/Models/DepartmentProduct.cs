namespace TraderJoes.Models
{
  public class DepartmentProduct
  {       
    public int DepartmentProductId { get; set; }
    public int ProductId { get; set; }
    public int DepartmentId { get; set; }
    public virtual Product Product { get; set; }
    public virtual Department Department { get; set; }
  }
}