using Gsk.Hack.Schedule.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsk.Hack.Schedule.API.Tests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetVaccines_ReadsFromTestTable_ShouldSucceed()
        {
            using (MySqlRepository repository = new MySqlRepository())
            {
                var recommendations = repository.GetVaccines("Margaret-Ann_De_Luca");
                Assert.IsTrue(recommendations.Count >= 8);
            }
        }

        [TestMethod]
        public void GetNumberOfRoomsAvailable_GetsMaxAvailableRooms_returnsInt()
        {
            using (MySqlRepository repository = new MySqlRepository())
            {
                int rooms = repository.GetNumberOfRoomsAvailable();
                Assert.AreEqual(2, rooms);
            }
        }
    }
}
