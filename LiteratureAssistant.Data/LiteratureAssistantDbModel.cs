namespace LiteratureAssistant.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LiteratureAssistant.Core.Models;

    public partial class LiteratureAssistantDbModel : DbContext
    {
        public LiteratureAssistantDbModel()
            : base("name=LiteratureAssistantDbEntities")
        {
        }

        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<itemAttribute> itemAttributes { get; set; }
        public virtual DbSet<itemTemplate> itemTemplates { get; set; }
        public virtual DbSet<templateAttribute> templateAttributes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<itemTemplate>()
                .HasMany(e => e.templateAttributes)
                .WithRequired(e => e.itemTemplate)
                .WillCascadeOnDelete(false);
        }
    }
}
