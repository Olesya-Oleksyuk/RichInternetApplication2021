using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Models;
using ToDoListWeb.Models;

namespace ToDoListWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteService _noteService;

        public HomeController(ILogger<HomeController> logger,
            INoteService noteService)
        {
            _logger = logger;
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<NoteModel> AddNote(NoteModel model)
        {
            return await _noteService.AddNote(model);
        }

        [HttpGet]
        public async Task<List<NoteModel>> GetNotes()
        {
            return await _noteService.GetNotes();
        }
    }
}
