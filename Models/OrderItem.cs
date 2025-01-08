﻿namespace FenecApi.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int Quantity { get; set; }

		// Foreign Keys
		public int OrderId { get; set; }
		public int ProductId { get; set; }

		// Navigation properties
		public Order Order { get; set; }
		public Product Product { get; set; }
	}
}
