using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections.Internal
{

public abstract class ListAggregator<T1, T2> : ListAggregator<T1>, IList<T2>, ICollection<T2>, IReadOnlyList<T2>, IReadOnlyCollection<T2>, IEnumerable<T2>, IEnumerable
    where T2 : T1
{
    bool ICollection<T2>.IsReadOnly { get { return T2_IsReadOnly; } }
    int ICollection<T2>.Count { get { return T2_Count; } }
    int IReadOnlyCollection<T2>.Count { get { return T2_Count; } }

    T2 IList<T2>.this[int index]
    {
        get { return T2_Get(index); }
        set { T2_Set(index, value); }
    }

    T2 IReadOnlyList<T2>.this[int index] { get { return T2_Get(index); } }

    protected abstract bool T2_IsReadOnly { get; }
    protected abstract int T2_Count { get; }

    IEnumerator<T2> IEnumerable<T2>.GetEnumerator()
    {
        return T2_GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return T2_GetEnumerator();
    }

    bool ICollection<T2>.Remove(T2 item)
    {
        return T2_Remove(item);
    }

    void ICollection<T2>.CopyTo(T2[] array, int arrayIndex)
    {
        T2_CopyTo(array, arrayIndex);
    }

    bool ICollection<T2>.Contains(T2 item)
    {
        return T2_Contains(item);
    }

    void ICollection<T2>.Clear()
    {
        T2_Clear();
    }

    void ICollection<T2>.Add(T2 item)
    {
        T2_Add(item);
    }

    void IList<T2>.RemoveAt(int index)
    {
        T2_RemoveAt(index);
    }

    void IList<T2>.Insert(int index, T2 item)
    {
        T2_Insert(index, item);
    }

    int IList<T2>.IndexOf(T2 item)
    {
        return T2_IndexOf(item);
    }

    protected abstract IEnumerator<T2> T2_GetEnumerator();
    protected abstract bool T2_Remove(T2 item);
    protected abstract void T2_CopyTo(T2[] array, int arrayIndex);
    protected abstract bool T2_Contains(T2 item);
    protected abstract void T2_Clear();
    protected abstract void T2_Add(T2 item);
    protected abstract T2 T2_Get(int index);
    protected abstract void T2_Set(int index, T2 item);
    protected abstract void T2_RemoveAt(int index);
    protected abstract void T2_Insert(int index, T2 item);
    protected abstract int T2_IndexOf(T2 item);
}

}
