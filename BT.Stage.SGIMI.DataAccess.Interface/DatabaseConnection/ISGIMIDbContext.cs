using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection
{
    public interface ISGIMIDbContext
    {
        DbSet<Fournisseur> Fournisseurs { get; set; }
        DbSet<Materiel> Materiels { get; set; }
        DbSet<Reclamation> Reclamations { get; set; }
        DbSet<Intervention> Interventions { get; set; }
        DbSet<UniteGestion> UniteGestions { get; set; }
    }
}
