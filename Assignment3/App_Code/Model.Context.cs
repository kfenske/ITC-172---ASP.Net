﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class ShowTrackerEntities : DbContext
{
    public ShowTrackerEntities()
        : base("name=ShowTrackerEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Fan> Fans { get; set; }
    public virtual DbSet<FanArtist> FanArtists { get; set; }
    public virtual DbSet<FanGenre> FanGenres { get; set; }
    public virtual DbSet<FanLogin> FanLogins { get; set; }
    public virtual DbSet<LoginHistory> LoginHistories { get; set; }
}
