﻿using Devify.Application.DTO;
using Devify.Application.Interfaces;
using Devify.Entity;
using Devify.Infrastructure.Persistance;
using Devify.Infrastructure.SeedWorks;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace Devify.Infrastructure.Services
{
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository  
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> getCurrentUser(string id)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(id);
                Console.WriteLine($"[AccountService] -> getAccountInformation with id:{id} -> successfully");
                return result;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"[AccountService] -> getAccountInformation with id:{id} -> failed -> ex: {ex} ");
                return null;
            }
            
        }

        public async Task<DetailAccountDTO> getUserById(string id)
        {
            return GetMulti(x=>x.Id == id,new string[] { "Creator" }).Select(u=>new DetailAccountDTO
            {
                Id = id,
                Username = u.UserName,
                DisplayName = u.DisplayName,
                Image = u.Image,
                Email= u.Email,
                PhoneNumber= u.PhoneNumber,
                Creator = new Creator
                {
                    CreatorId = id,
                    FacebookUrl = u.Creator.FacebookUrl,
                    LinkedInUrl = u.Creator.LinkedInUrl,
                    Slug = u.Creator.Slug,                  
                },
            }).FirstOrDefault();
        }

        public async Task<ApplicationUser> getUserByName(string name)
        {
            try
            {
                var result = await _userManager.FindByNameAsync(name);
                Console.WriteLine($"[AccountService] -> getUserByName with id:{name} -> successfully");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AccountService] -> getUserByName with id:{name} -> failed -> ex: {ex} ");
                return null;
            }
        }
    }
}
