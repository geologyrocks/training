using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Injectables
{
    public class MyRepos : IRepos
    {
        public string AllData => "Data from MyRepos";
    }
}
