using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IReclamationRepository
    {
        /// <summary>
        /// Returns List Reclamations.
        /// </summary>
        /// <returns></returns>
        List<Reclamation> GetReclamations();
        /// <summary>
        /// Returns reclamation by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Reclamation GetReclamationById(int id);
    }
}
