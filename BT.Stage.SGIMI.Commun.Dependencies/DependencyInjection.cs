using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BT.Stage.SGIMI.Commun.Dependencies
{
    public static class DependencyInjection
    {
        public static UnityContainer DependencyResolve()
        {
            UnityContainer unityContainer = new UnityContainer();
            // e.g. container.RegisterType<ITestService, TestService>();

            return unityContainer;
        } 
    }
}
