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
                CreatedDate = materiel.CreatedDate,
                CreatedTime = materiel.CreatedTime,
                LastUpdatedDate = materiel.LastUpdatedDate,
                LastUpdatedTime = materiel.LastUpdatedTime,
                LastUpdatedBy = materiel.LastUpdatedBy,
                CreatedBy = materiel.CreatedBy

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
                CreatedBy = user // TODO: add current connected user

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
                CreatedBy = "admin" // TODO: add current connected user

            };
            return createMaterielViewModel;
        }

        public static Materiel UpdatedMaterielViewModelToUpdatedMateriel(int id, CreateMaterielViewModel createMaterielViewModel, string user)
        {
            Materiel materiel = new Materiel
            {
                Id = id,
                Nom = createMaterielViewModel.Nom,
                Marque = createMaterielViewModel.Marque,
                Modele = createMaterielViewModel.Modele,
                ReferenceBT = createMaterielViewModel.ReferenceBT,
                NumeroDeSerie = createMaterielViewModel.NumeroDeSerie,
                Fournisseur = createMaterielViewModel.Fournisseur,
                CreatedBy = user // TODO: add current connected user

            };
            return materiel;
        }

        public static Materiel AffectationMaterielViewModelToMateriel(AffectationMaterielViewModel affectationMaterielViewModel, string user)
        {
            Materiel materiel = new Materiel
            {
                Agent = affectationMaterielViewModel.Agent,
                Unite = affectationMaterielViewModel.Unite,
                CreatedBy = user // TODO: add current connected user

            };
            return materiel;
        }

        public static AffectationMaterielViewModel MaterielToAffectationMaterielViewModel(Materiel materiel)
        {
            AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel
            {
                Agent = materiel.Agent,
                Unite = materiel.Unite,
                CreatedBy = "admin" // TODO: add current connected user

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
                Fournisseur = $"{materiel.Fournisseur}"
            };

            return materielReport;
        }
    }
}

