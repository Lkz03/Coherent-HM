using System.Text;
using System.Reflection;
using System.Text.Json;
using Attributes;

namespace Task1.Classes
{
 public class Logger
 {
  public string JSONName { get; private set; }

  public Logger(string name) => JSONName = name;

  public void Track<T>(params T[] objects)
  {
   List<PropertyInfo> GetTrackingProperties<T>()
   {
    List<PropertyInfo> list = new();
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

   List<FieldInfo> GetTrackingFields<T>()
   {
    List<FieldInfo> list = new();
    FieldInfo[] fieldInfos = typeof(T).GetFields();

    foreach (var field in fieldInfos)
    {
     object[] attributes = field.GetCustomAttributes(true);
     foreach (var attr in attributes)
     {
      if (attr is TrackingPropertyAttribute)
      {
       list.Add(field);
      }
     }
    }

    return list;
   }

   string GetSerializedObjectStringByPropertyList<T>(List<PropertyInfo> propertiesWithAttributes, List<FieldInfo> fieldsWithAttributes, params T[] objects)
   {
    StringBuilder sb = new StringBuilder();

    foreach (var obj in objects)
    {
     if (typeof(T).IsDefined(typeof(TrackingEntityAttribute), false))
     {
      foreach (var attribute in propertiesWithAttributes)
      {
       if (attribute.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName is not null)
       {
        sb.Append(attribute.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName);
       }
       else
       {
        sb.Append(attribute.Name);
       }
       sb.Append(":");
       sb.Append(attribute.GetValue(obj));
       sb.Append(Environment.NewLine);
      }
      foreach (var attribute in fieldsWithAttributes)
      {
       if (attribute.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName is not null)
       {
        sb.Append(attribute.GetCustomAttribute<TrackingPropertyAttribute>().PropertyName);
       }
       else
       {
        sb.Append(attribute.Name);
       }
       sb.Append(":");
       sb.Append(attribute.GetValue(obj));
       sb.Append(Environment.NewLine);
      }
     }
     else
     {
      throw new ArgumentException();
     }
    }
    return sb.ToString();
   }

   var trackingProperties = GetTrackingProperties<T>();
   var trackingFields = GetTrackingFields<T>();

   string fileName = $"{JSONName}.json";
   string jsonString = JsonSerializer.Serialize(GetSerializedObjectStringByPropertyList(trackingProperties, trackingFields, objects));
   File.WriteAllText(fileName, jsonString);

   Console.WriteLine(File.ReadAllText(fileName));
  }
 }
}
