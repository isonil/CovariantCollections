using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections.Internal
{

public abstract class ListAggregator<T1> : IList<T1>, ICollection<T1>, IEnumerable<T1>, IEnumerable
{
    bool ICollection<T1>.IsReadOnly { get { return T1_IsReadOnly; } }
    int ICollection<T1>.Count { get { return T1_Count; } }

    T1 IList<T1>.this[int index]
    {
        get { return T1_Get(index); }
        set { T1_Set(index, value); }
    }

    protected abstract bool T1_IsReadOnly { get; }
    protected abstract int T1_Count { get; }

    IEnumerator<T1> IEnumerable<T1>.GetEnumerator()
    {
        return T1_GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return T1_GetEnumerator();
    }

    bool ICollection<T1>.Remove(T1 item)
    {
        return T1_Remove(item);
    }

    void ICollection<T1>.CopyTo(T1[] array, int arrayIndex)
    {
        T1_CopyTo(array, arrayIndex);
    }

    bool ICollection<T1>.Contains(T1 item)
    {
        return T1_Contains(item);
    }

    void ICollection<T1>.Clear()
    {
        T1_Clear();
    }

    void ICollection<T1>.Add(T1 item)
    {
        T1_Add(item);
    }

    void IList<T1>.RemoveAt(int index)
    {
        T1_RemoveAt(index);
    }

    void IList<T1>.Insert(int index, T1 item)
    {
        T1_Insert(index, item);
    }

    int IList<T1>.IndexOf(T1 item)
    {
        return T1_IndexOf(item);
    }

    protected abstract IEnumerator<T1> T1_GetEnumerator();
    protected abstract bool T1_Remove(T1 item);
    protected abstract void T1_CopyTo(T1[] array, int arrayIndex);
    protected abstract bool T1_Contains(T1 item);
    protected abstract void T1_Clear();
    protected abstract void T1_Add(T1 item);
    protected abstract T1 T1_Get(int index);
    protected abstract void T1_Set(int index, T1 item);
    protected abstract void T1_RemoveAt(int index);
    protected abstract void T1_Insert(int index, T1 item);
    protected abstract int T1_IndexOf(T1 item);
}

}
