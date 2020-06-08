using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class ReclamationTranspose
    {
        public static List<ReclamationViewModel> ReclamationListToReclamationViewModelList(List<Reclamation> reclamations)
        {
            List<ReclamationViewModel> reclamationViewModels = new List<ReclamationViewModel>();
            foreach (Reclamation reclamation in reclamations)
            {
                ReclamationViewModel reclamationViewModel = ReclamationToReclamationViewModel(reclamation);

                reclamationViewModels.Add(reclamationViewModel);
            }

            return reclamationViewModels;
        }
        public static ReclamationViewModel ReclamationToReclamationViewModel(Reclamation reclamation)
        {
            ReclamationViewModel reclamationViewModel = new ReclamationViewModel
            {
                Id = reclamation.Id,
                //Materiel = reclamation.Materiel,
                Probleme = reclamation.Probleme,
                Commentaire = reclamation.Commentaire,
                Etat = reclamation.Etat,
                UniteGestion = reclamation.UniteGestion,
                CreatedBy = reclamation.CreatedBy,
                CreatedDate = reclamation.CreatedDate,
                CreatedTime = reclamation.CreatedTime,
                LastUpdatedBy = reclamation.LastUpdatedBy,
                LastUpdatedDate = reclamation.LastUpdatedDate,
                LastUpdatedTime = reclamation.LastUpdatedTime,

            };
            return reclamationViewModel;
        }

        public static Reclamation CreateReclamationViewModelToReclamation(int materielId, ReclamationViewModel reclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = reclamationViewModel.Id,
                //Materiel = materielId,
                Probleme = reclamationViewModel.Probleme,
                Commentaire = reclamationViewModel.Commentaire,
                UniteGestion=reclamationViewModel.UniteGestion,
                Etat = "en cours",
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return reclamation;
        }
        public static Reclamation UpdatedReclamationViewModelToUpdatedReclamation(Reclamation oldReclamation,ReclamationViewModel reclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = reclamationViewModel.Id,
                Materiel = oldReclamation.Materiel,
                Probleme = reclamationViewModel.Probleme,
                Commentaire = reclamationViewModel.Commentaire,
                Etat = reclamationViewModel.Etat,
                UniteGestion=reclamationViewModel.UniteGestion,
                CreatedBy = oldReclamation.CreatedBy,
                CreatedDate = oldReclamation.CreatedDate,
                CreatedTime = oldReclamation.CreatedTime,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = user
            };
            return reclamation;
        }
        public static List<ReclamationReport> ReclamationListToReclamationReportList(List<Reclamation> reclamations)
        {
            List<ReclamationReport> reclamationReports = new List<ReclamationReport>();
            foreach (Reclamation reclamation in reclamations)
            {
                ReclamationReport reclamationReport = ReclamationToReclamationReport(reclamation);

                reclamationReports.Add(reclamationReport);
            }
            return reclamationReports;
        }

        public static ReclamationReport ReclamationToReclamationReport(Reclamation reclamation)
        {
            ReclamationReport reclamationReport = new ReclamationReport
            {
                Materiel= $"{reclamation.Materiel}",
                Date = $"{reclamation.CreatedDate}",
                Probleme = $"{reclamation.Probleme}",
                Commentaire = $"{reclamation.Commentaire}",
                Etat = $"{reclamation.Etat}",
                UniteGestion = $"{reclamation.UniteGestion}",
                Rec_By =$"{reclamation.CreatedBy}"

    };

            return reclamationReport;
        }

    }
}