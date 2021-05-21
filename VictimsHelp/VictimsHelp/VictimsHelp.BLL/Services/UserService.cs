using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Enums;
using VictimsHelp.BLL.Models;
using VictimsHelp.DAL;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<User> _users;
        private readonly DbSet<Role> _roles;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _users = context.Set<User>();
            _roles = context.Set<Role>();
        }

        public async Task<IEnumerable<Claim>> AuthenticateAsync(UserModel model)
        {
            try
            {
                if (model is null)
                {
                    return new List<Claim>();
                }

                var user = await _users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user is null)
                {
                    return new List<Claim>();
                }

                if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    return new List<Claim>();
                }

                var claims = new List<Claim>
                { 
                    new Claim(ClaimType.Email, user.Email),
                    new Claim(ClaimType.Id, user.Id.ToString()),
                };
                claims.AddRange(user.UserRoles.Select(
                    userRole => new Claim(ClaimType.Role, userRole.Role.Name)));

                return claims;
            }
            catch (Exception)
            {
                return new List<Claim>();
            }
        }

        public async Task<bool> CreateAsync(UserModel model)
        {
            try
            {
                var user = await _users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    return false;
                }

                user = _mapper.Map<User>(model);
                foreach (var roleName in model.Roles)
                {
                    var role = await _roles.FirstOrDefaultAsync(r => r.Name == roleName);
                    user.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id });
                }

                await _users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task DeleteByEmailAsync(string email)
        {
            try
            {
                var user = await _users.FirstOrDefaultAsync(u => u.Email == email);

                if (user is null)
                {
                    return;
                }

                _users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task<bool> EditAsync(UserModel model)
        {
            try
            {
                if (model is null)
                {
                    return false;
                }

                var user = await _users
                    .Include(u => u.UserRoles)
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user is null)
                {
                    return false;
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Age = model.Age;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;

                await EditUserRolesAsync(user, model.Roles);

                _users.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private async Task EditUserRolesAsync(User user, ICollection<string> rolesNames)
        {
            rolesNames ??= new List<string>();

            foreach (var roleName in rolesNames)
            {
                var role = await _roles.FirstOrDefaultAsync(r => r.Name == roleName);

                if (user.UserRoles.FirstOrDefault(ur => ur.RoleId == role.Id) is null)
                {
                    user.UserRoles.Add(new UserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                        Role = role
                    });
                }
            }

            var rolesToDelete = user.UserRoles.Select(ur => ur.Role.Name).Except(rolesNames).ToList();

            foreach (var role in rolesToDelete)
            {
                var userRole = user.UserRoles.FirstOrDefault(ur => ur.Role.Name == role);
                user.UserRoles.Remove(userRole);
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            try
            {
                var users = await _users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .ToListAsync();

                var models = _mapper.Map<IEnumerable<UserModel>>(users);

                return models;
            }
            catch (Exception ex)
            {
                return new List<UserModel>();
            }
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Email == email);

                var model = _mapper.Map<UserModel>(user);

                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
