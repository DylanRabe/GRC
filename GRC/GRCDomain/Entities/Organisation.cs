using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities;

public class Organisation
{
    public int OrganisationId { get; set; }

    public string Nom { get; set; }

    public string Description { get; set; }
}
