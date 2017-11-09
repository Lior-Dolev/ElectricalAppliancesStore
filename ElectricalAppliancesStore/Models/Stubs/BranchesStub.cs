using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricalAppliancesStore.Models.Stubs
{
    public static class BranchesStub
    {
        public static List<Branch> GetBranches()
        {
            List<Branch> branches = new List<Branch>()
            {
                new Branch()
                {
                    ID = 1,
                    Address = new Address() { Street ="HaHarash",
                                              City ="TLV",
                                              AppartmentNumber =13,
                                              Country ="Israel",
                                              HouseNumber =4},
                    Email ="branch1@foodNstuff.com",
                    Name = "Rotshild",
                    OpeningHours ="Fri-Sun- Close, \nMon-Thi- 8:00-23:45",
                    PhoneNumber ="09-9833457",
                    PicturePath = "../Content/Media/branches/branch1.png",
                    LocationCoordinates = new double[] { 51.503454,-0.119562 },
                    LocationDescription = "London Eye, London"
                },
               new Branch()
                {
                    ID = 2,
                    Address = new Address() { Street ="HaHarash",
                                              City ="TLV",
                                              AppartmentNumber =13,
                                              Country ="Israel",
                                              HouseNumber =4},
                    Email ="branch1@foodNstuff.com",
                    Name = "Rotshild1",
                    OpeningHours ="Fri-Sun- Close, \nMon-Thi- 8:00-23:45",
                    PhoneNumber ="09-9833457",
                    PicturePath = "../Content/Media/branches/branch2.jpg",
                    LocationCoordinates = new double[] { 51.499633,-0.124755 },
                    LocationDescription = "Palace of Westminster, London"
                },
                new Branch()
                {
                    ID = 3,
                    Address = new Address() { Street ="HaHarash",
                                              City ="TLV",
                                              AppartmentNumber =13,
                                              Country ="Israel",
                                              HouseNumber =4},
                    Email ="branch1@foodNstuff.com",
                    Name = "Rotshild2",
                    OpeningHours ="Fri-Sun- Close, \nMon-Thi- 8:00-23:45",
                    PhoneNumber ="09-9833457",
                    PicturePath = "../Content/Media/branches/branch3.jpg",
                    LocationCoordinates = new double[] { 51.5008636,-0.1241971 },
                    LocationDescription = "Westminster Bridge, London"
                }
            };

            return branches;
        }
    }
}