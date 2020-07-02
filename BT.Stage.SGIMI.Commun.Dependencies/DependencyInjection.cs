using BT.Stage.SGIMI.BusinessLogic.Implementation;
using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.DataAccess.Implementation;
using BT.Stage.SGIMI.DataAccess.Implementation.DatabaseConnection;
using BT.Stage.SGIMI.DataAccess.Interface;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
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


            unityContainer.RegisterType<ISGIMIDbContext, SGIMIDbContext>();
          

            unityContainer.RegisterType<IFournisseurAdapter, FournisseurAdapter>();
            unityContainer.RegisterType<IFournisseurRepository, FournisseurRepository>();
            unityContainer.RegisterType<IMaterielAdapter, MaterielAdapter>();
            unityContainer.RegisterType<IMaterielRepository, MaterielRepository>();
            unityContainer.RegisterType<IReclamationAdapter, ReclamationAdapter>();
            unityContainer.RegisterType<IReclamationRepository, ReclamationRepository>();
            unityContainer.RegisterType<ISocieteTierceAdapter, SocieteTierceAdapter>();
            unityContainer.RegisterType<ISocieteTierceRepository, SocieteTierceRepository>();
            unityContainer.RegisterType<IInterventionAdapter, InterventionAdapter>();
            unityContainer.RegisterType<IInterventionRepository, InterventionRepository>();
            unityContainer.RegisterType<IUniteGestionAdapter, UniteGestionAdapter>();
            unityContainer.RegisterType<IUniteGestionRepository, UniteGestionRepository>();

            unityContainer.RegisterType<IAvisAdapter, AvisAdapter>();
            unityContainer.RegisterType<IAvisRepository, AvisRepository>();

            return unityContainer;
        } 
    }
}
