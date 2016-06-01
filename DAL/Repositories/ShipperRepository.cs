using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Extensions;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class ShipperRepository : Repository<Shipper>
    {
        private DbContext _context;
        public ShipperRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Shipper> GetShippers(string searchTerm = null)
        {
            using (var command = _context.CreateCommand())
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pSearchTerm", DBNull.Value));
                else
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pSearchTerm", searchTerm));

                //SqlParameter p = new SqlParameter("@pSearchTerm", searchTerm);
                //command.Parameters.Add(p);
                command.CommandText = @"select ShipperID, CompanyName, Phone 
                                          from Shippers
                                         where CompanyName like '%' + @pSearchTerm + '%'
                                            or Phone like '%' + @pSearchTerm + '%'
                                            or @pSearchTerm is null";

                return this.ToList(command).ToList();
            }
        }

        public void CreateShipper(Shipper shipper)
        {
            using (var command = _context.CreateCommand())
            {
                if (shipper.ShipperID <= 0)
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@ShipperID", DBNull.Value));
                else
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@ShipperID", shipper.ShipperID));

                if (string.IsNullOrWhiteSpace(shipper.CompanyName))
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pCompanyName", DBNull.Value));
                else
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pCompanyName", shipper.CompanyName));

                if (string.IsNullOrWhiteSpace(shipper.Phone))
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pPhone", DBNull.Value));
                else
                    command.Parameters.Add(IDbCommandExtensions.CreateParameter(command, "@pPhone", shipper.Phone));


                command.CommandText = @"insert into Shippers (ShipperID, CompanyName, Phone )
                                        values (@pShipperID, @pCompanyName, @pPhone)";
            }
        }
    }
}
