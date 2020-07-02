using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
   public static class AvisTranspose
    { 
        public static List<AvisViewModel> AvisListToAvisViewModelList(List<Avis> aviss)
        {
            List<AvisViewModel> avisViewModels = new List<AvisViewModel>();

            foreach (Avis avis in aviss)
            {
                AvisViewModel avisViewModel = AvisToAvisViewModel(avis);

                avisViewModels.Add(avisViewModel);
            }

            return avisViewModels;
        }

        public static AvisViewModel AvisToAvisViewModel(Avis avis)
        {
            AvisViewModel avisViewModel = new AvisViewModel
            {
                FeedBack = avis.FeedBack,
                CreatedBy =avis.CreatedBy
            };


            return avisViewModel;
        }

        public static Avis CreateAvisViewModelToAvis(AvisViewModel avisViewModel, string user)
        {
            Avis avis = new Avis
            {
                FeedBack=avisViewModel.FeedBack,
                CreatedBy = user,
              
            };
            return avis;
        }
    }
}
