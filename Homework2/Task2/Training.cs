class Training
{
 public string Description { get; private set; }
 private PracticalLesson[] _practicalLessons;
 private Lecture[] _lectures;

 public Lecture[] Lectures
 {
  get
  {
   return _lectures;
  }

  private set
  {
   _lectures = new Lecture[value.Length];
   for (int i = 0; i < value.Length; i++)
   {
    _lectures[i] = value[i];
   }
  }
 }
 public PracticalLesson[] PracticalLessons
 {
  get
  {
   return _practicalLessons;
  }

  private set
  {
   _practicalLessons = new PracticalLesson[value.Length];
   for (int i = 0; i < value.Length; i++)
   {
    _practicalLessons[i] = value[i];
   }
  }
 }

 public Training(PracticalLesson[] pPracticalLessons, Lecture[] pLectures)
 {
  Lectures = pLectures;
  PracticalLessons = pPracticalLessons;
 }

 // should I use interfaces or list instead of Array.Resize ? What is better performance wise ?
 public void Add(PracticalLesson pPracticalLesson)
 {
  Array.Resize(ref _practicalLessons, _practicalLessons.Length);
  _practicalLessons[_practicalLessons.Length] = pPracticalLesson;
 }
 public void Add(Lecture pLecture)
 {
  Array.Resize(ref _lectures, _lectures.Length);
  _lectures[_lectures.Length] = pLecture;
 }

 public bool IsPractical()
 {
  return _lectures == null ? true : false;
 }

 
}
