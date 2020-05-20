using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IUniteGestionRepository
    {
        /// <summary>
        /// Returns List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<UniteGestion> GetUniteGestions();
        /// <summary>
        /// Return UniteGestion by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UniteGestion GetUniteGestionById(int id);
        /// <summary>
        /// Create new UniteGestion
        /// </summary>
        /// <param name="uniteGestion"></param>
        /// <returns></returns>
        bool CreateUniteGestion(UniteGestion uniteGestion);
        bool UpdatedUniteGestion(UniteGestion uniteGestion);

        byte[] StaticReports();
        byte[] StaticReport();

        byte[] DynamicReports(List<UniteGestionReport> uniteGestionReports);
        byte[] DynamicReport(UniteGestionReport uniteGestionReport);
    }
}