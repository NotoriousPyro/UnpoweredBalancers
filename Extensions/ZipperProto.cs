using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;

namespace Mafi.Core.Factory.Zippers;

public static class ZipperProtoEx
{
    public static ZipperProto GetZipperProto(this ProtoRegistrator registrator, IoPortShapeProto.ID portShape) =>
        registrator.PrototypesDb.GetOrThrow<ZipperProto>(IdsCore.Transports.GetZipperIdFor(portShape));
}
