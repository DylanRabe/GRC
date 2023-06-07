using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//cette interface implement concretement le modelConfig au Modelbuilder
// puis dans le db context on ajoute le modelconfig


namespace GRC.SharedKernel.Configuration;

public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
