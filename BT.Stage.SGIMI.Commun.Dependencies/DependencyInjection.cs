using BT.Stage.SGIMI.BusinessLogic.Implementation;
using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.DataAccess.Implementation;
using BT.Stage.SGIMI.DataAccess.Interface;
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

            unityContainer.RegisterType<IFournisseurAdapter, FournisseurAdapter>();
            unityContainer.RegisterType<IFournisseurRepository, FournisseurRepository>();

            return unityContainer;
        } 
    }
}
