
namespace ClickBusIntegration.Model
{
    using System;

    public class Ticket 
    {
        public DateTime Hora { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; } 
        public Rodoviaria Rodoviaria { get; set; }
        public CiaOnibus CiaOnibus { get; set; }
    }
}