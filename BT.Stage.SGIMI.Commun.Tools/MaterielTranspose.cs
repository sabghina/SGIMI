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
                CreatedBy = materiel.CreatedBy

            };
            return materielViewModel;
        }

        public static Materiel CreateMaterielViewModelToMateriel(CreateMaterielViewModel createMaterielViewModel)
        {
            Materiel materiel = new Materiel
            {                
                Nom = createMaterielViewModel.Nom,
                Marque = createMaterielViewModel.Marque,
                Modele = createMaterielViewModel.Modele,
                ReferenceBT = createMaterielViewModel.ReferenceBT,
                NumeroDeSerie = createMaterielViewModel.NumeroDeSerie,
                Fournisseur = createMaterielViewModel.Fournisseur,
                CreatedBy = "admin" // TODO: add current connected user

            };
            return materiel;
        }
    }
}

