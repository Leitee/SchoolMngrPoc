using Reinforced.Typings.Fluent;

namespace Pandora.NetStandard.Model
{
    public static class ReinforcedTypingsConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            builder.Global(config =>
            {
                config.CamelCaseForProperties(true);
                config.UseModules(true);
                config.AutoOptionalProperties(true);
                config.ExportPureTypings(true);
            });
        }
    }
}