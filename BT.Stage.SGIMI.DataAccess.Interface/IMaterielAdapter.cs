using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IMaterielAdapter
    {
        /// <summary>
        /// Returns List Materiels.
        /// </summary>
        /// <returns></returns>
        List<Materiel> GetMateriels();
        /// <summary>
        /// Return materiel by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Materiel GetMaterielById(int id);
        string GetReferenceMaterielById(int id);
        /// <summary>
        /// Create new materiel.
        /// </summary>
        /// <param name="materiel"></param>
        /// <returns></returns> 
        bool CreateMateriel(Materiel materiel);
        bool UpdateMateriel(Materiel materiel);
        bool AffecterMateriel(Materiel materiel);
        List<Materiel> GetAffectedMateriels();
        bool RevokeMateriel(Materiel materiel);
        bool ArchivedMateriel(Materiel materiel);
        List<Materiel> GetArchivedMateriels();
    }
}
