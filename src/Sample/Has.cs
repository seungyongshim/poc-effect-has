using LanguageExt.Attributes;

namespace Sample;

[Typeclass("*")]
public interface Has<T>
{
    T It { get; }
}

