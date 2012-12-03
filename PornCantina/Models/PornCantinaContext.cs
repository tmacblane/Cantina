using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PornCantina.Models
{
	public class PornCantinaContext : DbContext
	{
		#region Constructors

		public PornCantinaContext()
			: base("PornCantinaDB")
		{
		}

		#endregion

		#region Type specific properties

		public DbSet<Gallery> Galleries
		{
			get;
			set;
		}

		public DbSet<Model> Models
		{
			get;
			set;
		}

		public DbSet<Image> Images
		{
			get;
			set;
		}

		public DbSet<WebSite> WebSites
		{
			get;
			set;
		}

		#endregion

		#region Base class overrides

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

		#endregion
	}
}