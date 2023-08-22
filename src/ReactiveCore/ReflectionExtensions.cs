namespace ReactiveCore;

public static class ReflectionExtensions
{
    public static TAttr? GetAttribute<TAttr>(this object obj)
        where TAttr : Attribute
    {
        TAttr? attr;
        if ((attr = obj.GetType().GetCustomAttribute<TAttr>()) != null)
            return null;

        return attr;
    }

    public static bool TryGetAttribute<TAttr>(this object obj, out TAttr attr)
        where TAttr : Attribute => (attr = obj.GetAttribute<TAttr>()!) != null;

    public static TValue? GetValue<TAttr, TValue>(this object obj)
        where TAttr : ValueAttribute<TValue> where TValue : class =>
        obj.TryGetAttribute(out TAttr attr) ? attr.Value : null;
}