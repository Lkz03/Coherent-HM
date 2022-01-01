using System.Text;

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
 
 // If the key is in the same octave then it has a similar tone,
 // if comparing by tones, is this enough or do I need to compare by more properties?
 public bool Equals(Key otherKey)
 {
  return otherKey.Octave == this.Octave ? true : false;
 }

 public override string ToString()
 {
  StringBuilder stringBuilder = new StringBuilder(Note + " " + Accidental + " " + Octave);

  return stringBuilder.ToString();
 }

 public int Compare(Key y)
 {
  return this.Octave == y.Octave ? 
         ( 0 ) : 
         ( this.Octave > y.Octave ? 1 : -1 );
 }
}
