using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBEMGlory.Accessors;
using PBEMGlory.Contexts;
using PBEMGlory.Models;
using PBEMGlory.Models.dbModels;

namespace PBEMGlory.Controllers
{
    public class LobbyController : Controller
    {
        private CoreContext _coreContext;
        public LobbyController(CoreContext coreContext)
        {
            _coreContext = coreContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewGame()
        {
            AddNewGameModel model = new AddNewGameModel();
            model.gameTypes = _coreContext.GameTypes.ToList();
            return View("Lobby/AddNewGame", model);
        }
    }
}