using SalesWeb.Models.Enums;
using System;

namespace SalesWeb.Models
{
    public class SalesRecord
    {
        //criar os DbSet no DbContext
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        
        //Cada vendedor pode possuir várias vendas
        //abaixo é criada a associação de N vendas para 1 vendedor
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}