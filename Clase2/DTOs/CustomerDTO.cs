using System;
namespace Clase2.DTOs
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastSync { get; set; }

        public void NormalizeName()
        {
            this.Name = this.Name.ToUpper().Trim();
        }

        public Boolean IsSameCustomer(CustomerDTO item)
        {
            return this.Id == item.Id;
        }

        public CustomerDTO Clone()
        {
            return new CustomerDTO()
            {
                Id = this.Id,
                Name = this.Name,
                LastSync = this.LastSync
            };
        }
    }
}