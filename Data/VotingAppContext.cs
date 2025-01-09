using System;
using Microsoft.EntityFrameworkCore;
using VotingApp.Areas.Admin.Models;

namespace VotingApp.Data;

public partial class VotingAppContext : DbContext
{

    public virtual DbSet<VoteModel> tbVotes { get; set; }
    public virtual DbSet<VoteOptionModel> tbVoteOptions { get; set; }
    public virtual DbSet<JobModel> tbJobs { get; set; }
    public virtual DbSet<VoteResultModel> tbVoteResults { get; set; }
    public VotingAppContext(DbContextOptions<VotingAppContext> options) : base(options) { }

    public VotingAppContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GS00AG1\\SQLEXPRESS;Database=VotingAppDB;Trusted_Connection=True;TrustServerCertificate=True"); // Replace with your actual connection string
        }
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VoteModel>()
        .Property(v => v.voteId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<VoteOptionModel>()
        .Property(v => v.optionId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<VoteResultModel>()
        .Property(v => v.resultId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<JobModel>()
        .Property(v => v.jobId)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<VoteOptionModel>(entity =>
        {
            entity.
            HasOne(v => v.voteObj).
            WithMany(v => v.voteOptions).
            HasForeignKey(v => v.voteId);
        });

        modelBuilder.Entity<VoteResultModel>(entity =>
        {
            entity.
            HasOne(v => v.optionObj).
            WithMany(v => v.lstResults).
            HasForeignKey(v => v.optionId);
        });


        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200);
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8, 2)");
        configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
    }
}
