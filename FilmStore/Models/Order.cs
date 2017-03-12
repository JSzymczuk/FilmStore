using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStore.Models
{
    public enum OrderStatus
    {
        // Nieopłacone
        AwaitingPayment,
        // Opłacone
        AwaitingFulfillment,
        // Skompletowane
        AwaitingShipment,
        // Wysłane
        AwaitingPickup,
        // Zakończone
        Completed,
        // Anulowane
        Cancelled,
        // Nieprzyjęte
        Declined,
        // Zwrócone
        Refunded
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int AddressId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? SentDate { get; set; }

        public Order() { Positions = new List<OrderPosition>(); }

        [ForeignKey("ClientId")]
        public virtual AppUser Client { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public virtual ICollection<OrderPosition> Positions { get; set; }
    }

    public class OrderPosition
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}