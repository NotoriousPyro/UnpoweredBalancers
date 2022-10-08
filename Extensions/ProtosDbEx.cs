using Mafi.Core.Ports.Io;
using Mafi.Core.Factory.Zippers;
using Mafi.Core.Factory.Sorters;
using System;

namespace Mafi.Core.Prototypes;

public static class ProtosDbEx
{
    public static ZipperProto GetZipperProto(this ProtosDb protosDb, IoPortShapeProto.ID portShape) =>
        protosDb.GetOrThrow<ZipperProto>(IdsCore.Transports.GetZipperIdFor(portShape));
    public static SorterProto GetSorterProto(this ProtosDb protosDb, IoPortShapeProto.ID portShape) =>
        protosDb.GetOrThrow<SorterProto>(IdsCore.Transports.GetSorterIdFor(portShape));
}
