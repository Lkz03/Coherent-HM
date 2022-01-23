namespace Task1.Classes
{
 class GenericDiagonalMatrix<T>
 {
  private T[] MatrixArray { get; set; }

  public T this[int i, int j]
  {
   get
   {
    if (i < 0 || j < 0 ||
        i >= Size || j >= Size)
    {
     throw new IndexOutOfRangeException();
    }
    if (i != j)
    {
     return default(T);
    }
    return MatrixArray[i];
   }

   set
   {
    if (!EqualityComparer<T>.Default.Equals(value, MatrixArray[i]) &&
        !EqualityComparer<T>.Default.Equals(value, default(T)))
    {
     T tempOldElement = MatrixArray[i];
     MatrixArray[i] = value;
     OnElementChanged?.Invoke(this, new MatrixElementChangedEventArgs<T>(tempOldElement, value, i));
    }
   }
  }

  internal GenericDiagonalMatrix(params T[] diagonalMatrixElements)
  {
   if (diagonalMatrixElements == null)
   {
    Size = 0;
   }
   else
   {
    MatrixArray = diagonalMatrixElements;
    for (int i = 0; i < diagonalMatrixElements.Length; i++)
    {
     this[i, i] = diagonalMatrixElements[i];
    }
    Size = diagonalMatrixElements.Length;
   }
  }

  private readonly int _size;
  public int Size { get => _size; init => _size = value; }

  public GenericDiagonalMatrix(int size)
  {
   if (size < 0)
   {
    throw new ArgumentException();
   }
   Size = size;
   MatrixArray = new T[size];
  }

  public delegate void ElementChanged(object sender, EventArgs args);

  public event ElementChanged OnElementChanged;
 }
}
