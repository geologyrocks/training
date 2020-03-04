using Unity;
using DemoUnity.DataAccessLayer;
using DemoUnity.ServiceLayer;

namespace DemoUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment one of the following statements...
            IUnityContainer container = InitContainerSingletons();
            // IUnityContainer container = InitContainerTransients();
            // IUnityContainer container = InitContainerInstances();

            DoStuff(container);
        }

        // Register types as singletons, Unity will instantiate once, just-in-time.
        private static IUnityContainer InitContainerSingletons()
        {
            var container = new UnityContainer();
            container.RegisterSingleton<PersonService>();
            container.RegisterSingleton<IPersonRepository, PersonRepositoryStub>();
            return container;
        }

        // Register types as transients, Unity will create a new instance every time a type is resolved.
        private static IUnityContainer InitContainerTransients()
        {
            var container = new UnityContainer();
            container.RegisterType<PersonService>();
            container.RegisterType<IPersonRepository, PersonRepositoryStub>();
            return container;
        }

        // Register actual instances, which we create ourselves.
        private static IUnityContainer InitContainerInstances()
        {
            var container = new UnityContainer();

            IPersonRepository repository = new PersonRepositoryStub("Howdy2");
            container.RegisterInstance<IPersonRepository>(repository);

            PersonService service = new PersonService(repository);
            container.RegisterInstance<PersonService>(service);

            return container;
        }

        private static void DoStuff(IUnityContainer container)
        {
            System.Console.WriteLine("\nPart 1 --------------------------------------------------");
            var personService1 = container.Resolve<PersonService>();
            personService1.DoSomePersonStuff();

            System.Console.WriteLine("\nPart 2 --------------------------------------------------");
            var personService2 = container.Resolve<PersonService>();
            personService2.DoSomePersonStuff();
        }
    }
}
