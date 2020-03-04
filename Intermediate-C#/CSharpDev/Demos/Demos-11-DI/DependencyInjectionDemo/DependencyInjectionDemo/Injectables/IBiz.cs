using System;

namespace DependencyInjectionDemo.Injectables
{
    public interface IBiz
    {
        Guid Id { get; }
        String Message { get; }
    }
}
