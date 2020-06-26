using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IFournisseurRepository
    {
        /// <summary>
        /// Returns List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetFournisseursActive();
        /// Returns Archived List Fournissuers.
        List<Fournisseur> GetArchivedFournisseurs();
        /// <summary>
        /// Returns fournisseur by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetFournisseurById(int id);
        string GetNameFournisseurById(int id);
        /// <summary>
        /// Create new fournisseur
        /// </summary>
        /// <param name="fournisseur"></param>
        /// <returns></returns>
        
        bool CreateFournisseur(Fournisseur fournisseur);
        bool UpdatedFournisseur(Fournisseur fournisseur);

        byte[] StaticReports();
        byte[] StaticReport();
        byte[] DynamicReports(List<FournisseurReport> FournisseurReports);
        byte[] DynamicReport(FournisseurReport fournisseurReport);
        bool ArchivedFournisseur(Fournisseur fournisseur);
        bool ActivatedFournisseur(Fournisseur fournisseur);
        byte[] DynamicReportsArchived(List<FournisseurReport> fournisseurReports);
    }
}
