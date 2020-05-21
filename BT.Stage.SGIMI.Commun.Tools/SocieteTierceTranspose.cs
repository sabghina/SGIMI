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
                Type = (TypeFournisseur)societeTierce.Type,
                SiteWeb = societeTierce.SiteWeb,
                CreatedBy = societeTierce.CreatedBy,
                CreatedDate = societeTierce.CreatedDate,
                CreatedTime = societeTierce.CreatedTime,
                LastUpdatedDate = societeTierce.LastUpdatedDate,
                LastUpdatedTime = societeTierce.LastUpdatedTime,
                LastUpdatedBy = societeTierce.LastUpdatedBy
            };
            return societeTierceViewModel;
        }

        public static Fournisseur UpdatedSocieteTierceViewModelToUpdatedSocieteTierce(SocieteTierceViewModel societeTierceViewModel, string user)
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
                Type = (char)societeTierceViewModel.Type,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
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
                Type = 'S',
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
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
                DateContrat = $"{societeTierce.CreatedDate}"
            };

            return societeTierceReport;
        }
    }
}
