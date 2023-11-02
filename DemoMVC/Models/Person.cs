using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models;
public class Person
{
    public string PersonID { get; set; }
    public string FullName { get; set; }
    [DataType(DataType.Date)]
    public string Address { get; set; }
    
}
