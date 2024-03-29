﻿using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.Data.Enum;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class FournisseurTranspose
    {
        public static List<FournisseurViewModel> FournisseurListToFournisseurViewModelList(List<Fournisseur> fournisseurs)
        {
            List<FournisseurViewModel> fournisseurViewModels = new List<FournisseurViewModel>();

            foreach (Fournisseur fournisseur in fournisseurs)
            {
                FournisseurViewModel fournisseurViewModel = FournisseurToFournisseurViewModel(fournisseur);

                fournisseurViewModels.Add(fournisseurViewModel);
            }

            return fournisseurViewModels;
        }

        public static FournisseurViewModel FournisseurToFournisseurViewModel(Fournisseur fournisseur)
        {
            FournisseurViewModel fournisseurViewModel = new FournisseurViewModel
            {
                Id = fournisseur.Id,
                Nom = fournisseur.Nom,
                Email = fournisseur.Email,
                Telephone = fournisseur.Telephone,
                Adresse = fournisseur.Adresse,
                Fax = fournisseur.Fax,
                Type= fournisseur.Type,
                SiteWeb = fournisseur.SiteWeb,
                Etat = fournisseur.Etat,
                ArchivedBy = fournisseur.ArchivedBy,
                ArchivedDate = fournisseur.ArchivedDate,
                ArchivedTime = fournisseur.ArchivedTime,
                ActivatedBy = fournisseur.ActivatedBy,
                ActivatedDate = fournisseur.ActivatedDate,
                ActivatedTime = fournisseur.ActivatedTime,
                CreatedBy = fournisseur.CreatedBy,
                CreatedDate = fournisseur.CreatedDate,
                CreatedTime = fournisseur.CreatedTime,
                LastUpdatedDate = fournisseur.LastUpdatedDate,
                LastUpdatedTime = fournisseur.LastUpdatedTime,
                LastUpdatedBy = fournisseur.LastUpdatedBy
            };
            return fournisseurViewModel;
        }

        public static Fournisseur CreateFournisseurViewModelToFournisseur(FournisseurViewModel fournisseurViewModel, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Nom = fournisseurViewModel.Nom,
                Email = fournisseurViewModel.Email,
                Telephone = fournisseurViewModel.Telephone,
                Adresse = fournisseurViewModel.Adresse,
                Fax = fournisseurViewModel.Fax,
                SiteWeb = fournisseurViewModel.SiteWeb,
                Type = "F",
                Etat = "Active",
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = fournisseurViewModel.LastUpdatedBy,
                LastUpdatedDate =  fournisseurViewModel.LastUpdatedDate,
                LastUpdatedTime = fournisseurViewModel.LastUpdatedTime,
            };
            return fournisseur;
        }

        public static Fournisseur UpdatedFournisseurViewModelToUpdatedFournisseur(Fournisseur oldFournisseur, FournisseurViewModel fournisseurViewModel, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Id = fournisseurViewModel.Id,
                Nom = fournisseurViewModel.Nom,
                Email = fournisseurViewModel.Email,
                Telephone = fournisseurViewModel.Telephone,
                Adresse = fournisseurViewModel.Adresse,
                Fax = fournisseurViewModel.Fax,
                SiteWeb = fournisseurViewModel.SiteWeb,
                Type = oldFournisseur.Type,
                Etat = oldFournisseur.Etat,
                ArchivedBy = oldFournisseur.ArchivedBy,
                ArchivedDate = oldFournisseur.ArchivedDate,
                ArchivedTime = oldFournisseur.ArchivedTime,
                ActivatedBy = oldFournisseur.ActivatedBy,
                ActivatedDate = oldFournisseur.ActivatedDate,
                ActivatedTime = oldFournisseur.ActivatedTime,
                CreatedBy = oldFournisseur.CreatedBy,
                CreatedDate = oldFournisseur.CreatedDate,
                CreatedTime= oldFournisseur.CreatedTime,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),                
            };
            return fournisseur;
        }

        public static List<FournisseurReport> FournisseurListToFournisseurReportList(List<Fournisseur> fournisseurs)
        {
            List<FournisseurReport> fournisseurReports = new List<FournisseurReport>();
            foreach (Fournisseur fournisseur in fournisseurs)
            {
                FournisseurReport fournisseurReport = FournisseurToFournisseurReport(fournisseur);

                fournisseurReports.Add(fournisseurReport);
            }
            return fournisseurReports;
        }

        public static FournisseurReport FournisseurToFournisseurReport(Fournisseur fournisseur)
        {
            FournisseurReport fournisseurReport = new FournisseurReport
            {
                Nom = $"{fournisseur.Nom}",
                Contact = $"Telephone :{fournisseur.Telephone} / Fax: {fournisseur.Fax}",
                Email = $"{fournisseur.Email}",
                Adresse = $"{fournisseur.Adresse}",
                SiteWeb = $"{fournisseur.SiteWeb}",
                Etat = $"{fournisseur.Etat}", 
                CreatedBy = $"{fournisseur.CreatedBy}",
                DateContrat = $"Date : {fournisseur.CreatedDate} / Heure: {fournisseur.CreatedTime} ",
                ArchivedBy = $"{fournisseur.ArchivedBy}",
                DateArchive = $"Date : {fournisseur.ArchivedDate} / Heure: {fournisseur.ArchivedTime} ",
                ActivatedBy = $"{fournisseur.ActivatedBy}",
                DateActivation = $"Date : {fournisseur.ActivatedDate} / Heure: {fournisseur.ActivatedTime} ",
                LastUpdatedBy = $"{fournisseur.LastUpdatedBy}",
                DateModification = $"Date : {fournisseur.LastUpdatedDate} / Heure: {fournisseur.LastUpdatedTime} ",

            };

            return fournisseurReport;
        }

        public static Fournisseur ArchiverFournisseurViewModelToArchiverFournisseur(Fournisseur oldFournisseur, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Id = oldFournisseur.Id,
                Nom = oldFournisseur.Nom,
                Email = oldFournisseur.Email,
                Telephone = oldFournisseur.Telephone,
                Adresse = oldFournisseur.Adresse,
                Fax = oldFournisseur.Fax,
                SiteWeb = oldFournisseur.SiteWeb,
                Type = oldFournisseur.Type,
                Etat = "Archivé",
                ArchivedBy = user,
                ArchivedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ArchivedTime = DateTime.Now.ToString("HH:mm:ss"),
                ActivatedBy = oldFournisseur.ActivatedBy,
                ActivatedDate = oldFournisseur.ActivatedDate,
                ActivatedTime = oldFournisseur.ActivatedTime,
                CreatedBy = oldFournisseur.CreatedBy,
                CreatedDate = oldFournisseur.CreatedDate,
                CreatedTime = oldFournisseur.CreatedTime,
                LastUpdatedBy = oldFournisseur.LastUpdatedBy,
                LastUpdatedDate = oldFournisseur.LastUpdatedDate,
                LastUpdatedTime = oldFournisseur.LastUpdatedTime,


            };
            return fournisseur;
        }

        public static Fournisseur ActiverFournisseurViewModelToActiverFournisseur(Fournisseur oldFournisseur, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Id = oldFournisseur.Id,
                Nom = oldFournisseur.Nom,
                Email = oldFournisseur.Email,
                Telephone = oldFournisseur.Telephone,
                Adresse = oldFournisseur.Adresse,
                Fax = oldFournisseur.Fax,
                SiteWeb = oldFournisseur.SiteWeb,
                Type = oldFournisseur.Type,
                Etat = "Active",
                ActivatedBy = user,
                ActivatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ActivatedTime = DateTime.Now.ToString("HH:mm:ss"),
                ArchivedBy = oldFournisseur.ArchivedBy,
                ArchivedDate = oldFournisseur.ArchivedDate,
                ArchivedTime = oldFournisseur.ArchivedTime,
                CreatedBy = oldFournisseur.CreatedBy,
                CreatedDate = oldFournisseur.CreatedDate,
                CreatedTime = oldFournisseur.CreatedTime,
                LastUpdatedBy = oldFournisseur.LastUpdatedBy,
                LastUpdatedDate = oldFournisseur.LastUpdatedDate,
                LastUpdatedTime = oldFournisseur.LastUpdatedTime,


            };
            return fournisseur;
        }
    }
}
