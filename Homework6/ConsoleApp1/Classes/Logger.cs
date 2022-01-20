using System.Text;
using System.Reflection;
using System.Text.Json;
using Task1.Attributes;

namespace Task1.Classes
{
 public class Logger
 {
  public string JSONName { get; set; }

  public Logger(string name) => JSONName = name;

  // Not sure if this is exactly what the task meant
  public void Track<T>(params T[] objects)
  {
   List<PropertyInfo> GetTrackingProperties<T>()
   {
    List<PropertyInfo> list = new List<PropertyInfo>();
    PropertyInfo[] propertyInfos = typeof(T).GetProperties();
   
    foreach (var prop in propertyInfos)
    {
     object[] attributes = prop.GetCustomAttributes(true);
     foreach (var attr in attributes)
     {
      if (attr is TrackingPropertyAttribute)
      {
       list.Add(prop);
      }
     }
    }
    return list;
   }

   string GetSerializedObjectStringByPropertyList<T>(List<PropertyInfo> list, params T[] objects)
   {
    StringBuilder sb = new StringBuilder();

    foreach (var obj in objects)
    {
     if (typeof(T).IsDefined(typeof(TrackingEntityAttribute), false))
     {
      foreach (var property in list)
      {
       if (property is not null)
       {
        sb.Append(property.Name);
        sb.Append(":");
        sb.Append(property.GetValue(obj));
        sb.Append(Environment.NewLine);
       }
      }
     }
     else
     {
      throw new ArgumentException();
     }
    }
    return sb.ToString();
   }

   List<PropertyInfo> trackingProperties = GetTrackingProperties<T>();

   string fileName = $"{JSONName}.json";
   string jsonString = JsonSerializer.Serialize(GetSerializedObjectStringByPropertyList(trackingProperties, objects));
   File.WriteAllText(fileName, jsonString);

   Console.WriteLine(File.ReadAllText(fileName));
  }
 }
}
