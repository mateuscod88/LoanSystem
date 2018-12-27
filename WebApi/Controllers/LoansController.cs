using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Lender.Service;
using Domain.Loan.Model;
using Domain.Loan.Service;
using Domain.User.Model;
using Domain.User.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private IUserService _userService;
        private ILoanService _loanService;
        public LoansController(IUserService userService, ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }
        // GET: api/Loans
        [HttpGet]
        public ActionResult<IEnumerable<UserModelWithOperationType>> GetAllLoanersAndLenders()
        {
            var allLoanAndLenders = _userService.GetAllLendersAndLoaners().ToList();
            return allLoanAndLenders;
        }

        // GET: api/Loans/5
        [HttpGet("{id}", Name = "GetLoansByUserId")]
        public ActionResult<IEnumerable<LoanModel>> GetLoansByUserId(int id)
        {
            var userLoans = _loanService.GetLoanByUserId(id).ToList();
            return userLoans;
        }
        // GET: api/Loans/5
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<IEnumerable<UserModel>> GetUserById(int id)
        {
            var user = _userService.GetUserById(id).ToList();
            return user;
        }
        // POST: api/Loans
        [HttpPost]
        [ActionName("AddUser")]
        public IActionResult AddUser([FromBody] UserModel user)
        {
            try
            {

                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _userService.AddUser(user);
                return CreatedAtRoute("GetUserById", new { id = user.Id }, user);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }

        }
        [HttpPost]
        [ActionName("AddLoan")]
        public void AddLoan([FromBody] string value)
        {
        }

        // PUT: api/Loans/5
        [HttpPut("{id}")]
        [ActionName("PayBackLoan")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
