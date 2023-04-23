using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data.ViewModels;
using Stripe;

namespace ShoppingCart.Controllers
{
    public class StripeDashboardController : Controller
    {
        public IActionResult StripeIndex()
        {
            var response = new StripeDashboardVM();

            var balanceService = new BalanceService();
            var balanceResult = balanceService.Get();
            response.Balance = balanceResult;

            var transactionService = new BalanceTransactionService();
            var transactionsResult = transactionService.List().ToList();
            response.Transactions = transactionsResult;

            var customerService = new CustomerService();
            var customerResult = customerService.List().ToList();
            response.Customers = customerResult;

            var chargeService = new ChargeService();
            var chargeResult = chargeService.List().ToList();
            response.Charges = chargeResult;

            var disputeService = new DisputeService();
            var disputeResult = disputeService.List().ToList();
            response.Disputes = disputeResult;

            var refundService = new RefundService();
            var refundResult = refundService.List().ToList();
            response.Refunds = refundResult;

            var productService = new ProductService();
            var productResult = productService.List().ToList();
            response.Products = productResult;

            return View(response);
        }
    }
}
 