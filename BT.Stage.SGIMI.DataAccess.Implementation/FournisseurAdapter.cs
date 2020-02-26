﻿using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class FournisseurAdapter : IFournisseurAdapter
    {
        public Fournisseur GetFournisseurById(int id)
        {
            // replace with database access
            Fournisseur fournisseur = new Fournisseur
            {
                Id = id,
                Nom = "Fournisseur" + id,
                CreatedBy = id + 1
            };

            return fournisseur;
        }

        public List<Fournisseur> GetFournisseurs()
        {
            // replace with databse access
            List<Fournisseur> fournisseurs = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur fournisseur = new Fournisseur
                {
                    Id = i,
                    Nom = "Fournisseur" + i,
                    CreatedBy = i + 1
                };

                fournisseurs.Add(fournisseur);
            }

            return fournisseurs;
        }
    }
}