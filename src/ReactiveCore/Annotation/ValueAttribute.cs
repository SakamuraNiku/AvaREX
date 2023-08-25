namespace ReactiveCore.Annotation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ValueAttribute<T> : Attribute where T : class
{
    #region Auto Properties

    public T? Value { get; }

    #endregion

    #region Constructors

    public ValueAttribute(T? value) => Value = value;

    #endregion
}