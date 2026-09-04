namespace Order.gRPC.Data
{
    public sealed class Order
    {
        private Order(Guid id, Guid customerId, string productName, int quantity, decimal price, DateTime cratedAt)
        {
            Id = id;
            CustomerId = customerId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            CratedAt = cratedAt;
        }

        public Guid Id { get; private set; }


        public Guid CustomerId { get; private set; }

        public string ProductName { get; private set; }

        public int Quantity { get; private set; } 

        public decimal Price { get; private set; } 

        public DateTime CratedAt { get; private set; }


        public static Order Create( Guid customerId, string productName, int quantity, decimal price, DateTime cratedAt)
        {
            return new Order(Guid.NewGuid(), customerId, productName, quantity, price, cratedAt);
        }


    }
}
