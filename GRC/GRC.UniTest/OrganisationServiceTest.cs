using GRC.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.UniTest;

public class OrganisationServiceTest
{
    private readonly OrganisationServiceTest organisationService;

    public OrganisationServiceTest()
    {
        var options = new DbContextOptionsBuilder<GrcContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new GrcContext();
       // organisationService = new OrganisationService(context);
    }
}

