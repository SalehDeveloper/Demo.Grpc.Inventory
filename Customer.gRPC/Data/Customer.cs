namespace Customer.gRPC.Data
{
    public  sealed class Customer
    {
        private Customer(Guid id, string name, string address, DateTime dateOfBirth, string? secondaryAddress)
        {
            Id = id;
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
            SecondaryAddress = secondaryAddress;
        }

        public Guid Id { get; private set; }


        public string Name { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public DateTime DateOfBirth { get; private set; }

        public string? SecondaryAddress { get; private set; }


       public static Customer Create( string name, string address, DateTime dateOfBirth, string? secondaryAddress)
        {
            return new Customer(Guid.NewGuid(), name, address, dateOfBirth, secondaryAddress);
        }

    }
}
