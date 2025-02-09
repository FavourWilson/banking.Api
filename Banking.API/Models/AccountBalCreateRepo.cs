﻿using Banking.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class AccountBalCreateRepo
    {
        public Guid AccountDetailID { get; set; }
        
        public decimal Deposit { get; set; }
       
        public decimal Withdrawal { get; set; }
        
        public decimal TotalBalance { get; set; }
        
        public DateTimeOffset DateOftransaction { get; set; }

       

    }
}
