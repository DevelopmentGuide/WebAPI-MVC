using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministrationController : Controller
    {
        private DataBaseContext user_data_context;
        public AdministrationController(DataBaseContext user_data_context)
        {
            this.user_data_context = user_data_context;
        }


        // CREATE, EDIT, DELETE OPERATIONS
        // INDEX
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return user_data_context.User.ToList();
        }

        // DETAILS
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return this.user_data_context.User.Where(user => user.UserId == id).FirstOrDefault();
        }

        // CREATE
        [HttpPost]
        public string Post([FromBody] Users New_User)
        {
            this.user_data_context.User.Add(New_User);
            this.user_data_context.SaveChanges();
            return "New User created successfully!";
        }


        // EDIT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users New_User)
        {
            this.user_data_context.User.Update(New_User);
            this.user_data_context.SaveChanges();
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.user_data_context.User.Remove(this.user_data_context.User.Where(New_User => New_User.UserId == id).FirstOrDefault());
            this.user_data_context.SaveChanges();
        }


        // DETAILS-MAIL
        [HttpGet("email/{email}")]
        public Users GetMail(string email)
        {
            return this.user_data_context.User.Where(user => user.Email == email).FirstOrDefault();
        }


        // EDIT-BYEMAIL
        [HttpPut("email/{email}")]
        public void PutMail(string email, [FromBody] Users New_User)
        {
            this.user_data_context.User.Update(New_User);
            this.user_data_context.SaveChanges();
        }

        // DELETE-BYEMAIL
        [HttpDelete("email/{email}")]
        public void DeleteMail(string email)
        {
            this.user_data_context.User.Remove(this.user_data_context.User.Where(New_User => New_User.Email == email).FirstOrDefault());
            this.user_data_context.SaveChanges();
        }

    }
}
