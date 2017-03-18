using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections.Internal
{
    
public abstract class ListAggregator<T1, T2, T3, T4> : ListAggregator<T1, T2, T3>, IList<T4>, ICollection<T4>, IReadOnlyList<T4>, IReadOnlyCollection<T4>, IEnumerable<T4>, IEnumerable
    where T2 : T1
    where T3 : T2
    where T4 : T3
{
    bool ICollection<T4>.IsReadOnly { get { return T4_IsReadOnly; } }
    int ICollection<T4>.Count { get { return T4_Count; } }
    int IReadOnlyCollection<T4>.Count { get { return T4_Count; } }

    T4 IList<T4>.this[int index]
    {
        get { return T4_Get(index); }
        set { T4_Set(index, value); }
    }

    T4 IReadOnlyList<T4>.this[int index] { get { return T4_Get(index); } }

    protected abstract bool T4_IsReadOnly { get; }
    protected abstract int T4_Count { get; }

    IEnumerator<T4> IEnumerable<T4>.GetEnumerator()
    {
        return T4_GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return T4_GetEnumerator();
    }

    bool ICollection<T4>.Remove(T4 item)
    {
        return T4_Remove(item);
    }

    void ICollection<T4>.CopyTo(T4[] array, int arrayIndex)
    {
        T4_CopyTo(array, arrayIndex);
    }

    bool ICollection<T4>.Contains(T4 item)
    {
        return T4_Contains(item);
    }

    void ICollection<T4>.Clear()
    {
        T4_Clear();
    }

    void ICollection<T4>.Add(T4 item)
    {
        T4_Add(item);
    }

    void IList<T4>.RemoveAt(int index)
    {
        T4_RemoveAt(index);
    }

    void IList<T4>.Insert(int index, T4 item)
    {
        T4_Insert(index, item);
    }

    int IList<T4>.IndexOf(T4 item)
    {
        return T4_IndexOf(item);
    }

    protected abstract IEnumerator<T4> T4_GetEnumerator();
    protected abstract bool T4_Remove(T4 item);
    protected abstract void T4_CopyTo(T4[] array, int arrayIndex);
    protected abstract bool T4_Contains(T4 item);
    protected abstract void T4_Clear();
    protected abstract void T4_Add(T4 item);
    protected abstract T4 T4_Get(int index);
    protected abstract void T4_Set(int index, T4 item);
    protected abstract void T4_RemoveAt(int index);
    protected abstract void T4_Insert(int index, T4 item);
    protected abstract int T4_IndexOf(T4 item);
}

}
