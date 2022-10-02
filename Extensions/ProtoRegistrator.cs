using Mafi.Core.Mods;

public static class ProtoRegistratorEx
{
    public static ZipperProtoBuilder ZipperProtoBuilder(this ProtoRegistrator registrator)
        => new ZipperProtoBuilder(registrator);
}
