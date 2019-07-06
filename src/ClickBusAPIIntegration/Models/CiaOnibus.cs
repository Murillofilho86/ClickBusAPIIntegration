namespace ClickBusIntegration.Model
{
    using ClickBusIntegration.Domain;
    using System.Collections.Generic;

    public class CiaOnibus 
    {
            public string Name { get; set; }
            
            public IList<Onibus> Onibus { get; set; }
    }
}