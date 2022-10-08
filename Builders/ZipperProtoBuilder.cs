using Mafi.Core.Economy;
using Mafi.Core.Entities.Static;
using Mafi.Core.Prototypes;
using Mafi.Core.Factory.Zippers;


namespace Mafi.Core.Mods;

public class ZipperProtoBuilder : IProtoBuilder
{
    public class State : LayoutEntityBuilderState<State>
    {
        private readonly StaticEntityProto.ID m_id;

        public State(ZipperProtoBuilder builder, StaticEntityProto.ID id, string name)
            : base(builder, id, name)
        {
            m_id = id;
        }

        [MustUseReturnValue]
        public override State Description(string description, string explanation = "short description of a machine")
        {
            return base.Description(description, explanation);
        }

        [MustUseReturnValue]
        public State SetElectricityConsumption(Electricity electricity)
        {
            base.Electricity = electricity;
            return (State)this;
        }

        [MustUseReturnValue]
        public State SetDeconstructionParams(AssetValue productGiven, EntityCosts entityCosts)
        {
            // Assert.That(productGiven.IsNotEmpty).IsTrue();
            // Assert.That(durationPerProduct).IsPositive();
            // m_durationPerProduct = durationPerProduct;
            // m_productsGiven = productGiven;
            return this;
        }

        public ZipperProto BuildAndAdd()
        {
            return AddToDb(new ZipperProto(m_id, base.Strings, layout: base.LayoutOrThrow, costs: base.Costs, base.Electricity, graphics: base.Graphics));
        }
    }

    public ProtosDb ProtosDb => Registrator.PrototypesDb;

    public ProtoRegistrator Registrator
    {
        get;
    }

    public ZipperProtoBuilder(ProtoRegistrator registrator)
        : base()
    {
        Registrator = registrator;
    }

    public State Start(string name, StaticEntityProto.ID labId)
    {
        return new State(this, labId, name);
    }
}
