using AMcom.Teste.DAL.Interface.Entity;
using NetTopologySuite.Geometries;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public class UbsAvaliacaoSpecification : QuerySpecification<Ubs>
    {
        public UbsAvaliacaoSpecification()
           : base(_ => true) { }
    }
}
