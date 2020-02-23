using PBEMGlory.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBEMGlory.Models
{
    public class AddNewGameModel
    {
        /// <summary>
        /// Game details to add
        /// </summary>
        public Game game { get; set; }
        public List<GameType> gameTypes { get; set; }

    }
}
