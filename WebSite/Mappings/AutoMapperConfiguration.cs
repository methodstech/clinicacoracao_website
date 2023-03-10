namespace WebSite.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize((cfg) =>
            {
                cfg.AddProfiles(IoC.AutoMapperConfiguration.GetAutoMapperProfiles());
            });
        }
    }
}