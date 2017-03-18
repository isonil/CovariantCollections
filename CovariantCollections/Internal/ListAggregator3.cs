using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections.Internal
{
    
public abstract class ListAggregator<T1, T2, T3> : ListAggregator<T1, T2>, IList<T3>, ICollection<T3>, IEnumerable<T3>, IEnumerable
    where T2 : T1
    where T3 : T2
{
    bool ICollection<T3>.IsReadOnly { get { return T3_IsReadOnly; } }
    int ICollection<T3>.Count { get { return T3_Count; } }

    T3 IList<T3>.this[int index]
    {
        get { return T3_Get(index); }
        set { T3_Set(index, value); }
    }

    protected abstract bool T3_IsReadOnly { get; }
    protected abstract int T3_Count { get; }

    IEnumerator<T3> IEnumerable<T3>.GetEnumerator()
    {
        return T3_GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return T3_GetEnumerator();
    }

    bool ICollection<T3>.Remove(T3 item)
    {
        return T3_Remove(item);
    }

    void ICollection<T3>.CopyTo(T3[] array, int arrayIndex)
    {
        T3_CopyTo(array, arrayIndex);
    }

    bool ICollection<T3>.Contains(T3 item)
    {
        return T3_Contains(item);
    }

    void ICollection<T3>.Clear()
    {
        T3_Clear();
    }

    void ICollection<T3>.Add(T3 item)
    {
        T3_Add(item);
    }

    void IList<T3>.RemoveAt(int index)
    {
        T3_RemoveAt(index);
    }

    void IList<T3>.Insert(int index, T3 item)
    {
        T3_Insert(index, item);
    }

    int IList<T3>.IndexOf(T3 item)
    {
        return T3_IndexOf(item);
    }

    protected abstract IEnumerator<T3> T3_GetEnumerator();
    protected abstract bool T3_Remove(T3 item);
    protected abstract void T3_CopyTo(T3[] array, int arrayIndex);
    protected abstract bool T3_Contains(T3 item);
    protected abstract void T3_Clear();
    protected abstract void T3_Add(T3 item);
    protected abstract T3 T3_Get(int index);
    protected abstract void T3_Set(int index, T3 item);
    protected abstract void T3_RemoveAt(int index);
    protected abstract void T3_Insert(int index, T3 item);
    protected abstract int T3_IndexOf(T3 item);
}

}
