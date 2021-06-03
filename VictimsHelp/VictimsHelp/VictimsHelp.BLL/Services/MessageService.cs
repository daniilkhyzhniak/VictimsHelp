using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Models;
using VictimsHelp.DAL;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Message> _messages;
        private readonly DbSet<User> _users;

        public MessageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _messages = _context.Set<Message>();
            _users = _context.Set<User>();
        }

        public async Task<IEnumerable<MessageModel>> GetMessagesAsync(string email1, string email2)
        {
            try
            {
                var messages = await _messages
                    .Where(m => (m.SenderEmail == email1 && m.ReceiverEmail == email2) || 
                    (m.SenderEmail == email2 && m.ReceiverEmail == email1))
                    .OrderBy(m => m.DateTime)
                    .ToListAsync();

                var models = _mapper.Map<IEnumerable<MessageModel>>(messages);

                return models;
            }
            catch (Exception ex)
            {
                return new List<MessageModel>();
            }
        }

        public async Task<bool> SendMessageAsync(MessageModel model)
        {
            try
            {
                if (model is null)
                {
                    return false;
                }

                if (model.SenderEmail == model.ReceiverEmail)
                {
                    return false;
                }

                var message = _mapper.Map<Message>(model);

                var sender = await _users.FirstOrDefaultAsync(
                    u => u.Email == message.SenderEmail);

                if (sender is null)
                {
                    return false;
                }

                message.SenderName = sender.FirstName;
                message.DateTime = DateTime.Now;

                await _messages.AddAsync(message);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
