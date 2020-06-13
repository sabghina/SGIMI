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
        public static List<ReclamationViewModel> ReclamationListToReclamationViewModelList(List<Reclamation> reclamations, List<Materiel> materiels)
        {
            List<ReclamationViewModel> reclamationViewModels = new List<ReclamationViewModel>();
            foreach (Reclamation reclamation in reclamations)
            {
                foreach (Materiel materiel in materiels)
                {
                    if (reclamation.Materiel == materiel.Id)
                    {
                        ReclamationViewModel reclamationViewModel = ReclamationToReclamationViewModel(reclamation, materiel);
                        reclamationViewModels.Add(reclamationViewModel);
                    }
                    
                }
            }

            return reclamationViewModels;
        }

        public static ReclamationViewModel ReclamationToReclamationViewModel(Reclamation reclamation, Materiel materiel)
        {
            ReclamationViewModel reclamationViewModel = new ReclamationViewModel
            {
                Id = reclamation.Id,
                Materiel = materiel.ReferenceBT,
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

        public static CreateReclamationViewModel ReclamationToCreateReclamationViewModel(Reclamation reclamation, Materiel materiel)
        {
            CreateReclamationViewModel createReclamationViewModel = new CreateReclamationViewModel
            {
                Id = reclamation.Id,
                Materiel = materiel.Id,
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
            return createReclamationViewModel;
        }

        public static Reclamation CreateReclamationViewModelToReclamation(CreateReclamationViewModel createReclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = createReclamationViewModel.Id,
                Materiel = createReclamationViewModel.Materiel,
                Probleme = createReclamationViewModel.Probleme,
                Commentaire = createReclamationViewModel.Commentaire,
                UniteGestion = createReclamationViewModel.UniteGestion,
                Etat = "En attente",
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return reclamation;

        }

        public static Reclamation ChangeReclamationEtat(Reclamation reclamationById, string user,string Etat)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = reclamationById.Id,
                Materiel = reclamationById.Materiel,
                Probleme = reclamationById.Probleme,
                Commentaire = reclamationById.Commentaire,
                UniteGestion = reclamationById.UniteGestion,
                Etat = Etat,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                CreatedBy = reclamationById.CreatedBy,
                CreatedDate = reclamationById.CreatedDate,
                CreatedTime = reclamationById.CreatedTime
            };
            return reclamation;
        }

        public static Reclamation UpdatedReclamationViewModelToUpdatedReclamation(Reclamation oldReclamation, CreateReclamationViewModel createReclamationViewModel, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = createReclamationViewModel.Id,
                Materiel = oldReclamation.Materiel,
                Probleme = createReclamationViewModel.Probleme,
                Commentaire = createReclamationViewModel.Commentaire,
                Etat = createReclamationViewModel.Etat,
                UniteGestion = createReclamationViewModel.UniteGestion,
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
                Materiel = $"{reclamation.Materiel}",
                Date = $"{reclamation.CreatedDate}",
                Probleme = $"{reclamation.Probleme}",
                Commentaire = $"{reclamation.Commentaire}",
                Etat = $"{reclamation.Etat}",
                UniteGestion = $"{reclamation.UniteGestion}",
                Rec_By = $"{reclamation.CreatedBy}"

            };

            return reclamationReport;
        }

        public static Reclamation AnnulerReclamationViewModelToAnnulerReclamation(Reclamation oldReclamation, string user)
        {
            Reclamation reclamation = new Reclamation
            {
                Id = oldReclamation.Id,
                Materiel = oldReclamation.Materiel,
                Probleme = oldReclamation.Probleme,
                Commentaire = oldReclamation.Commentaire,
                Etat = "Annulée",
                UniteGestion = oldReclamation.UniteGestion,
                CreatedBy = oldReclamation.CreatedBy,
                CreatedDate = oldReclamation.CreatedDate,
                CreatedTime = oldReclamation.CreatedTime,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = user

            };
            return reclamation;
        }
    }

}
