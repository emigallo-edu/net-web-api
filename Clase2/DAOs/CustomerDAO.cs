using System;
using Clase2.DTOs;
using Clase2.Sources;

namespace Clase2.DAOs
{
    public class CustomerDAO
    {
        private SqlSource _sql;

        public CustomerDAO()
        {
            this._sql = new SqlSource();
        }

        public Boolean SaveCustomerInDB(CustomerDTO customer)
        {
            if (customer.LastSync.HasValue)
            {
                customer.LastSync = DateTime.Now;
                return this._sql.Update(customer);
            }

            customer.LastSync = DateTime.Now;
            return this._sql.Insert(customer);
        }
    }
}