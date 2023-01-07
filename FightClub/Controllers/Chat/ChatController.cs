﻿using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    public class ChatController : Controller
    {
        private IRepositoryContext _context;
        public ChatController(IRepositoryContext context)
        {
            _context = context;
        }

        public IActionResult AllChats()
        {
            return View(_context.GetAllEntityOfDb<Chat>());
        }

        public IActionResult CreateChat()
        {
            return View(new Chat());
        }

        public IActionResult ChattingRoom(Guid chatId)
        {
            Chat? chat = _context.GetAllEntityOfDb<Chat>()
                .Include(chatContext => chatContext.Massages)
                .FirstOrDefault(chatContext => chatContext.Id == chatId);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return BadRequest("Chat is not exist");
            }
        }

        public IActionResult EditChat(Guid chatId)
        {
            Chat? chat = _context.GetAllEntityOfDb<Chat>()
                .FirstOrDefault(chatContext => chatContext.Id == chatId);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return AllChats();
            }
        }
    }
}
