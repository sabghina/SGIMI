using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class ReclamationAdapter : IReclamationAdapter
    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public ReclamationAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public bool CancelReclamation(Reclamation reclamation)
        {
            sGIMIDbContext.Reclamations.AddOrUpdate(reclamation);
            Task<int> nbRowsCanceled = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsCanceled != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeReclamation(Reclamation reclamationById)
        {
            sGIMIDbContext.Reclamations.AddOrUpdate(reclamationById);
            Task<int> nbRowsChanged = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsChanged != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateReclamation(Reclamation reclamation)
        {
            sGIMIDbContext.Reclamations.Add(reclamation);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public Reclamation GetReclamationById(int id)
        {
            Reclamation reclamation = sGIMIDbContext.Reclamations.Find(id);
     
            return reclamation;
        }
        public List<Reclamation> GetReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if (reclamation.Etat == "En attente")
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
            
        }

        public List<Reclamation> GetUserReclamations(string currentUser)
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if ((reclamation.Etat == "En attente") && (reclamation.CreatedBy == currentUser)) 
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
        }

        public List<Reclamation> GetInProgressReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationInProgress = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if (reclamation.Etat == "En cours")
                {
                    reclamationInProgress.Add(reclamation);
                }
            }
            return reclamationInProgress;
        }

        public List<Reclamation> GetUserInProgressReclamations(string currentUser)
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationInProgress = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if ((reclamation.Etat == "En cours")&&(reclamation.CreatedBy == currentUser))
                {
                    reclamationInProgress.Add(reclamation);
                }
            }
            return reclamationInProgress;
        }

        public List<Reclamation> GetCanceledReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if (reclamation.Etat == "Annulée")
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
        }


        public List<Reclamation> GetUserCanceledReclamations(string currentUser)
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if ((reclamation.Etat == "Annulée" ) && (reclamation.CreatedBy == currentUser))
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
        
    }




        public List<Reclamation> GetFinishedReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if (reclamation.Etat == "Terminée")
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
        }

        public List<Reclamation> GetUserFinishedReclamations(string currentUser)
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();
            List<Reclamation> reclamationWainting = new List<Reclamation>();
            foreach (Reclamation reclamation in reclamations)
            {
                if ((reclamation.Etat == "Terminée") && (reclamation.CreatedBy == currentUser))
                {
                    reclamationWainting.Add(reclamation);
                }
            }
            return reclamationWainting;
        }

        public bool UpdateReclamation(Reclamation reclamation)
        {
            sGIMIDbContext.Reclamations.AddOrUpdate(reclamation);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
