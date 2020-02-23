using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBEMGlory.Models.dbModels;

namespace PBEMGlory.Contexts
{
    /// <summary>
    /// The core database of this application that is used for auth and game storage
    /// </summary>
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
        { }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameType> GameTypes { get; set; }
    }
}
