using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.DAL;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.BLL.Services
{
    public class PsychologistService : IPsychologistService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<User> _users;

        public PsychologistService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _users = context.Set<User>();
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .Where(u => u.UserRoles.Select(ur => ur.Role.Name).Contains(Roles.Psychologist))
                    .FirstOrDefaultAsync(u => u.Email == email);

                var model = _mapper.Map<UserModel>(user);

                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            try
            {
                var users = await _users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .Where(u => u.UserRoles.Select(ur => ur.Role.Name).Contains(Roles.Psychologist))
                    .ToListAsync();

                var models = _mapper.Map<IEnumerable<UserModel>>(users);

                return models;
            }
            catch (Exception)
            {
                return new List<UserModel>();
            }
        }

        public async Task<bool> SignDeclarationAsync(string psychologistEmail, string clientEmail)
        {
            try
            {
                var client = await _users.FirstOrDefaultAsync(
                    u => u.Email == clientEmail &&
                    u.UserRoles.Select(ur => ur.Role.Name).Contains(Roles.Client));

                if (client is null || 
                    !string.IsNullOrWhiteSpace(client.PsychologistEmail))
                {
                    return false;
                }

                var psychologist = await _users.FirstOrDefaultAsync(
                    u => u.Email == psychologistEmail && 
                    u.UserRoles.Select(ur => ur.Role.Name).Contains(Roles.Psychologist));

                if (psychologist is null)
                {
                    return false;
                }

                client.PsychologistEmail = psychologist.Email;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserModel>> GetClientsAsync(string psychologistEmail)
        {
            try
            {
                var users = await _users
                    .Where(u => u.PsychologistEmail == psychologistEmail)
                    .ToListAsync();

                var models = _mapper.Map<IEnumerable<UserModel>>(users);

                return models;
            }
            catch (Exception)
            {
                return new List<UserModel>();
            }
        }
    }
}
