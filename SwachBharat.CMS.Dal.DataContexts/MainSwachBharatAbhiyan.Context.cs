﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwachBharat.CMS.Dal.DataContexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DevSwachhBharatMainEntities : DbContext
    {
        public DevSwachhBharatMainEntities()
            : base("name=DevSwachhBharatMainEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppConnection> AppConnections { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<country_states> country_states { get; set; }
        public virtual DbSet<state_districts> state_districts { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<tehsil> tehsils { get; set; }
        public virtual DbSet<UserInApp> UserInApps { get; set; }
        public virtual DbSet<Sauchalay_feedback> Sauchalay_feedback { get; set; }
        public virtual DbSet<Game_AnswerType> Game_AnswerType { get; set; }
        public virtual DbSet<Game_Slogan> Game_Slogan { get; set; }
        public virtual DbSet<GameDetail> GameDetails { get; set; }
        public virtual DbSet<GameMaster> GameMasters { get; set; }
        public virtual DbSet<GamePlayerDetail> GamePlayerDetails { get; set; }
        public virtual DbSet<AD_USER_MST_LIQUID> AD_USER_MST_LIQUID { get; set; }
        public virtual DbSet<AD_USER_MST_STREET> AD_USER_MST_STREET { get; set; }
        public virtual DbSet<AppDetail> AppDetails { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public virtual DbSet<CheckAppD> CheckAppDs { get; set; }
        public virtual DbSet<AEmployeeMaster> AEmployeeMasters { get; set; }
    
        public virtual int SP_Admin_table()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Admin_table");
        }
    
        public virtual ObjectResult<SP_Admin2_Result> SP_Admin2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Admin2_Result>("SP_Admin2");
        }


        public virtual ObjectResult<SP_ULBADMIN_Result> SP_ULBADMIN(Nullable<int> divisionIdIn, Nullable<int> districtIdIn, Nullable<int> appIdIN, Nullable<int> userId)
        {
            var divisionIdInParameter = divisionIdIn.HasValue ?
                new ObjectParameter("DivisionIdIn", divisionIdIn) :
                new ObjectParameter("DivisionIdIn", typeof(int));

            var districtIdInParameter = districtIdIn.HasValue ?
                new ObjectParameter("DistrictIdIn", districtIdIn) :
                new ObjectParameter("DistrictIdIn", typeof(int));

            var appIdINParameter = appIdIN.HasValue ?
                new ObjectParameter("AppIdIN", appIdIN) :
                new ObjectParameter("AppIdIN", typeof(int));

            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ULBADMIN_Result>("SP_ULBADMIN", divisionIdInParameter, districtIdInParameter, appIdINParameter, userIdParameter);
        }
    }
}
