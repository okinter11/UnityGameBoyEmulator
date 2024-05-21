using System;

namespace MyUtils.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class CanLoadAttribute : Attribute
    {
    }
}