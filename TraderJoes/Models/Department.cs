using System.Collections.Generic;

namespace TraderJoes.Models
{
  public class Department
  {
    public Department()
    {
      this.JoinEntities = new HashSet<DepartmentProduct>();
    }

    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DepartmentProduct> JoinEntities { get; set; }
  }
}