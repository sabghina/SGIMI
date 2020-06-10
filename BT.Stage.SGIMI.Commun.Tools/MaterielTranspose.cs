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
    public static class MaterielTranspose
    {
        public static List<MaterielViewModel> MaterielListToMaterielViewModelList(List<Materiel> materiels)
        {
            List<MaterielViewModel> materielViewModels = new List<MaterielViewModel>();
            foreach (Materiel materiel in materiels)
            {
                MaterielViewModel materielViewModel = MaterielToMaterielViewModel(materiel);

                materielViewModels.Add(materielViewModel);
            }

            return materielViewModels;
        }
        public static MaterielViewModel MaterielToMaterielViewModel(Materiel materiel)
        {
            MaterielViewModel materielViewModel = new MaterielViewModel
            {
                Id = materiel.Id,
                Nom = materiel.Nom,
                Marque = materiel.Marque,
                Modele = materiel.Modele,
                ReferenceBT = materiel.ReferenceBT,
                NumeroDeSerie = materiel.NumeroDeSerie,
                Fournisseur = materiel.Fournisseur.ToString(),
                Agent = materiel.Agent,
                Etat = materiel.Etat,
                AffectedBy = materiel.AffectedBy,
                AffectedDate = materiel.AffectedDate,
                AffectedTime = materiel.AffectedTime,
                CreatedDate = materiel.CreatedDate,
                CreatedTime = materiel.CreatedTime,
                LastUpdatedDate = materiel.LastUpdatedDate,
                LastUpdatedTime = materiel.LastUpdatedTime,
                LastUpdatedBy = materiel.LastUpdatedBy,
                CreatedBy = materiel.CreatedBy,
                

            };
            return materielViewModel;
        }

        public static Materiel CreateMaterielViewModelToMateriel(CreateMaterielViewModel createMaterielViewModel, string user)
        {
            Materiel materiel = new Materiel
            {                
                Nom = createMaterielViewModel.Nom,
                Marque = createMaterielViewModel.Marque,
                Modele = createMaterielViewModel.Modele,
                ReferenceBT = createMaterielViewModel.ReferenceBT,
                NumeroDeSerie = createMaterielViewModel.NumeroDeSerie,
                Fournisseur = createMaterielViewModel.Fournisseur,
                Etat = "NonAffecte",
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")

    };
            return materiel;
        }

        public static CreateMaterielViewModel MaterielToCreateMaterielViewModel(Materiel materiel)
        {
            CreateMaterielViewModel createMaterielViewModel = new CreateMaterielViewModel
            {
                Nom = materiel.Nom,
                Marque = materiel.Marque,
                Modele = materiel.Modele,
                ReferenceBT = materiel.ReferenceBT,
                NumeroDeSerie = materiel.NumeroDeSerie,
                Fournisseur = materiel.Fournisseur,
                CreatedBy = materiel.CreatedBy,
                CreatedDate = materiel.CreatedDate,
                CreatedTime = materiel.CreatedTime

            };
            return createMaterielViewModel;
        }

        public static Materiel UpdatedMaterielViewModelToUpdatedMateriel(Materiel oldMateriel, CreateMaterielViewModel createMaterielViewModel, string user)
        {
            Materiel materiel = new Materiel
            {
                Id = createMaterielViewModel.Id,
                Nom = createMaterielViewModel.Nom,
                Marque = createMaterielViewModel.Marque,
                Modele = createMaterielViewModel.Modele,
                ReferenceBT = createMaterielViewModel.ReferenceBT,
                NumeroDeSerie = createMaterielViewModel.NumeroDeSerie,
                Fournisseur = createMaterielViewModel.Fournisseur,
                Agent = oldMateriel.Agent,
                Etat = oldMateriel.Etat,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                CreatedBy = oldMateriel.CreatedBy,
                CreatedDate = oldMateriel.CreatedDate,
                CreatedTime = oldMateriel.CreatedTime,
                AffectedBy = oldMateriel.AffectedBy,
                AffectedDate = oldMateriel.AffectedDate,
                AffectedTime = oldMateriel.AffectedTime,

            };
            return materiel;
        }

        public static Materiel AffectationMaterielViewModelToMateriel(Materiel oldMateriel, AffectationMaterielViewModel affectationMaterielViewModel, string user)
        {
            Materiel materiel = new Materiel
            {
                Id = oldMateriel.Id,
                Nom = oldMateriel.Nom,
                Marque = oldMateriel.Marque,
                Modele = oldMateriel.Modele,
                ReferenceBT = oldMateriel.ReferenceBT,
                NumeroDeSerie = oldMateriel.NumeroDeSerie,
                Fournisseur = oldMateriel.Fournisseur,
                Etat = "Affecte",
                Agent = affectationMaterielViewModel.Agent,
                AffectedBy = user,
                AffectedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                AffectedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = oldMateriel.LastUpdatedBy,
                LastUpdatedDate = oldMateriel.LastUpdatedDate,
                LastUpdatedTime = oldMateriel.LastUpdatedTime,
                CreatedBy = oldMateriel.CreatedBy,
                CreatedDate = oldMateriel.CreatedDate,
                CreatedTime = oldMateriel.CreatedTime,
                
                

            };
            return materiel;
        }

        public static AffectationMaterielViewModel MaterielToAffectationMaterielViewModel(Materiel materiel)
        {
            AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel
            {
                Id = materiel.Id,
                Etat = materiel.Etat,
                Agent = materiel.Agent,
                AffectedBy = materiel.AffectedBy,
                AffectedDate = materiel.AffectedDate,
                AffectedTime = materiel.AffectedTime,

            };
            return affectationMaterielViewModel;
        }
        public static List<MaterielReport> MaterielListToMaterielReportList(List<Materiel> materiels)
        {
            List<MaterielReport> materielReports = new List<MaterielReport>();
            foreach (Materiel materiel in materiels)
            {
                MaterielReport materielReport = MaterielToMaterielReport(materiel);

                materielReports.Add(materielReport);
            }
            return materielReports;
        }

        public static MaterielReport MaterielToMaterielReport(Materiel materiel)
        {
            MaterielReport materielReport = new MaterielReport
            {
                Nom = $"{materiel.Nom}",
                Marque = $"{materiel.Marque}",
                Modele = $"{materiel.Modele}",
                ReferenceBT = $"{materiel.ReferenceBT}",
                NumeroDeSerie = $"{materiel.NumeroDeSerie}",
                Fournisseur = $"{materiel.Fournisseur}",
                Etat = $"{materiel.Etat}",
                Agent = $"{materiel.Agent}",
                DateContrat = $"{materiel.CreatedDate}",
                DateAffectation = $"{materiel.AffectedDate}"
            };

            return materielReport;
        }
    }
}

