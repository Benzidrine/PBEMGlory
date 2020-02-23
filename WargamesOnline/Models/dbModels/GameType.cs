using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBEMGlory.Models.dbModels
{
    /// <summary>
    /// The name of a game type for description
    /// </summary>
    public class GameType
    {
        /// <summary>
        /// Integer id of the game type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the type of game - e.g. Tic Tac Toe
        /// </summary>
        public string Name { get; set; }
    }
}
