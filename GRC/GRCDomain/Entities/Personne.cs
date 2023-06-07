using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities;

public class Personne
{
    public int PersonneId { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string Email { get; set; }

    public Job job { get; set; }
}