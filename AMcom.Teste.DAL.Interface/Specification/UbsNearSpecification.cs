using AMcom.Teste.DAL.Interface.Entity;
using GeoAPI.Geometries;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public class UbsNearSpecification : QuerySpecification<Ubs>
    {
        public UbsNearSpecification(IPoint myLocation)
           : base(_ => true, ubs => ubs.Location.Distance(myLocation), false) { }
    }
}
