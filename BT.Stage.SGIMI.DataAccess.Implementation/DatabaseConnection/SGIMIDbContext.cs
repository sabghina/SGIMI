namespace BT.Stage.SGIMI.DataAccess.Implementation.DatabaseConnection
{
    using BT.Stage.SGIMI.Data.Entity;
    using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SGIMIDbContext : DbContext, ISGIMIDbContext
    {
        public SGIMIDbContext()
            : base("name=SGIMIDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Materiel> Materiels { get; set; }
        public virtual DbSet<Reclamation> Reclamations { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<UniteGestion> UniteGestions { get; set; }
       

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}