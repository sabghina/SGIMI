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
        public static List<InterventionViewModel> InterventionListToInterventionViewModelList(List<Intervention> interventions, List<Reclamation> reclamations)
        {
            List<InterventionViewModel> interventionViewModels = new List<InterventionViewModel>();
            foreach (Intervention intervention in interventions)
            {
                foreach (Reclamation reclamation in reclamations)
                {
                    if (intervention.Reclamation == reclamation.Id)
                    {
                        InterventionViewModel interventionViewModel = InterventionToInterventionViewModel(intervention, reclamation);
                        interventionViewModels.Add(interventionViewModel);
                    }
                }
            }
            return interventionViewModels;
        }

        public static InterventionViewModel InterventionToInterventionViewModel(Intervention intervention, Reclamation reclamation)
        {
            InterventionViewModel interventionViewModel = new InterventionViewModel
            {
                Id = intervention.Id,
                Type = intervention.Type,
                Nature = intervention.Nature,
                Etat = intervention.Etat,
                Reclamation = reclamation.Probleme,
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
        public static Intervention CreateInterventionViewModelToIntervention(CreateInterventionViewModel createInterventionViewModel, string user)
        {
            Intervention intervention = new Intervention
            {
                Id = createInterventionViewModel.Id,
                Type = createInterventionViewModel.Type,
                Nature = createInterventionViewModel.Nature,
                Etat = "En cours",
                Reclamation = createInterventionViewModel.Reclamation,
                ProblemeConstate = createInterventionViewModel.ProblemeConstate,
                TraveauxEffectues = createInterventionViewModel.TraveauxEffectues,
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return intervention;
        }
        public static CreateInterventionViewModel InterventionToCreateInterventionViewModel(Intervention intervention, Reclamation reclamation)
        {
            CreateInterventionViewModel createInterventionViewModel = new CreateInterventionViewModel
            {
                Id = intervention.Id,
                Type = intervention.Type,
                Nature = intervention.Nature,
                Etat = intervention.Etat,
                Reclamation = reclamation.Id,
                ProblemeConstate = intervention.ProblemeConstate,
                TraveauxEffectues = intervention.TraveauxEffectues,
                CreatedBy = intervention.CreatedBy,
                CreatedDate = intervention.CreatedDate,
                CreatedTime = intervention.CreatedTime,
                LastUpdatedDate = intervention.LastUpdatedDate,
                LastUpdatedTime = intervention.LastUpdatedTime,
                LastUpdatedBy = intervention.LastUpdatedBy
            };
            return createInterventionViewModel;
        }

        public static Intervention UpdatedCreateInterventionViewModelToUpdatedIntervention(Intervention oldIntervention, CreateInterventionViewModel createInterventionViewModel, string user)
        {
            Intervention intervention = new Intervention
            {

                Id = createInterventionViewModel.Id,
                Type = createInterventionViewModel.Type,
                Nature = createInterventionViewModel.Nature,
                Etat = createInterventionViewModel.Etat,
                Reclamation = oldIntervention.Reclamation,
                ProblemeConstate = createInterventionViewModel.ProblemeConstate,
                TraveauxEffectues = createInterventionViewModel.TraveauxEffectues,
                CreatedBy = oldIntervention.CreatedBy,
                CreatedDate = oldIntervention.CreatedDate,
                CreatedTime = oldIntervention.CreatedTime,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
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
                Date = $"{intervention.CreatedDate}",
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


    
