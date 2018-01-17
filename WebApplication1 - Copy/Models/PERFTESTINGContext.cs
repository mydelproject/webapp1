using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class PERFTESTINGContext : DbContext
    {
        public virtual DbSet<AutoTestResults> AutoTestResults { get; set; }

        // Unable to generate entity type for table 'dbo.Persons'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.newProdMethods'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.prodMehodsDegradation'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Auto_TestExecution'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Auto_TestNameRefData'. Please see the warning messages.

        public PERFTESTINGContext(DbContextOptions<PERFTESTINGContext> options)
           : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
