using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class ReclamationAdapter : IReclamationAdapter 
    {
        public bool CreateReclamation(Reclamation reclamation)
        {
            // ajout in database
            return true;
        }

        public Reclamation GetReclamationById(int id)
        {
            // replace with database access
            Reclamation reclamation = new Reclamation
            {
                Id = id,
                Materiel = "Matériel" + id,
                Date = "0" + id + "/0" + id + "/2020",
                Probleme = "Problème" + id,
                Commentaire = "Commentaire" + id,
                Etat = "En cours",
                CreatedBy = id + 1
            };

            return reclamation;
        }
        public List<Reclamation> GetReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = new List<Reclamation>();
            for (int i = 1; i < 10; i++)
            {
                Reclamation reclamation = new Reclamation
                {
                    Id = i,
                    Materiel = "Matériel" + i,
                    Date = "0" + i + "/0" + i + "/2020",
                    Probleme ="Problème" + i,
                    Commentaire = "Commentaire"+i,
                    Etat = "En cours",
                    CreatedBy = i + 1
                };

                reclamations.Add(reclamation);
            }

            return reclamations;
        }
    }
}
