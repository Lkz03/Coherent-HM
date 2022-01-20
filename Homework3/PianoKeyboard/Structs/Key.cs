public struct Key : IComparable
{
 public Note Note { get; init; }
 public Accidental Accidental { get; init; }
 public Octave Octave { get; init; }

 public Key(Note note, Accidental accidental, Octave octave)
 {
  Note = note;
  Accidental = accidental;
  Octave = octave;
 }
 public bool Equals(Key otherKey)
 {
  return otherKey.Octave == this.Octave;
 }

 public override string ToString()
 {
  return new string(Note + " " + Accidental + " " + Octave);
 }

 public int Compare(Key y)
 {
  return this.Octave == y.Octave ? 
         ( 0 ) : 
         ( this.Octave > y.Octave ? 1 : -1 );
 }
}
