/*
Coherent is developing a training management system. Each training consists of a set of
lectures and practical exercises. It is necessary to create classes to represent the following
entities: training, lecture, practical lesson.

All specified entities have a text description (this is an arbitrary string, possibly empty or equal
to null).

A lecture has a topic (an arbitrary string, possibly empty or equal to null), and a practical lesson
- a link to a task condition (an arbitrary string, possibly empty or equal to null) and a link to a
solution (an arbitrary string, possibly empty or equal to null).
The training should store a set of lectures and practice sessions in an internal array and have an
Add() method for adding a lecture or practice session.In addition, the training must have an
IsPractical() method - it returns true if the training contains only practical lessons.

Implement the Clone() instance method in the training class to clone the training.
*/

class Program
{
 public static void Main()
 {
  Lecture lecture = new Lecture();
  PracticalLesson practicalLesson = new PracticalLesson();
  Training training = new Training();

  training.Description = "this is training";
  lecture.Description = "this is a lecture";
  practicalLesson.Description = "this is a practical lesson";

  training.Add(lecture);
  training.Add(practicalLesson);

  foreach (var subject in training.Subjects)
  {
   Console.WriteLine(subject.Description);
  }

  if (training.IsPractical())
  {
   Console.WriteLine("Is practical");
  }
  else
  {
   Console.WriteLine("Is not practical");
  }

  Training cloneOfTraining = training.Clone();
  Console.WriteLine($"Description of the clone: {cloneOfTraining.Description}");
  training.Description = "not any more";
  Console.WriteLine($"Description of the clone: {cloneOfTraining.Description}");
 }
}