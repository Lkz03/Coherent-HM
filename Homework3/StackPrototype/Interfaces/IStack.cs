public interface IStack<T>
{
 // Is it okey if I add additional methods(Peek(), Size()) in order to make other functions more simple ?
 T Peek();
 int Size();
 void Pop();
 void Push(T e);
 bool IsEmpty();
}
