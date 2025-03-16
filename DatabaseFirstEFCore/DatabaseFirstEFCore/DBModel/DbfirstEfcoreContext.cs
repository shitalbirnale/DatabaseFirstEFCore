using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstEFCore.DBModel;

public partial class DbfirstEfcoreContext : DbContext
{
    public DbfirstEfcoreContext()
    {
    }

    public DbfirstEfcoreContext(DbContextOptions<DbfirstEfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;Database=DBFirstEFCore;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Age).IsUnicode(false);
            entity.Property(e => e.EmailAddress).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.PhoneNo).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
