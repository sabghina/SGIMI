﻿using BT.Stage.SGIMI.Data.Entity;
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

    public class SocieteTierceAdapter : ISocieteTierceAdapter

    //database data

    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public SocieteTierceAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public bool CreateSocieteTierce(Fournisseur societeTierce)
        {
            sGIMIDbContext.Fournisseurs.Add(societeTierce);
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

        public Fournisseur GetSocieteTierceById(int id)
        {
            Fournisseur societeTierce = sGIMIDbContext.Fournisseurs.Find(id);
            return societeTierce;
        }

        
        public List<Fournisseur> GetSocieteTierces()
        {
            List<Fournisseur> fournisseurs = sGIMIDbContext.Fournisseurs.ToList();
            List<Fournisseur> societeTierces = new List<Fournisseur> { };

            //Parcourir la liste avec foreach
            //foreach (Fournisseur fournisseur in fournisseurs)
            //{
            //    if (GetSocieteTierceTypeById(fournisseur.Id) == true)
            //    {
            //        //foreach (Fournisseur societeTierce in societeTierces)
            //        //{
            //        //    societeTierce.=fournisseur;
            //        //}
            //        societeTierces = new List<Fournisseur>() { fournisseur };
            //    }
            //}
            for (int i=0; i<=fournisseurs.Count();i++)
            {

                if (fournisseurs[i].Type == 'S')
                {
                    societeTierces.Add(fournisseurs[i]);
                }

                else
                {
                    return fournisseurs;
                }
            }
           
            return societeTierces;
        }

        public string GetNameSocieteTierceById(int id)
        {
            Fournisseur societeTierce = sGIMIDbContext.Fournisseurs.Find(id);
            return societeTierce.Nom;
        }

        public bool UpdateSocieteTierce(Fournisseur societeTierce)
        {
            sGIMIDbContext.Fournisseurs.AddOrUpdate(societeTierce);
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

        //public bool GetSocieteTierceTypeById(int id)
        //{
        //    Fournisseur fournisseur = sGIMIDbContext.Fournisseurs.Find(id);

        //    if (fournisseur.Type == 'S')
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}


// Static Data 

//    {
//        public bool CreateSocieteTierce(Fournisseur societeTierce)
//        {
//            // ajout in database
//            return true;
//        }
//        public Fournisseur GetSocieteTierceById(int id)
//        {
//            // replace with database access
//            Fournisseur societeTierce = new Fournisseur
//            {
//                Id = id,
//                Nom = "Societe Tierce" + id,
//                Email = "SocieteTierceemail" + id,
//                Telephone = "+216xxxxx",
//                Fax = "7xxxxxx",
//                Adresse = "Rue xxxxxxxx",
//                SiteWeb = "www.societe.com",
//                CreatedBy = "user" + id + 1,
//                CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
//                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
//                LastUpdatedBy = "admin",
//                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
//                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
//            };

//            return societeTierce;
//        }

//        public List<Fournisseur> GetSocieteTierces()
//        {
//            // replace with databse access
//            List<Fournisseur> societeTierces = new List<Fournisseur>();
//            for (int i = 1; i < 10; i++)
//            {
//                Fournisseur societeTierce = new Fournisseur
//                {
//                    Id = i,
//                    Nom = "Societe Tierce" + i,
//                    Email = "SocieteTierceemail" + i,
//                    Telephone = "+216xxxxx",
//                    Fax = "7xxxxxx",
//                    Adresse = "Rue xxxxxxxx",
//                    SiteWeb = "www.societe.com",
//                    CreatedBy = "user" + i + 1,
//                    CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
//                    CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
//                    LastUpdatedBy = "admin",
//                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
//                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
//                };

//                societeTierces.Add(societeTierce);
//            }
//            return societeTierces;
//        }
//        public bool UpdateSocieteTierce(Fournisseur societeTierce)
//        {
//            return true;

//        }
//    }
//}
