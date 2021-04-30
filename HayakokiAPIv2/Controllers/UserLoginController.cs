using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HayakokiAPIv2.Models;

namespace HayakokiAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly HayakokiContext _context;

        public UserLoginController(HayakokiContext context)
        {
            _context = context;
        }
        // POST: api/UserLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginReturn>> PostLogin(UserQuery uq)
        {
            var reqData = await _context.Users
                          .Where(s => s.UserName == uq.uname)
                          .FirstOrDefaultAsync();
            var rd = new LoginReturn();
            if (reqData == null)
            {
                rd.password = "";
            }
            else
            {
                rd.password = reqData.Password;
                rd.id = reqData.UserId;
            }
            return rd;
        }


    }
}
