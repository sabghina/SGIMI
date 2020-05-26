using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.Data.DTO;
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
                Nature = intervention.Nature,
                Date = intervention.Date,
                Etat = intervention.Etat,
                Reclamation = intervention.Reclamation,
                ProblemeConstate = intervention.ProblemeConstate,
                TraveauxEffectues = intervention.TraveauxEffectues,
                CreatedBy = intervention.CreatedBy,
                CreatedDate = intervention.CreatedDate,
                CreatedTime = intervention.CreatedTime,
                LastUpdatedDate = intervention.LastUpdatedDate,
                LastUpdatedTime = intervention.LastUpdatedTime,
                LastUpdatedBy = intervention.LastUpdatedBy
            };
            return interventionViewModel;
        }

        public static Intervention UpdatedInterventionViewModelToUpdatedIntervention(Intervention oldIntervention,InterventionViewModel interventionViewModel, string user)
        {
            Intervention intervention = new Intervention
            {

                Id = interventionViewModel.Id,
                Type = interventionViewModel.Type,
                Nature = interventionViewModel.Nature,
                Etat = interventionViewModel.Etat,
                Reclamation = oldIntervention.Reclamation,
                ProblemeConstate = interventionViewModel.ProblemeConstate,
                TraveauxEffectues = interventionViewModel.TraveauxEffectues,
                CreatedBy = oldIntervention.CreatedBy,
                CreatedDate = oldIntervention.CreatedDate,
                CreatedTime = oldIntervention.CreatedTime,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return intervention;
        }
        public static Intervention InterventionViewModelToIntervention(InterventionViewModel interventionViewModel, string user)
        {
            Intervention intervention = new Intervention
            {
                Id = interventionViewModel.Id,
                Type = interventionViewModel.Type,
                Nature = interventionViewModel.Nature,
                Date = interventionViewModel.Date,
                Etat = interventionViewModel.Etat,
                Reclamation = interventionViewModel.Reclamation,
                ProblemeConstate = interventionViewModel.ProblemeConstate,
                TraveauxEffectues = interventionViewModel.TraveauxEffectues,
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return intervention;

        }

        public static List<InterventionReport> InterventionListToInterventionReportList(List<Intervention> interventions)
        {
            List<InterventionReport> interventionReports = new List<InterventionReport>();
            foreach (Intervention intervention in interventions)
            {
                InterventionReport interventionReport = InterventionToInterventionReport(intervention);

                interventionReports.Add(interventionReport);
            }
            return interventionReports;
        }

        public static InterventionReport InterventionToInterventionReport(Intervention intervention)
        {
            
                InterventionReport interventionReport = new InterventionReport
                {
                    Date = $"{intervention.Date}",
                    Etat = $"{ intervention.Etat}",
                    Nature = $"{intervention.Nature}",
                    Reclamation = $"{intervention.Reclamation}",
                    ProblemeConstate = $"{intervention.ProblemeConstate}",
                    TraveauxEffectues = $"{intervention.TraveauxEffectues}",
                    InterventionBy = $"{intervention.CreatedBy}" 
                    
                };

                return interventionReport;
        }
    }
}


    
