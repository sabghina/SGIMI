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
                SiteWeb = fournisseur.SiteWeb,
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
                Type = (char)fournisseurViewModel.Type,
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")
            };
            return fournisseur;
        }

        public static Fournisseur UpdatedFournisseurViewModelToUpdatedFournisseur(FournisseurViewModel fournisseurViewModel, string user)
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
                Type = (char)fournisseurViewModel.Type,
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
                Contact = $"Telephone :{fournisseur.Telephone}/Fax: {fournisseur.Fax}",
                Email = $"{fournisseur.Email}",
                Adresse = $"{fournisseur.Adresse}",
                SiteWeb = $"{fournisseur.SiteWeb}",
                DateContrat = $"{fournisseur.CreatedDate}"
            };

            return fournisseurReport;
        }
    }
}
