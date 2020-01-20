using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Models
{
    public class Seller
    {
        //criar os DbSet no DbContext
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        //Cada vendedor possui 1 departamento
        //abaixo é criada a associação de 1 vendedor para cada departamento
        public Department Department { get; set; }

        //Cada vendedor pode possuir várias vendas
        //abaixo é criada a associação 1-n - 1 vendedor para N vendas
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        //no construtor com parametros não incluir parametros que sejam Collections (Seller)
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //adiciona uma venda à lista de vendas 
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        //remove uma venda da lista de vendas
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //calcula o total de vendas de um período
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}