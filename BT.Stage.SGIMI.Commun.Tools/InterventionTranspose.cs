using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
   public static class InterventionTranspose
    {
        public static List<InterventionViewModel> InterventionListToInterventionViewModelList(List<Intervention> interventions)
        {
            List<InterventionViewModel> interventionViewModels = new List<InterventionViewModel>();
            foreach (Intervention intervention in interventions)
            {
                InterventionViewModel interventionViewModel = InterventionToInterventionViewModel(intervention);

                interventionViewModels.Add(interventionViewModel);
            }

            return interventionViewModels;
        }
        public static InterventionViewModel InterventionToInterventionViewModel(Intervention intervention)
        {
            InterventionViewModel interventionViewModel = new InterventionViewModel
            {
                Id = intervention.Id,
                Type = intervention.Type,
                Date = intervention.Date,
                Etat = intervention.Etat,
                Reclamation = intervention.Reclamation,
                CreatedBy = intervention.CreatedBy,
                CreatedDate = intervention.CreatedDate,
                CreatedTime = intervention.CreatedTime,
                LastUpdatedDate = intervention.LastUpdatedDate,
                LastUpdatedTime = intervention.LastUpdatedTime,
                LastUpdatedBy = intervention.LastUpdatedBy
            };
            return interventionViewModel;
        }

        public static Intervention InterventionViewModelToIntervention(InterventionViewModel interventionViewModel, string user)
        {
            Intervention intervention = new Intervention
            {
                Id = interventionViewModel.Id,
                Type = interventionViewModel.Type,
                Date = interventionViewModel.Date,
                Etat = interventionViewModel.Etat,
                Reclamation = interventionViewModel.Reclamation,
                CreatedBy = user
            };
            return intervention;
        }

        public static Intervention UpdatedInterventionViewModelToUpdatedIntervention(int id, InterventionViewModel interventionViewModel, string user)
        {
            throw new NotImplementedException();
        }
    }
}

    
