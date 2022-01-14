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
    if (i != j)
    {
     throw new Exception();
    }
    if (!EqualityComparer<T>.Default.Equals(value, MatrixArray[i]) &&
        !EqualityComparer<T>.Default.Equals(value, default(T)))
    {
     OnElementChange?.Invoke(this, MatrixArray[i], value, i);
     MatrixArray[i] = value;
    }
    // should I throw another exception here or doing nothing is fine ?
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
    MatrixArray = new T[diagonalMatrixElements.Length];
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

  public delegate void ElementChange(object sender, T oldElement, T newElement, int indexOfOldElement);

  public event ElementChange OnElementChange;
 }
}
