namespace employeeManager.API.Models
{
    public class AddressRequest
    {
        public string Id { set; get; }
        public string City { set; get; }
        public string Street { set; get; }
    }

    public class ContactRequest
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string OfficeNumber { set; get; }

    }
}
