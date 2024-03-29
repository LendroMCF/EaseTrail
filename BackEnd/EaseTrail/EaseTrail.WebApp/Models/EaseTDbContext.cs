using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EaseTrail.WebApp.Models;

public partial class EaseTDbContext : DbContext
{
    public EaseTDbContext()
    {
    }

    public EaseTDbContext(DbContextOptions<EaseTDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    public virtual DbSet<AccountPlan> AccountPlans { get; set; }

    public virtual DbSet<Collaborator> Collaborators { get; set; }

    public virtual DbSet<CollaboratorAbility> CollaboratorAbilities { get; set; }

    public virtual DbSet<Function> Functions { get; set; }

    public virtual DbSet<OriginStatus> OriginStatuses { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<PlanFunction> PlanFunctions { get; set; }

    public virtual DbSet<SystemTransaction> SystemTransactions { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamAccount> TeamAccounts { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LEANDRO;Initial Catalog=EaseT_db;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Abilitie__3214EC074E057795");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC070877A33C");

            entity.ToTable("Account");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Code)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountD__3214EC0780AD1D2A");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.AccountDetails)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__AccountDe__Accou__412EB0B6");
        });

        modelBuilder.Entity<AccountPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountP__3214EC07CA9B7FF2");

            entity.ToTable("AccountPlan");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PlanId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.AccountPlans)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__AccountPl__Accou__440B1D61");

            entity.HasOne(d => d.Plan).WithMany(p => p.AccountPlans)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK__AccountPl__PlanI__44FF419A");
        });

        modelBuilder.Entity<Collaborator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collabor__3214EC077F6142DD");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Link1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Link2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Link3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ValuePerHour).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Collaborators)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Collabora__Accou__5BE2A6F2");
        });

        modelBuilder.Entity<CollaboratorAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collabor__3214EC07425C5F9C");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AbilityId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CollaboratorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Ability).WithMany(p => p.CollaboratorAbilities)
                .HasForeignKey(d => d.AbilityId)
                .HasConstraintName("FK__Collabora__Abili__619B8048");

            entity.HasOne(d => d.Collaborator).WithMany(p => p.CollaboratorAbilities)
                .HasForeignKey(d => d.CollaboratorId)
                .HasConstraintName("FK__Collabora__Colla__60A75C0F");
        });

        modelBuilder.Entity<Function>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Function__3214EC075FAC0157");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OriginStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OriginSt__3214EC0781E15F7B");

            entity.ToTable("OriginStatus");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OriginStatus1).HasColumnName("OriginStatus");

            entity.HasOne(d => d.Account).WithMany(p => p.OriginStatuses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__OriginSta__Accou__47DBAE45");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plans__3214EC07C32DFB0B");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PlanFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlanFunc__3214EC07E1A5491A");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FunctionId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PlanId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Function).WithMany(p => p.PlanFunctions)
                .HasForeignKey(d => d.FunctionId)
                .HasConstraintName("FK__PlanFunct__Funct__3B75D760");

            entity.HasOne(d => d.Plan).WithMany(p => p.PlanFunctions)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK__PlanFunct__PlanI__3C69FB99");
        });

        modelBuilder.Entity<SystemTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemTr__3214EC0791110529");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SenderId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Sender).WithMany(p => p.SystemTransactions)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__SystemTra__Sende__59063A47");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC0727297B0C");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Teams)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Teams__AccountId__4E88ABD4");
        });

        modelBuilder.Entity<TeamAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamAcco__3214EC075DE6146C");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TeamId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.TeamAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__TeamAccou__Accou__5165187F");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamAccounts)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__TeamAccou__TeamI__52593CB8");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC07D28FD1AE");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SenderId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Receiver).WithMany(p => p.TransactionReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__Transacti__Recei__5629CD9C");

            entity.HasOne(d => d.Sender).WithMany(p => p.TransactionSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Transacti__Sende__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC077BBF91B3");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OriginId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OriginStatusId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Users__AccountId__4AB81AF0");

            entity.HasOne(d => d.OriginStatus).WithMany(p => p.Users)
                .HasForeignKey(d => d.OriginStatusId)
                .HasConstraintName("FK__Users__OriginSta__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
