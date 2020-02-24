using BT.Stage.SGIMI.Commun.Dependencies;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BT.Stage.SGIMI.UserInterface.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = DependencyInjection.DependencyResolve();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}