using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsRelations.Data;
using StudentsRelations.DTOs;
using StudentsRelations.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsRelations.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class AccountContolller : ControllerBase
    {
        public StudentsRelationsDBContext _context { get; }
        public AccountContolller(StudentsRelationsDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Account>> GetAccounts()
        {
            var allAccounts= await _context.Accounts.Include(m=>m.Student).ToListAsync();
            return allAccounts;
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountAddUIDTO account)
        {
            Account accountEntitiy = new()
            {
                Address = account.Address,
                StudentID = account.StudentID,
            };
            await _context.AddAsync(accountEntitiy);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAccounts(AccountUpdateUIDTO account)
        {
            Account accountEntity = new()
            {
                Id = account.Id,
                Address = account.Address,
                StudentID = account.StudentID,
            };
            var updatedAccount = await _context.Accounts.FindAsync(accountEntity.Id);
            if (updatedAccount == null)
            {
                return BadRequest();
            }
            updatedAccount.Address=account.Address;
            updatedAccount.StudentID=account.StudentID;
            _context.Accounts.Update(updatedAccount);
            await _context.SaveChangesAsync();
            return Ok();    
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var deletedEntity= await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(deletedEntity);
            return Ok();
        }
    }
}
