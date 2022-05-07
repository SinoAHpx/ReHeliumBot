namespace HeliumBot.Models;

public class ModuleMetadataAttribute : Attribute
{
    public string Name { get; set; }

    public string? HelpText { get; set; }
    
    public string? Description { get; set; }
    
    
}