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
        public static List<MaterielViewModel> MaterielListToMaterielViewModelList(List<Materiel> materiels, List<Fournisseur> fournisseurs)
        {
            List<MaterielViewModel> materielViewModels = new List<MaterielViewModel>();
            foreach (Materiel materiel in materiels)
            {
                foreach (Fournisseur fournisseur in fournisseurs)
                {
                    if (materiel.Fournisseur == fournisseur.Id)
                    {
                        MaterielViewModel materielViewModel = MaterielToMaterielViewModel(materiel, fournisseur);

                        materielViewModels.Add(materielViewModel);
                    }
                }
            }

            return materielViewModels;
        }
        public static MaterielViewModel MaterielToMaterielViewModel(Materiel materiel, Fournisseur fournisseur)
        {
            MaterielViewModel materielViewModel = new MaterielViewModel
            {
                Id = materiel.Id,
                Nom = materiel.Nom,
                Marque = materiel.Marque,
                Modele = materiel.Modele,
                ReferenceBT = materiel.ReferenceBT,
                NumeroDeSerie = materiel.NumeroDeSerie,
                Fournisseur = fournisseur.Nom,
                Agent = materiel.Agent,
                UniteGestion = materiel.UniteGestion,
                Etat = materiel.Etat,
                Statut = materiel.Statut,
                AffectedBy = materiel.AffectedBy,
                AffectedDate = materiel.AffectedDate,
                AffectedTime = materiel.AffectedTime,
                ArchivedBy = materiel.ArchivedBy,
                ArchivedDate = materiel.ArchivedDate,
                ArchivedTime = materiel.ArchivedTime,
                RevokedBy = materiel.RevokedBy,
                RevokedDate = materiel.RevokedDate,
                RevokedTime = materiel.RevokedTime,
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
                Etat = "Non affecté",
                Statut = "Non reclamé",
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
                Fournisseur = oldMateriel.Fournisseur,
                Agent = oldMateriel.Agent,
                UniteGestion = oldMateriel.UniteGestion,
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
                UniteGestion = oldMateriel.UniteGestion,
                Etat = "Affecte",
                Statut = oldMateriel.Statut,
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

        public static Materiel RetirerMaterielViewModelToRetirerMateriel(Materiel oldMateriel, string user)
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
                UniteGestion = oldMateriel.UniteGestion,
                Etat = "Non affecté",
                Statut = oldMateriel.Statut,
                RevokedBy = user,
                RevokedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                RevokedTime = DateTime.Now.ToString("HH:mm:ss"),
                AffectedBy = user,
                AffectedDate = oldMateriel.AffectedDate,
                AffectedTime = oldMateriel.AffectedTime,
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
                Statut = materiel.Statut,
                Agent = materiel.Agent,
                UniteGestion = materiel.UniteGestion,
                AffectedBy = materiel.AffectedBy,
                AffectedDate = materiel.AffectedDate,
                AffectedTime = materiel.AffectedTime,

            };
            return affectationMaterielViewModel;
        }
        public static List<MaterielReport> MaterielListToMaterielReportList(List<Materiel> materiels, List<Fournisseur> fournisseurs)
        {
            List<MaterielReport> materielReports = new List<MaterielReport>();
            foreach (Materiel materiel in materiels)
            { 
                foreach (Fournisseur fournisseur in fournisseurs)
                {
                    if (materiel.Fournisseur == fournisseur.Id)
                    {
                        MaterielReport materielReport = MaterielToMaterielReport(materiel, fournisseur);

                        materielReports.Add(materielReport);
                    }
                }
                
            }
            return materielReports;
        }

        public static Materiel ChangeMaterielStatut(Materiel materielById, string user, string statut)
        {
            Materiel materiel = new Materiel
            {
                Id = materielById.Id,
                Nom = materielById.Nom,
                Marque = materielById.Marque,
                Modele = materielById.Modele,
                ReferenceBT = materielById.ReferenceBT,
                NumeroDeSerie = materielById.NumeroDeSerie,
                Fournisseur = materielById.Fournisseur,
                Agent = materielById.Agent,
                UniteGestion = materielById.UniteGestion,
                Etat = materielById.Etat,
                Statut = statut,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                CreatedBy = materielById.CreatedBy,
                CreatedDate = materielById.CreatedDate,
                CreatedTime = materielById.CreatedTime,
                AffectedBy = materielById.AffectedBy,
                AffectedDate = materielById.AffectedDate,
                AffectedTime = materielById.AffectedTime,

            };
            return materiel;
        }

        public static MaterielReport MaterielToMaterielReport(Materiel materiel, Fournisseur fournisseur)
        {
            MaterielReport materielReport = new MaterielReport
            {
                Nom = $"{materiel.Nom}",
                Marque = $"{materiel.Marque}",
                Modele = $"{materiel.Modele}",
                ReferenceBT = $"{materiel.ReferenceBT}",
                NumeroDeSerie = $"{materiel.NumeroDeSerie}",
                Fournisseur = $"{fournisseur.Nom}",
                Etat = $"{materiel.Etat}",
                Statut = $"{materiel.Statut}",
                Agent = $"{materiel.Agent}",
                CreatedBy = $"{materiel.CreatedBy}",
                DateContrat = $"Date : {materiel.CreatedDate} / Heure : { materiel.CreatedTime }",
                AffectedBy = $"{materiel.AffectedBy}",
                DateAffectation = $"Date : {materiel.AffectedDate} / Heure : { materiel.AffectedTime }",
                RevokedBy = $"{materiel.RevokedBy}",
                DateElimination = $"Date : {materiel.RevokedDate} / Heure : { materiel.RevokedTime }",
                ArchivedBy = $"{materiel.ArchivedBy}",
                DateArchive = $"Date : {materiel.ArchivedDate} / Heure : { materiel.ArchivedTime }",
                LastUpdatedBy = $"{materiel.LastUpdatedBy}",
                DateModification = $"Date : {materiel.LastUpdatedDate} / Heure : { materiel.LastUpdatedTime }",
            };

            return materielReport;
        }

        public static Materiel ArchiverMaterielViewModelToArchiverMateriel(Materiel oldMateriel, string user)
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
                Etat = "Supprimé",
                Statut = oldMateriel.Statut,
                RevokedBy = user,
                RevokedDate = oldMateriel.RevokedDate,
                RevokedTime = oldMateriel.RevokedTime,
                ArchivedBy = user,
                ArchivedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ArchivedTime = DateTime.Now.ToString("HH:mm:ss"),
                AffectedBy = user,
                AffectedDate = oldMateriel.AffectedDate,
                AffectedTime = oldMateriel.AffectedTime,
                LastUpdatedBy = oldMateriel.LastUpdatedBy,
                LastUpdatedDate = oldMateriel.LastUpdatedDate,
                LastUpdatedTime = oldMateriel.LastUpdatedTime,
                CreatedBy = oldMateriel.CreatedBy,
                CreatedDate = oldMateriel.CreatedDate,
                CreatedTime = oldMateriel.CreatedTime,



            };
            return materiel;
        }

        public static Materiel FiltrerMaterielViewModelToMateriel(Materiel oldMateriel, AffectationMaterielViewModel affectationMaterielViewModel)
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
                UniteGestion = affectationMaterielViewModel.UniteGestion,
                Etat = oldMateriel.Etat,
                Statut = oldMateriel.Statut,
                Agent = oldMateriel.Agent,
                AffectedBy = oldMateriel.AffectedBy,
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
    }
}

