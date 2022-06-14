using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InternetShopTechnic.model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TovarId { get; set; }
        public Tovar Tovar { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int Number { get; set; }

        public Status Status { get; set; }

        public string DateAndAddress { get; set; }
        
    }

    public enum Status
    {
        processing, assembled, delivered
    }
}
