using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Lender.Service;
using Domain.Loan.Service;
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
        public LoansController(IUserService userService,ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }
        // GET: api/Loans
        [HttpGet]
        [ActionName("GetAllLoanersAndLenders")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var allLoanAndLenders = _userService.GetAllLendersAndLoaners().ToList();
            return new ObjectResult(JsonConvert.SerializeObject(allLoanAndLenders));
        }

        // GET: api/Loans/5
        [HttpGet("{id}", Name = "Get")]
        [ActionName("GetLoansByUserId")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            var userLoans = _loanService.GetLoanByUserId(id).ToList();
            return new ObjectResult(JsonConvert.SerializeObject(userLoans));
        }

        // POST: api/Loans
        [HttpPost]
        [ActionName("AddUser")]
        public void AddUser([FromBody] string value)
        {
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
