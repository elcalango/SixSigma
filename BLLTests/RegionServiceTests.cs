using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL.Tests
{
    [TestClass()]
    public class RegionServiceTests
    {
        private RegionService _service;
        [TestMethod()]
        public void GetRegionsTest()
        {
            _service = new RegionService();
            IList<Region> regions = _service.GetRegions();
            
            Assert.AreEqual(regions.Count, 4);
        }
    }
}