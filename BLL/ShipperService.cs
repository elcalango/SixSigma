using DAL;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShipperService
    {
        private IConnectionFactory connectionFactory;

        public IEnumerable<Shipper> GetShippers( string searchTerm = null)
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var shipperRep = new ShipperRepository(context);

            return shipperRep.GetShippers(searchTerm);
        }

        public void CreateShipper (Shipper shipper)
        {
            try
            {
                connectionFactory = ConnectionHelper.GetConnection();

                var context = new DbContext(connectionFactory);

                var shipperRep = new ShipperRepository(context);

                shipperRep.CreateShipper(shipper);

                 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar Shipper! " + ex.Message);
            }
            
        }
    }
}
