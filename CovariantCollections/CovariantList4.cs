using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CovariantCollections
{

/// <summary>
/// Covariant list of T4.
/// Allows conversions to: List&lt;T4&gt;, IList&lt;T4&gt;, IList&lt;T3&gt;, IList&lt;T2&gt;, IList&lt;T1&gt;
/// </summary>
/// <typeparam name="T1">Any type which inherits from T2.</typeparam>
/// <typeparam name="T2">Any type which inherits from T3.</typeparam>
/// <typeparam name="T3">Any type which inherits from T4.</typeparam>
/// <typeparam name="T4">The main type.</typeparam>
public class CovariantList<T1, T2, T3, T4> : Internal.ListAggregator<T1, T2, T3, T4>, IList<T4>, ICollection<T4>, IList, ICollection, IEnumerable<T4>, IEnumerable
    where T2 : T1
    where T3 : T2
    where T4 : T3
{
    private readonly List<T4> list;

    //List<T4> properties
    public int Capacity { get { return list.Capacity; } }
    public int Count { get { return list.Count; } }

    public T4 this[int index]
    {
        get { return list[index]; }
        set { list[index] = value; }
    }

    //ICollection properties
    bool ICollection.IsSynchronized { get { return ((ICollection)list).IsSynchronized; } }
    object ICollection.SyncRoot { get { return ((ICollection)list).SyncRoot; } }

    //IList properties
    bool IList.IsFixedSize { get { return false; } }
    bool IList.IsReadOnly { get { return false; } }

    object IList.this[int index]
    {
        get { return list[index]; }
        set { ((IList)list)[index] = value; }
    }

    //Inherited IList<T1> properties
    protected override bool T1_IsReadOnly { get { return false; } }
    protected override int T1_Count { get { return list.Count; } }

    //Inherited IList<T2> properties
    protected override bool T2_IsReadOnly { get { return false; } }
    protected override int T2_Count { get { return list.Count; } }

    //Inherited IList<T3> properties
    protected override bool T3_IsReadOnly { get { return false; } }
    protected override int T3_Count { get { return list.Count; } }

    //Inherited IList<T4> properties
    protected override bool T4_IsReadOnly { get { return false; } }
    protected override int T4_Count { get { return list.Count; } }

    public CovariantList()
    {
        list = new List<T4>();
    }

    public CovariantList(IEnumerable<T4> collection)
    {
        list = new List<T4>(collection);
    }

    public CovariantList(int capacity)
    {
        list = new List<T4>(capacity);
    }

    public CovariantList(List<T4> list)
    {
        if (list == null)
            throw new ArgumentNullException("list");

        this.list = list;
    }

    public static implicit operator CovariantList<T1, T2, T3, T4>(List<T4> list)
    {
        if (list == null)
            return null;

        return new CovariantList<T1, T2, T3, T4>(list);
    }

    public static implicit operator List<T4>(CovariantList<T1, T2, T3, T4> covariantList)
    {
        if (covariantList == null)
            return null;

        return covariantList.list;
    }

    //List<T4> methods
    public void Add(T4 item)
    {
        list.Add(item);
    }

    public void AddRange(IEnumerable<T4> collection)
    {
        list.AddRange(collection);
    }

    public ReadOnlyCollection<T4> AsReadOnly()
    {
        return list.AsReadOnly();
    }

    public int BinarySearch(T4 item)
    {
        return list.BinarySearch(item);
    }

    public int BinarySearch(T4 item, IComparer<T4> comparer)
    {
        return list.BinarySearch(item, comparer);
    }

    public int BinarySearch(int index, int count, T4 item, IComparer<T4> comparer)
    {
        return list.BinarySearch(index, count, item, comparer);
    }

    public void Clear()
    {
        list.Clear();
    }

    public bool Contains(T4 item)
    {
        return list.Contains(item);
    }

    public List<TOutput> ConvertAll<TOutput>(Converter<T4, TOutput> converter)
    {
        return list.ConvertAll(converter);
    }

    public void CopyTo(T4[] array)
    {
        list.CopyTo(array);
    }

    public void CopyTo(T4[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public void CopyTo(int index, T4[] array, int arrayIndex, int count)
    {
        list.CopyTo(index, array, arrayIndex, count);
    }

    public bool Exists(Predicate<T4> match)
    {
        return list.Exists(match);
    }

    public T4 Find(Predicate<T4> match)
    {
        return list.Find(match);
    }

    public List<T4> FindAll(Predicate<T4> match)
    {
        return list.FindAll(match);
    }

    public int FindIndex(Predicate<T4> match)
    {
        return list.FindIndex(match);
    }

    public int FindIndex(int startIndex, Predicate<T4> match)
    {
        return list.FindIndex(startIndex, match);
    }

    public int FindIndex(int startIndex, int count, Predicate<T4> match)
    {
        return list.FindIndex(startIndex, count, match);
    }

    public T4 FindLast(Predicate<T4> match)
    {
        return list.FindLast(match);
    }

    public int FindLastIndex(Predicate<T4> match)
    {
        return list.FindLastIndex(match);
    }

    public int FindLastIndex(int startIndex, Predicate<T4> match)
    {
        return list.FindLastIndex(startIndex, match);
    }

    public int FindLastIndex(int startIndex, int count, Predicate<T4> match)
    {
        return list.FindLastIndex(startIndex, count, match);
    }

    public void ForEach(Action<T4> action)
    {
        list.ForEach(action);
    }

    public List<T4>.Enumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public List<T4> GetRange(int index, int count)
    {
        return list.GetRange(index, count);
    }

    public int IndexOf(T4 item)
    {
        return list.IndexOf(item);
    }

    public int IndexOf(T4 item, int index)
    {
        return list.IndexOf(item, index);
    }

    public int IndexOf(T4 item, int index, int count)
    {
        return list.IndexOf(item, index, count);
    }

    public void Insert(int index, T4 item)
    {
        list.Insert(index, item);
    }

    public void InsertRange(int index, IEnumerable<T4> collection)
    {
        list.InsertRange(index, collection);
    }

    public int LastIndexOf(T4 item)
    {
        return list.LastIndexOf(item);
    }

    public int LastIndexOf(T4 item, int index)
    {
        return list.LastIndexOf(item, index);
    }

    public int LastIndexOf(T4 item, int index, int count)
    {
        return list.LastIndexOf(item, index, count);
    }

    public bool Remove(T4 item)
    {
        return list.Remove(item);
    }

    public int RemoveAll(Predicate<T4> match)
    {
        return list.RemoveAll(match);
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    public void RemoveRange(int index, int count)
    {
        list.RemoveRange(index, count);
    }

    public void Reverse()
    {
        list.Reverse();
    }

    public void Reverse(int index, int count)
    {
        list.Reverse(index, count);
    }

    public void Sort()
    {
        list.Sort();
    }

    public void Sort(Comparison<T4> comparison)
    {
        list.Sort(comparison);
    }

    public void Sort(IComparer<T4> comparer)
    {
        list.Sort(comparer);
    }

    public void Sort(int index, int count, IComparer<T4> comparer)
    {
        list.Sort(index, count, comparer);
    }

    public T4[] ToArray()
    {
        return list.ToArray();
    }

    public void TrimExcess()
    {
        list.TrimExcess();
    }

    public bool TrueForAll(Predicate<T4> match)
    {
        return list.TrueForAll(match);
    }

    //ICollection methods
    void ICollection.CopyTo(Array array, int arrayIndex)
    {
        ((ICollection)list).CopyTo(array, arrayIndex);
    }

    //IList methods
    void IList.Remove(object item)
    {
        ((IList)list).Remove(item);
    }

    void IList.Insert(int index, object item)
    {
        ((IList)list).Insert(index, item);
    }

    int IList.IndexOf(object item)
    {
        return ((IList)list).IndexOf(item);
    }

    bool IList.Contains(object item)
    {
        return ((IList)list).Contains(item);
    }

    int IList.Add(object item)
    {
        return ((IList)list).Add(item);
    }

    //Inherited IList<T1> methods
    protected override IEnumerator<T1> T1_GetEnumerator()
    {
        return list.Cast<T1>().GetEnumerator();
    }

    protected override bool T1_Remove(T1 item)
    {
        int index = ((IList)list).IndexOf(item);

        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    protected override void T1_CopyTo(T1[] array, int arrayIndex)
    {
        int count = list.Count;

        for (int i = 0; i < count; i++)
        {
            array[arrayIndex + i] = list[i];
        }
    }

    protected override bool T1_Contains(T1 item)
    {
        return ((IList)list).Contains(item);
    }

    protected override void T1_Clear()
    {
        list.Clear();
    }

    protected override void T1_Add(T1 item)
    {
        ((IList)list).Add(item);
    }

    protected override T1 T1_Get(int index)
    {
        return list[index];
    }

    protected override void T1_Set(int index, T1 item)
    {
        ((IList)list)[index] = item;
    }

    protected override void T1_RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    protected override void T1_Insert(int index, T1 item)
    {
        ((IList)list).Insert(index, item);
    }

    protected override int T1_IndexOf(T1 item)
    {
        return ((IList)list).IndexOf(item);
    }

    //Inherited IList<T2> methods
    protected override IEnumerator<T2> T2_GetEnumerator()
    {
        return list.Cast<T2>().GetEnumerator();
    }

    protected override bool T2_Remove(T2 item)
    {
        int index = ((IList)list).IndexOf(item);

        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    protected override void T2_CopyTo(T2[] array, int arrayIndex)
    {
        int count = list.Count;

        for (int i = 0; i < count; i++)
        {
            array[arrayIndex + i] = list[i];
        }
    }

    protected override bool T2_Contains(T2 item)
    {
        return ((IList)list).Contains(item);
    }

    protected override void T2_Clear()
    {
        list.Clear();
    }

    protected override void T2_Add(T2 item)
    {
        ((IList)list).Add(item);
    }

    protected override T2 T2_Get(int index)
    {
        return list[index];
    }

    protected override void T2_Set(int index, T2 item)
    {
        ((IList)list)[index] = item;
    }

    protected override void T2_RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    protected override void T2_Insert(int index, T2 item)
    {
        ((IList)list).Insert(index, item);
    }

    protected override int T2_IndexOf(T2 item)
    {
        return ((IList)list).IndexOf(item);
    }

    //Inherited IList<T3> methods
    protected override IEnumerator<T3> T3_GetEnumerator()
    {
        return list.Cast<T3>().GetEnumerator();
    }

    protected override bool T3_Remove(T3 item)
    {
        int index = ((IList)list).IndexOf(item);

        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    protected override void T3_CopyTo(T3[] array, int arrayIndex)
    {
        int count = list.Count;

        for (int i = 0; i < count; i++)
        {
            array[arrayIndex + i] = list[i];
        }
    }

    protected override bool T3_Contains(T3 item)
    {
        return ((IList)list).Contains(item);
    }

    protected override void T3_Clear()
    {
        list.Clear();
    }

    protected override void T3_Add(T3 item)
    {
        ((IList)list).Add(item);
    }

    protected override T3 T3_Get(int index)
    {
        return list[index];
    }

    protected override void T3_Set(int index, T3 item)
    {
        ((IList)list)[index] = item;
    }

    protected override void T3_RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    protected override void T3_Insert(int index, T3 item)
    {
        ((IList)list).Insert(index, item);
    }

    protected override int T3_IndexOf(T3 item)
    {
        return ((IList)list).IndexOf(item);
    }

    //Inherited IList<T4> methods
    protected override IEnumerator<T4> T4_GetEnumerator()
    {
        return list.GetEnumerator();
    }

    protected override bool T4_Remove(T4 item)
    {
        return list.Remove(item);
    }

    protected override void T4_CopyTo(T4[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    protected override bool T4_Contains(T4 item)
    {
        return list.Contains(item);
    }

    protected override void T4_Clear()
    {
        list.Clear();
    }

    protected override void T4_Add(T4 item)
    {
        list.Add(item);
    }

    protected override T4 T4_Get(int index)
    {
        return list[index];
    }

    protected override void T4_Set(int index, T4 item)
    {
        list[index] = item;
    }

    protected override void T4_RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    protected override void T4_Insert(int index, T4 item)
    {
        list.Insert(index, item);
    }

    protected override int T4_IndexOf(T4 item)
    {
        return list.IndexOf(item);
    }
}

}
