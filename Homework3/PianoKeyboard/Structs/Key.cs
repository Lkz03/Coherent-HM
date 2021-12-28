using System.Text;

public struct Key : IComparable
{
 public char Note { get;  }
 public string Accidental { get; }
 public string Octave { get; }

 public Key(char note, string accidental, string octave)
 {
  Note = note;
  Accidental = accidental;
  Octave = octave;
 }
 
 // Do I only need to look if Octave is equal, seems this way in the example ?
 public bool Equals(Key otherKey)
 {
  return /*otherKey.Note == this.Note && otherKey.Accidental == this.Accidental && */otherKey.Octave == this.Octave ? true : false;
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
         ( this.Octave.Length > y.Octave.Length ? 1 : -1 );
 }
}
