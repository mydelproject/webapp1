using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class PERFTESTINGContext : DbContext
    {
        public virtual DbSet<AutoTestExecution> AutoTestExecution { get; set; }
        public virtual DbSet<AutoTestNameRefData> AutoTestNameRefData { get; set; }
        public virtual DbSet<AutoTestResults> AutoTestResults { get; set; }

        // Unable to generate entity type for table 'dbo.Persons'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.newProdMethods'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.prodMehodsDegradation'. Please see the warning messages.

        public PERFTESTINGContext(DbContextOptions<PERFTESTINGContext> options): base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=PERFTESTING;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoTestExecution>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("Auto_TestExecution");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.ExecutionDate).HasColumnType("datetime");

                entity.Property(e => e.IsExecute)
                    .HasColumnName("isExecute")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ScriptName).IsUnicode(false);
            });

            modelBuilder.Entity<AutoTestNameRefData>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("Auto_TestNameRefData");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.ScriptName).IsUnicode(false);
            });

            modelBuilder.Entity<AutoTestResults>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("Auto_TestResults");

                entity.Property(e => e.Sno).HasColumnName("SNo");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Result).IsUnicode(false);

                entity.Property(e => e.ScriptName).IsUnicode(false);

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.TestName).IsUnicode(false);

                entity.Property(e => e.TestScenario).IsUnicode(false);
            });
        }
    }
}
