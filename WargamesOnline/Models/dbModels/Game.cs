using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBEMGlory.Models.dbModels
{
    public class Game
    {
        /// <summary>
        /// Integer id of the game
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User given game name
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// This int is the id of various game types
        /// </summary>
        public int GameTypeId { get; set; }
        /// <summary>
        /// Password user has given to the game
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Id of the player that created the game
        /// </summary>
        public int CreatorPlayerID { get; set; }
        /// <summary>
        /// Comment left by the player when creating the game to be a message in lobby
        /// </summary>
        public string Comment { get; set; }
    }
}
