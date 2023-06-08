using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities;

public class Job
{
    public int JobId { get; set; }

    public string Nom { get; set; }

    public Organisation organisation { get; set; }

    public List<Personne> Personnes { get; set; }
}

