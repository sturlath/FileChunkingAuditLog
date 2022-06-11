using Volo.Abp.Settings;

namespace FileChunkingAuditLog.Settings;

public class FileChunkingAuditLogSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FileChunkingAuditLogSettings.MySetting1));
    }
}
