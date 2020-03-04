using System;

namespace DependencyInjectionDemo.Injectables
{
    public class MyComplexBiz : IBiz
    {
        private IRepos repos;

        public MyComplexBiz(IRepos repos)
        {
            this.repos = repos;
        }

        public Guid Id { get; } = Guid.NewGuid();

        public string Message => $"[{repos.AllData}, {Id}]";
    }
}
