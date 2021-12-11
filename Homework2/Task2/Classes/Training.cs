class Training : ISubject
{
 public string Description { get; set; }

 private List<ISubject> _subjects = new List<ISubject>();
 public List<ISubject> Subjects 
 {
  get
  {
   return _subjects;
  }
 }

 public Training(string pString, List<ISubject> pList) 
 {
  Description = pString;
  _subjects = pList;
 }

 public void Add(ISubject subject)
 {
  _subjects.Add(subject);
 }

 public bool IsPractical()
 {
  foreach(var subject in _subjects)
  {
   if (subject is ILecture)
   { 
    return false;
   }
  }
  return true;
 }

 public Training Clone()
 {
  return new Training(Description, _subjects);
 }
}
