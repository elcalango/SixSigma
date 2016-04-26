using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RegionRepository : Repository<Region>
    {
        private DbContext _context;
        public RegionRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Region> GetRegions()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "select RegionID, RegionDescription from Region";

                return this.ToList(command).ToList();
            }
        }
    }
}
