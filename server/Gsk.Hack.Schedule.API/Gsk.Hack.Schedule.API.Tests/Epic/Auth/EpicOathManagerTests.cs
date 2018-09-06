using Gsk.Hack.Schedule.API.Epic.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gsk.Hack.Schedule.API.Tests.Epic.Auth
{
    [TestClass]
    public class EpicOathManagerTests
    {
        [TestMethod]
        public void MakeMetaDataRequest_ShouldSucceed()
        {
            var manager = new EpicOathManager();
            var response = manager.MakeMetaDataRequest();

        }

        [TestMethod]
        public void MaakeAccessRequest_UsesTokenFromWebCallbackToGetOathObject_ReturnsAccessResponse()
        {
            const string code =
                "O46bl1nIP5PTKx2yjmg-cAhTz-2SasGogTVYbJx9WkT5LVuct5AJH0V8IhXk-4ExgBviGV1SRpgJyTUfXrP5oTAalhj6QCvIey0HmNKkIUEXQvRK5Q7P88gdBy1LplRp";
            var manager = new EpicOathManager();
            var result = manager.MakeAccessTokenRequest(code);
        }

        [TestMethod]
        public void GetPatientData()
        {
            const string accessToken =
                "uShtU44RfkfZnaWDmZWzNgkgNaY5OekraIuT8pHiMafL758peIxg2APdQJQ-02mMQ3omnly30b3P6ub4NTOe4Rvdp-UziAa5DVyxkd2cBVcd3Z72yo6wDe75JbpY3o1I";

            var manager = new EpicOathManager();
            var result = manager.FetchPatientData(accessToken);

            Assert.AreEqual("Patient", result.resourceType);
            Assert.IsTrue(result.active);
            Assert.AreEqual("male", result.gender);
            Assert.IsFalse(result.deceasedBoolean);
            Assert.AreEqual("Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB", result.id);

            Assert.AreEqual("Physician Family Medicine", result.careProvider[0].display);
            Assert.AreEqual("https://open-ic.epic.com/Argonaut/api/FHIR/DSTU2/Practitioner/T3Mz3KLBDVXXgaRoee3EKAAB", result.careProvider[0].reference);

            Assert.AreEqual("usual", result.name[0].use);
            Assert.AreEqual("JasonArgonaut", result.name[0].text);
            Assert.AreEqual("Argonaut", result.name[0].family);
            Assert.AreEqual("Jason", result.name[0].given);

            Assert.AreEqual("usual", result.identifier[0].use);
            Assert.AreEqual("urn:oid:1.2.840.114350.1.13.327.1.7.5.737384.0", result.identifier[0].system);
            Assert.AreEqual("E3826", result.identifier[0].value);
            Assert.AreEqual("usual", result.identifier[1].use);
            Assert.AreEqual("urn:oid:1.2.3.4", result.identifier[1].system);
            Assert.AreEqual("203579", result.identifier[1].value);

            Assert.AreEqual("home", result.address[0].use);
            Assert.AreEqual("1979 Milky Way Dr.", result.address[0].line[0]);
            Assert.AreEqual("Verona", result.address[0].city);
            Assert.AreEqual("WI", result.address[0].state);
            Assert.AreEqual("53593", result.address[0].postalCode);
            Assert.AreEqual("US", result.address[0].country);

            Assert.AreEqual("temp", result.address[1].use);
            Assert.AreEqual("5301 Tokay Blvd", result.address[1].line[0]);
            Assert.AreEqual("MADISON", result.address[1].city);
            Assert.AreEqual("WI", result.address[1].state);
            Assert.AreEqual("53711", result.address[1].postalCode);
            Assert.AreEqual("US", result.address[1].country);
            Assert.AreEqual("2011-08-04T00:00:00Z", result.address[1].period.start);
            Assert.AreEqual("2014-08-04T00:00:00Z", result.address[1].period.end);

        }
    }

}