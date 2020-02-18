using InternationalBusinessDTOs;
using InternationalBusinessWebApiLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InternationalBusinessMenWebApi.Controllers
{
    [RoutePrefix("api/InternationalBusiness")]
    public class InternationalBusinessController : ApiController
    {
        private IInternationalBusinessAdapter _webapiModelAdapter;

        public InternationalBusinessController(IInternationalBusinessAdapter webapiModelAdapter)
        {
            this._webapiModelAdapter = webapiModelAdapter;
        }

        [Route("Version")]
        [HttpGet]
        public string Version()
        {
            return _webapiModelAdapter.Version();
        }

        [Route("Rates")]
        [HttpGet]
        public IHttpActionResult Rates()
        {
            try
            {
                return Ok(_webapiModelAdapter.GetRates());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("Transactions")]
        [HttpGet]
        public IHttpActionResult Transactions()
        {
            try
            {
                return Ok(_webapiModelAdapter.GetTransactions());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("TransactionBySku")]
        [HttpGet]
        public IHttpActionResult TransactionBySku(string sku)
        {
            try
            {
                IEnumerable<Transaction> result = _webapiModelAdapter.GetTransactionsBySku(sku);
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}