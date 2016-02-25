using System;
using Microsoft.Practices.Unity;
using HelloLists.Service;
using HelloLists.ContentResoler;
using HelloLists.ContentResolver;
using HelloTasks.Service;

namespace HelloLists.Base
{
    public class DependencyFactory
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            UnityContainer container = new UnityContainer();

            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //if (section != null)
            //{
            //    section.Configure(container);
            //}

            // Register repositories
            container.RegisterType<IListStorage, ListStorage>();
            container.RegisterType<ITaskStorage, TaskStorage>();

            // Register services
            container.RegisterType<IListService, ListService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<ISyncService, SyncService>();

            //Register adapters
            container.RegisterType(typeof(IDataAdapter<>), typeof(DataAdapter<>));
            container.RegisterType(typeof (ISyncDataProviderService), typeof (SyncDataProviderService));
            container.RegisterType(typeof(ISettings), typeof(Settings));

            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T resolved;
            
            try
            {
                resolved = Container.Resolve<T>();
            }
            catch (Exception e)
            {
                resolved = default(T);
            }
            return resolved;
        }
    }
}
