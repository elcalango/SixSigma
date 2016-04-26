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
    public class RegionService
    {
        private IConnectionFactory connectionFactory;

        public IList<Region> GetRegions()
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var regionRep = new RegionRepository(context);

            return regionRep.GetRegions();
        }
    }
}
