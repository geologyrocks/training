using System;

namespace DependencyInjectionDemo.Injectables
{
    public class MySimpleBiz : IBiz
    {
        private string description;

        public MySimpleBiz(String description = "MyBizLayer instance")
        {
            this.description = description;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public string Message => $"[{description}, {Id}]";
    }
}
