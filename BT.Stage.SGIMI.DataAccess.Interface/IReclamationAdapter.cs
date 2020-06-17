using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IReclamationAdapter
    {
        /// <summary>
        /// Returns List Reclamations.
        /// </summary>
        /// <returns></returns>
        List<Reclamation> GetReclamations();
        /// <summary>
        /// Returns Reclamation by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Reclamation GetReclamationById(int id);
        bool CreateReclamation(Reclamation reclamation);
        bool UpdateReclamation(Reclamation reclamation);
        bool ChangeReclamation(Reclamation reclamationById);
        bool CancelReclamation(Reclamation reclamation);
        List<Reclamation> GetInProgressReclamations();
        List<Reclamation> GetFinishedReclamations();
        List<Reclamation> GetCanceledReclamations();
        List<Reclamation> GetUserReclamations(string currentUser);
        List<Reclamation> GetUserFinishedReclamations(string currentUser);
    }
}
