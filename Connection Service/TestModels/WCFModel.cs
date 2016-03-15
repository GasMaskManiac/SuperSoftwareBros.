namespace Three_Amigos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WCFModel : DbContext
    {
        public virtual DbSet<Contracts.DTOProducts> Products { get; set; }
        public virtual DbSet<Models.AllCategories> Categories { get; set; }
        public virtual DbSet<Contracts.DTOOrder> Order { get; set; }
    }
}