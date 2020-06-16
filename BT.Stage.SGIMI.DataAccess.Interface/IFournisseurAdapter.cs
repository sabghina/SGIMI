using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IFournisseurAdapter
    {
        /// <summary>
        /// Returns Active List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetFournisseurs();
        /// Returns Archived List Fournissuers.
        List<Fournisseur> GetArchivedFournisseurs();
        /// <summary>
        /// Return fournisseur by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetFournisseurById(int id);
        /// <summary>
        /// Create new fournisseur
        /// </summary>
        /// <param name="fournisseur"></param>
        /// <returns></returns>
        List<Fournisseur> GetSearchedFournisseurs();
        bool CreateFournisseur(Fournisseur fournisseur);
        bool UpdateFournisseur(Fournisseur fournisseur);
        string GetNameFournisseurById(int id);
        bool ArchiveFournisseur(Fournisseur fournisseur);
        bool ActiveFournisseur(Fournisseur fournisseur);
        bool SearchFournisseur(Fournisseur fournisseur);
        
    }
}
