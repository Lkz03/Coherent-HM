using Task1.Attributes;

namespace Task1.Classes
{
 [TrackingEntity]
 public class DummyClass
 {
  [TrackingProperty]
  public string Name { get; set; }
  [TrackingProperty]
  public string Description { get; set; }
  
  public DummyClass(string name, string desc)
  {
   Name = name;
   Description = desc;
  }
 }
}
