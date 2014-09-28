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

        public virtual DbSet<count> counts { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<itemAttribute> itemAttributes { get; set; }
        public virtual DbSet<itemTemplate> itemTemplates { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<templateAttribute> templateAttributes { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<item>()
                .HasMany(e => e.counts)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.itemAttributes)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<item>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<itemTemplate>()
                .HasMany(e => e.items)
                .WithRequired(e => e.itemTemplate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<itemTemplate>()
                .HasMany(e => e.templateAttributes)
                .WithRequired(e => e.itemTemplate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<templateAttribute>()
                .HasMany(e => e.itemAttributes)
                .WithRequired(e => e.templateAttribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}