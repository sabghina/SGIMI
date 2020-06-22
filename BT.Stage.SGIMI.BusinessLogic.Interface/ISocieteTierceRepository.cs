using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface ISocieteTierceRepository
    {

        /// <summary>
        /// Returns List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetSocieteTierces();
        /// <summary>
        /// Returns Archived List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetArchivedSocieteTierces();
        /// Returns societe tierce .
        /// </summary>
        /// <param name="societeTierce"></param>
        /// <returns></returns>
        Fournisseur GetSocieteTierceById(int id);
        //bool GetSocieteTierceTypeById(int id);
        bool CreateSocieteTierce(Fournisseur societeTierce);
        bool UpdatedSocieteTierce(Fournisseur societeTierce);

        byte[] StaticReports();
        byte[] StaticReport();

        byte[] DynamicReports(List<SocieteTierceReport> societeTierceReports);
        byte[] DynamicReport(SocieteTierceReport societeTierceReport);
        bool ArchivedSocieteTierce(Fournisseur societeTierce);
        bool ActivatedSocieteTierce(Fournisseur societeTierce);
    }
}
