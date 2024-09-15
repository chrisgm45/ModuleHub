#region   USNIGS

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using ModuleHub.Domain.Entities.Common;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleHub.DataAccess.FluentConfigurations;
using ModuleHub.DataAccess.FluentConfigurations.Common;
using ModuleHub.Domain.Entities;

#endregion

namespace ModuleHub.DataAccess.Contexts
{

    /// <summary>
    /// Modela todo el Contexto de la Base de Datos
    /// </summary>
    public class ApplicationContext : DbContext
    {


        #region    TABLES


        /// <summary>
        /// Tabla para los <see cref="DataSource"/>
        /// </summary>
        public DbSet<DataSource> DataSources { get; set; }


        /// <summary>
        /// Tabla para los <see cref="CommunicationClient/>
        /// </summary>
        public DbSet<CommunicationClient> CommunicationClients { get; set; }


        /// <summary>
        /// Tabla para los <see cref="CommunicationNode"/>
        /// </summary>
        public DbSet<CommunicationNode> CommunicationNodes { get; set; }


        #endregion


        #region    CONSTRUCTORS

        /// <summary>
        /// Requerido por EntittyFramework
        /// </summary>
        public ApplicationContext()
        {
        }


        /// <summary>
        /// Inicializa el Application Context de la Base de Datos
        /// </summary>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        {
        }


        /// <summary>
        ///  Inicializa el Application Context de la Base de Datos
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }



        /// <summary>
        /// Permite configurar la tecnología a emplear para la BD  (( " SQLITE " ))
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }


        /// <summary>
        /// Organiza la estructura de la base de datos. (( qué tipo de dato va a qué tabla ))
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Relacion de 1 a 1 entre DataSource y CommunicationClient
            modelBuilder.Entity<DataSource>().HasOne(p => p.CommunicationClient).WithOne(d => d.DataSource).HasForeignKey<CommunicationClient>(d => d.DataSourceId);


            // Crea las tablas de las Entidades que estaran en la Base de Datos
            modelBuilder.ApplyConfiguration(new CommunicationNodeEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new CommunicationClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DataSourceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ModbusNodeEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new OPCNodeEntityTypeConfiguration());

        }

        #endregion


        #region   HELPERS


        /// <summary>
        /// Indispensable para poder usar la funcion GetOptions declarada en el 2do Contructor de <see cref="ApplicationContext"/>
        /// </summary>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }


        #endregion




    }
}
