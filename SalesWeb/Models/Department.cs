using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesWeb.Models
{
    public class Department
    {
        //criar os DbSet no DbContext
        public int Id { get; set; }
        public string Name { get; set; }

        //Departamento possui vários Sellers
        //Abaixo é criada a relação 1-n - 1 departamento para vários vendedores
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        //no construtor com parametros não incluir parametros que sejam Collections (Seller)
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //soma as vendas de todos os vendedores do departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}