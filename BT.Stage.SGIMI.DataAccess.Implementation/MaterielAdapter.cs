﻿using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class MaterielAdapter : IMaterielAdapter
    {
        public Materiel GetMaterielById(int id)
        {
            // replace with database access
            Materiel materiel = new Materiel
            {
                Id = id,
                Nom = "Materiel" + id,
                Marque = "Marque" + id,
                Modele = "Modele" + id,
                ReferenceBT = "Mat00" + id,
                NumeroDeSerie = id + 1,
                Fournisseur = id,
                CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = "admin",
                CreatedBy = "admin"
            };

            return materiel;
        }
        public List<Materiel> GetMateriels()
        {
            // replace with databse access
            List<Materiel> materiels = new List<Materiel>();
            for (int i = 1; i < 10; i++)
            {
                Materiel materiel = new Materiel
                {
                    Id = i,
                    Nom = "Materiel" + i,
                    Marque = "Marque" + i,
                    Modele = "Modele" + i,
                    ReferenceBT = "Mat00" + i,
                    NumeroDeSerie = i + 1,
                    Fournisseur = i,
                    CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss"),
                    LastUpdatedBy = "admin",
                    CreatedBy = "admin"
                };

                materiels.Add(materiel);
            }

            return materiels;
        }

        bool IMaterielAdapter.CreateMateriel(Materiel materiel)
        {
            // ajout in database
            return true;
        }
    }
}

