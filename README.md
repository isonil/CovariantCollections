<p align="center">
  <img src="https://user-images.githubusercontent.com/8492408/124278955-339cb100-db47-11eb-8d97-9bb068dbf31c.png">
</p>

# .NET
Note: from .NET 4.5 onwards there is IReadOnlyList\<out T> and IReadOnlyCollection\<out T> which are both covariant, so there's no reason to use this project. This project is aimed at older versions of .NET

# About
C# type-safe List\<T> wrapper which can be cast to ILists of any (known) subtype.

The goal was to create a collection which could be cast to any collection whose elements inherit from the main type without any extra memory allocations.

Let's say we want to make the following code work:

```C#
class Foo { }
class Bar : Foo { }

var myCollection = SomeCollectionOfBars;

Test1(myCollection);
Test2(myCollection);

void Test1(IList<Bar> bars)
{
}

void Test2(IList<Foo> foos)
{
}
```

This could simply be achieved by casting our collection and creating a copy like so:

```C#
Test1(myCollection);
Test2(myCollection.Cast<Foo>().ToList());
```

However, this means we need to copy the whole list which in some cases can be too slow.

Another approach is to use IEnumerables:

```C#
Test1(myCollection);
Test2(myCollection.Cast<Foo>());

void Test1(IEnumerable<Bar> bars)
{
}

void Test2(IEnumerable<Foo> foos)
{
}
```

However, this means that we can no longer access the elements in random order efficiently.

With CovariantCollections this is possible and doesn't incur any copies:

```C#
var myCollection = new CovariantList<Foo, Bar>();

Test1(myCollection);
Test2(myCollection);
```

CovariantList has the same methods as List of the last given type (e.g. CovariantList\<T1, T2, T3, T4, T5> has the same methods as List\<T5>). However, it can be cast to IList\<> or ICollection\<> of any of the given types.

For example CovariantList\<T1, T2, T3> can be cast to:
List\<T3>, IList\<T3>, IList\<T1>, ICollection\<T2>, IEnumerable\<T1>, and so on.

Another example:
```C#
class A { }
class B : A { }
class C : B { }

IList<C> list = new CovariantList<A, B, C>();
Test(list);

void Test(IList<C> list)
{
  Test1((IList<A>)list); // OK
  Test2((IList<B>)list); // OK
}

void Test1(IList<A> list)
{
}

void Test2(IList<B> list)
{
}
```
