using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections.Internal
{
    
public abstract class ListAggregator<T1, T2, T3, T4, T5> : ListAggregator<T1, T2, T3, T4>, IList<T5>, ICollection<T5>, IEnumerable<T5>, IEnumerable
    where T2 : T1
    where T3 : T2
    where T4 : T3
    where T5 : T4
{
    bool ICollection<T5>.IsReadOnly { get { return T5_IsReadOnly; } }
    int ICollection<T5>.Count { get { return T5_Count; } }

    T5 IList<T5>.this[int index]
    {
        get { return T5_Get(index); }
        set { T5_Set(index, value); }
    }

    protected abstract bool T5_IsReadOnly { get; }
    protected abstract int T5_Count { get; }

    IEnumerator<T5> IEnumerable<T5>.GetEnumerator()
    {
        return T5_GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return T5_GetEnumerator();
    }

    bool ICollection<T5>.Remove(T5 item)
    {
        return T5_Remove(item);
    }

    void ICollection<T5>.CopyTo(T5[] array, int arrayIndex)
    {
        T5_CopyTo(array, arrayIndex);
    }

    bool ICollection<T5>.Contains(T5 item)
    {
        return T5_Contains(item);
    }

    void ICollection<T5>.Clear()
    {
        T5_Clear();
    }

    void ICollection<T5>.Add(T5 item)
    {
        T5_Add(item);
    }

    void IList<T5>.RemoveAt(int index)
    {
        T5_RemoveAt(index);
    }

    void IList<T5>.Insert(int index, T5 item)
    {
        T5_Insert(index, item);
    }

    int IList<T5>.IndexOf(T5 item)
    {
        return T5_IndexOf(item);
    }

    protected abstract IEnumerator<T5> T5_GetEnumerator();
    protected abstract bool T5_Remove(T5 item);
    protected abstract void T5_CopyTo(T5[] array, int arrayIndex);
    protected abstract bool T5_Contains(T5 item);
    protected abstract void T5_Clear();
    protected abstract void T5_Add(T5 item);
    protected abstract T5 T5_Get(int index);
    protected abstract void T5_Set(int index, T5 item);
    protected abstract void T5_RemoveAt(int index);
    protected abstract void T5_Insert(int index, T5 item);
    protected abstract int T5_IndexOf(T5 item);
}

}
