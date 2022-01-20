/*
 Task 1.Create the following set of types:
• • The [TrackingEntity] attribute, which can be applied to a class or structure.
• • The [TrackingProperty] attribute, which can be applied to a field or property and
has its own PropertyName.
• The Logger class with the Track() method that takes an arbitrary object as a parameter.
If this object has the [TrackingEntity] attribute, then the method writes to the JSON
file as a JSON object the values of those instance properties and fields of the object that
are marked with the [TrackingProperty] attribute. Values are captured as
"name:value" pairs, where "name" is taken from the [TrackingProperty] attribute. If
the name is not specified there (empty), then the name of the property or field to which
the [TrackingProperty] attribute is applied is taken. The name of the JSON file itself
is specified as a constructor parameter of the Loggerclass.
Place the generated types in a separate class library. In a console application, connect this class
library and test the work of types from it.
 */

using Task1.Classes;

public class Program
{
 public static void Main()
 {
  DummyClass[] objects = { new DummyClass("test1name", "test1desc"),
                           new DummyClass("test2name", "test2desc"),
                           new DummyClass("test3name", "test3desc")};

  Logger logger = new Logger("LoggerName");

  logger.Track(objects);
 }
}