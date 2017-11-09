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
                    PicturePath = "../Content/Media/branches/branch1.png"
                },
               new Branch()
                {
                    ID = 1,
                    Address = new Address() { Street ="HaHarash",
                                              City ="TLV",
                                              AppartmentNumber =13,
                                              Country ="Israel",
                                              HouseNumber =4},
                    Email ="branch1@foodNstuff.com",
                    Name = "Rotshild1",
                    OpeningHours ="Fri-Sun- Close, \nMon-Thi- 8:00-23:45",
                    PhoneNumber ="09-9833457",
                    PicturePath = "../Content/Media/branches/branch2.jpg"
                },
                new Branch()
                {
                    ID = 1,
                    Address = new Address() { Street ="HaHarash",
                                              City ="TLV",
                                              AppartmentNumber =13,
                                              Country ="Israel",
                                              HouseNumber =4},
                    Email ="branch1@foodNstuff.com",
                    Name = "Rotshild2",
                    OpeningHours ="Fri-Sun- Close, \nMon-Thi- 8:00-23:45",
                    PhoneNumber ="09-9833457",
                    PicturePath = "../Content/Media/branches/branch3.jpg"
                }
            };

            return branches;
        }
    }
}