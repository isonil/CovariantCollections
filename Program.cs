using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CovariantCollections
{

class Program
{
    private class C1 {}
    private class C2 : C1 {}
    private class C3 : C2 {}

    private static void Test1(IList<C1> l)
    {
        Console.WriteLine("Test1 Count: " + l.Count);
    }

    private static void Test2(ICollection<C2> c)
    {
        Console.WriteLine("Test2 Count: " + c.Count);
    }

    private static void Test3(IList<C3> l)
    {
        Console.WriteLine("Test3 Count: " + l.Count);
    }

    private static void Test4(List<C3> l)
    {
        Console.WriteLine("Test4 Count: " + l.Count);
    }

    private static void Test5(IReadOnlyCollection<C2> r)
    {
        Console.WriteLine("Test5 Count: " + r.Count);
    }

    private static void Test6(IEnumerable e)
    {
        Console.WriteLine("Test6 Count: " + ((IEnumerable<C1>)e).Count());
    }

    private static void Test7(CovariantList<C2, C2, C3> c)
    {
        Console.WriteLine("Test7 Count: " + c.Count);
    }

    static void Main(string[] args)
    {
        var covariantList = new CovariantList<C1, C2, C3>();
        covariantList.Add(new C3());

        Test1(covariantList);
        Test2(covariantList);
        Test3(covariantList);
        Test4(covariantList);
        Test5(covariantList);
        Test6(covariantList);
        Test7((List<C3>)covariantList);

        Test7(new List<C3>());

        covariantList.Add(new C3());
        Test1(covariantList);

        List<C3> list = covariantList;
        list.Add(new C3());
        Test1(covariantList);

        Console.ReadLine();
    }
}

}
