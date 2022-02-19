using Attributes;

namespace Task1.Classes
{
 [TrackingEntity]
 public class DummyClass
 {
  [TrackingProperty(null)]
  public string _desc = "test_desc";
  [TrackingProperty("Attribute name field")]
  public string _name = "test_name";
  [TrackingProperty(null)]
  public string Name { get; set; }
  [TrackingProperty("Attribute description prop")]
  public string Description { get; set; }
  
  public DummyClass(string name, string desc)
  {
   Name = name;
   Description = desc;
  }
 }
}
