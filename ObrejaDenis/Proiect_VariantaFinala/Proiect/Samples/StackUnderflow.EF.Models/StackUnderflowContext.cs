using System;
using Access.Primitives.EFCore.DSL;
using Access.Primitives.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StackUnderflow.DatabaseModel.Models;

namespace StackUnderflow.EF.Models
{
    public partial class StackUnderflowContext : DbContext
    {
        public StackUnderflowContext()
        {
        }

        public StackUnderflowContext(DbContextOptions<StackUnderflowContext> options)
            : base(options)
        {
        }

        public static Port<StackUnderflowContext> Factory(IServiceProvider sp)
            => from dbContext in DbContextDSL<StackUnderflowContext>.CreateDbContext(sp)
               select dbContext;

        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }
        public virtual DbSet<PostType> PostType { get; set; }
        public virtual DbSet<PostView> PostView { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<TenantUser> TenantUser { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBadge> UserBadge { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }
        public virtual DbSet<VoteType> VoteType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ACCESS-1303SF2\\SQL2017;Database=StackUnderflow;Integrated Security=true;");
            }
        }

        protected virtual string DefaultSchema => "base";
           
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
           
    }
}
