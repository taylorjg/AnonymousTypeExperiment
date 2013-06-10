
## Anonymous Type Experiment

This little project takes a brief look at the Equals and GetHashCode methods that the C#
compiler generates for anonymous types. I used
[Telerik's JustDecompile](http://www.telerik.com/products/decompiler.aspx)
to view these generated methods.

Given this anonymous type:

``` C#
var object1 = new {Prop1 = "ABC", Prop2 = 123};
var object2 = new {Prop1 = "ABC", Prop2 = 123};
var actual = object1.Equals(object2);
Assert.That(actual, Is.True);
```

the compiler generates a class with 2 type parameters:

``` C#
internal sealed class <>f__AnonymousType0<<Prop1>j__TPar, <Prop2>j__TPar>
{
    // ...
}
```

The class name is <>f__AnonymousType0 and the type parameter names are <Prop1>j__TPar and <Prop2>j__TPar.

The Equals method looks like this:

``` C#
public override bool Equals(object value)
{
    bool flag;
    <>f__AnonymousType0<<Prop1>j__TPar, <Prop2>j__TPar> <>f_AnonymousType0 = value as <>f__AnonymousType0<<Prop1>j__TPar, <Prop2>j__TPar>;
    if (<>f_AnonymousType0 == null || !EqualityComparer<<Prop1>j__TPar>.Default.Equals(this.<Prop1>i__Field, <>f_AnonymousType0.<Prop1>i__Field))
    {
        flag = false;
    }
    else
    {
        flag = EqualityComparer<<Prop2>j__TPar>.Default.Equals(this.<Prop2>i__Field, <>f_AnonymousType0.<Prop2>i__Field);
    }
    bool flag1 = flag;
    return flag1;
}
```

The GetHashCode method looks like this:


``` C#
public override int GetHashCode()
{
    int hashCode = -1966436625;
    hashCode = -1521134295 * hashCode + EqualityComparer<<Prop1>j__TPar>.Default.GetHashCode(this.<Prop1>i__Field);
    hashCode = -1521134295 * hashCode + EqualityComparer<<Prop2>j__TPar>.Default.GetHashCode(this.<Prop2>i__Field);
    int num = hashCode;
    return num;
}
```
