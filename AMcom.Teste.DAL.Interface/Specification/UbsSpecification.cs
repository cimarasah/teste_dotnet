using AMcom.Teste.DAL.Interface.Entity;
using NetTopologySuite.Geometries;

namespace AMcom.Teste.DAL.Interface.Specification
{
    public class UbsSpecification : QuerySpecification<Ubs>
    {
        UbsNearSpecification leftSpecification;
        UbsAvaliacaoSpecification rightSpecification;

        public UbsSpecification(UbsNearSpecification left, UbsAvaliacaoSpecification right)
            : base(_ => true)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(Ubs o)
        {
            return this.leftSpecification.IsSatisfiedBy(o)
                && this.rightSpecification.IsSatisfiedBy(o);
        }
    }
}
