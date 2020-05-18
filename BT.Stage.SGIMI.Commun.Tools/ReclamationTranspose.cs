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
                Materiel = reclamation.Materiel,
                Date = reclamation.Date,
                Probleme = reclamation.Probleme,
                Commentaire = reclamation.Commentaire,
                Etat = reclamation.Etat,
                CreatedBy = reclamation.CreatedBy
    };
            return reclamationViewModel;
        }

        public static Reclamation ReclamationViewModelToReclamation( ReclamationViewModel reclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = reclamationViewModel.Id,
                Materiel = reclamationViewModel.Materiel,
                Date = reclamationViewModel.Date,
                Probleme = reclamationViewModel.Probleme,
                Commentaire = reclamationViewModel.Commentaire,
                Etat = reclamationViewModel.Etat,
                CreatedBy = reclamationViewModel.CreatedBy
            };
            return reclamation;
        }
        public static Reclamation UpdatedReclamationViewModelToUpdatedReclamation(int id, ReclamationViewModel reclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = reclamationViewModel.Id,
                Materiel = reclamationViewModel.Materiel,
                Date = reclamationViewModel.Date,
                Probleme = reclamationViewModel.Probleme,
                Commentaire = reclamationViewModel.Commentaire,
                Etat = reclamationViewModel.Etat,
                CreatedBy = reclamationViewModel.CreatedBy
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
                Date = $"{reclamation.Date}",
                Probleme = $"{reclamation.Probleme}",
                Commentaire = $"{reclamation.Commentaire}",
                Etat = $"{reclamation.Etat}",
                UniteGestion = $"{reclamation.UniteGestion}"
    };

            return reclamationReport;
        }

    }
}