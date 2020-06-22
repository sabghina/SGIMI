using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Enum;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class SocieteTierceTranspose
    {

        public static List<SocieteTierceViewModel> FournisseurListToSocieteTierceViewModelList(List<Fournisseur> societeTierces)
        {
            List<SocieteTierceViewModel> societeTierceViewModels = new List<SocieteTierceViewModel>();

            foreach (Fournisseur societeTierce in societeTierces)
            {
                SocieteTierceViewModel societeTierceViewModel = FournisseurToSocieteTierceViewModel(societeTierce);

                societeTierceViewModels.Add(societeTierceViewModel);
            }

            return societeTierceViewModels;
        }

        public static SocieteTierceViewModel FournisseurToSocieteTierceViewModel(Fournisseur societeTierce)
        {
            SocieteTierceViewModel societeTierceViewModel = new SocieteTierceViewModel
            {
                Id = societeTierce.Id,
                Nom = societeTierce.Nom,
                Email = societeTierce.Email,
                Telephone = societeTierce.Telephone,
                Fax = societeTierce.Fax,
                Adresse = societeTierce.Adresse,
                Type = societeTierce.Type,
                SiteWeb = societeTierce.SiteWeb,
                Etat = societeTierce.Etat,
                ArchivedBy = societeTierce.ArchivedBy,
                ArchivedDate = societeTierce.ArchivedDate,
                ArchivedTime = societeTierce.ArchivedTime,
                CreatedBy = societeTierce.CreatedBy,
                CreatedDate = societeTierce.CreatedDate,
                CreatedTime = societeTierce.CreatedTime,
                LastUpdatedDate = societeTierce.LastUpdatedDate,
                LastUpdatedTime = societeTierce.LastUpdatedTime,
                LastUpdatedBy = societeTierce.LastUpdatedBy
            };
            return societeTierceViewModel;
        }

        public static Fournisseur UpdatedSocieteTierceViewModelToUpdatedSocieteTierce(Fournisseur oldSocieteTierce, SocieteTierceViewModel societeTierceViewModel, string user)
        {

            Fournisseur societeTierce = new Fournisseur
            {
                Id = societeTierceViewModel.Id,
                Nom = societeTierceViewModel.Nom,
                Email = societeTierceViewModel.Email,
                Telephone = societeTierceViewModel.Telephone,
                Adresse = societeTierceViewModel.Adresse,
                Fax = societeTierceViewModel.Fax,
                SiteWeb = societeTierceViewModel.SiteWeb,
                Type = oldSocieteTierce.Type,
                Etat = oldSocieteTierce.Etat,
                ArchivedBy = oldSocieteTierce.ArchivedBy,
                ArchivedDate = oldSocieteTierce.ArchivedDate,
                ArchivedTime = oldSocieteTierce.ArchivedTime,
                CreatedBy = oldSocieteTierce.CreatedBy,
                CreatedDate = oldSocieteTierce.CreatedDate,
                CreatedTime = oldSocieteTierce.CreatedTime,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
            };
            return societeTierce;
        }

        public static Fournisseur CreateSocieteTierceViewModelToSocieteTierce(SocieteTierceViewModel societeTierceViewModel, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Nom = societeTierceViewModel.Nom,
                Email = societeTierceViewModel.Email,
                Telephone = societeTierceViewModel.Telephone,
                Adresse = societeTierceViewModel.Adresse,
                Fax = societeTierceViewModel.Fax,
                SiteWeb = societeTierceViewModel.SiteWeb,
                Type = "S",
                Etat = "Active",
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = societeTierceViewModel.LastUpdatedBy,
                LastUpdatedDate = societeTierceViewModel.LastUpdatedDate,
                LastUpdatedTime = societeTierceViewModel.LastUpdatedTime,
            };

            return fournisseur;
        }

        public static List<SocieteTierceReport> SocieteTierceListToSocieteTierceReportList(List<Fournisseur> societeTierces)
        {
            List<SocieteTierceReport> societeTierceReports = new List<SocieteTierceReport>();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                SocieteTierceReport societeTierceReport = SocieteTierceToSocieteTierceReport(societeTierce);

                societeTierceReports.Add(societeTierceReport);
            }
            return societeTierceReports;
        }

        public static SocieteTierceReport SocieteTierceToSocieteTierceReport(Fournisseur societeTierce)
        {
            SocieteTierceReport societeTierceReport = new SocieteTierceReport
            {
                Nom = $"{societeTierce.Nom}",
                Contact = $"Telephone :{societeTierce.Telephone}/Fax: {societeTierce.Fax}",
                Email = $"{societeTierce.Email}",
                Adresse = $"{societeTierce.Adresse}",
                SiteWeb = $"{societeTierce.SiteWeb}",
                Etat = $"{societeTierce.Etat}",
                DateContrat = $"{societeTierce.CreatedDate}"
            };

            return societeTierceReport;
        }


        public static Fournisseur ArchiverSocieteTierceViewModelToArchiverFournisseur(Fournisseur oldSocieteTierce, string user)
        {
            Fournisseur societeTierce = new Fournisseur
            {
                Id = oldSocieteTierce.Id,
                Nom = oldSocieteTierce.Nom,
                Email = oldSocieteTierce.Email,
                Telephone = oldSocieteTierce.Telephone,
                Adresse = oldSocieteTierce.Adresse,
                Fax = oldSocieteTierce.Fax,
                SiteWeb = oldSocieteTierce.SiteWeb,
                Type = oldSocieteTierce.Type,
                Etat = "Archivé",
                ArchivedBy = user,
                ArchivedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ArchivedTime = DateTime.Now.ToString("HH:mm:ss"),
                CreatedBy = oldSocieteTierce.CreatedBy,
                CreatedDate = oldSocieteTierce.CreatedDate,
                CreatedTime = oldSocieteTierce.CreatedTime,
                LastUpdatedBy = oldSocieteTierce.LastUpdatedBy,
                LastUpdatedDate = oldSocieteTierce.LastUpdatedDate,
                LastUpdatedTime = oldSocieteTierce.LastUpdatedTime,


            };
            return societeTierce;
        }
    }
}
