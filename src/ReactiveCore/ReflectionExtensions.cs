namespace ReactiveCore;

public static class ReflectionExtensions
{
    public static TAttr? GetAttribute<TAttr>(this Type type)
        where TAttr : Attribute
    {
        TAttr? attr;
        if ((attr = type.GetCustomAttribute<TAttr>()) == null)
            return null;

        return attr;
    }

    public static TAttr? GetAttribute<TAttr>(this object obj) =>
        obj.GetType().GetAttribute<TAttr>();

    public static bool TryGetAttribute<TAttr>(this Type type, out TAttr attr)
        where TAttr : Attribute => (attr = type.GetAttribute<TAttr>()!) != null;

    public static bool TryGetAttribute<TAttr>(this object obj, out TAttr attr)
        where TAttr : Attribute => obj.GetType().TryGetAttribute(out attr);

    public static TValue? GetValue<TAttr, TValue>(this Type type)
        where TAttr : ValueAttribute<TValue> where TValue : class =>
        type.TryGetAttribute(out TAttr attr) ? attr.Value : null;

    public static TValue? GetValue<TAttr, TValue>(this object obj)
        where TAttr : ValueAttribute<TValue> where TValue : class =>
        obj.TryGetAttribute(out TAttr attr) ? attr.Value : null;

    public static bool IsNulL<T>(this T obj)
        where T : struct => obj.Equals(default(T));
}