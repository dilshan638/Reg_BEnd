using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBEnd.Models
{
    public class PaymentDetailContex: DbContext
    {
        public PaymentDetailContex(DbContextOptions<PaymentDetailContex> options) : base(options)
        {

        }

        public DbSet<Paymentdetail> Paymentdetails { get; set; }
    }
}
