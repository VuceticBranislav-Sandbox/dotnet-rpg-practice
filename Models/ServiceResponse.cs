

namespace dotnet_rpg_practice.Models
{
    /// <summary>
    /// Response wrapper that provides payload, status and additional message.<br/> 
    /// <list type="bullet">
    ///   <item> <term>Data</term>    <description>Payload data.</description> </item>
    ///   <item> <term>Success</term> <description>Response status.</description> </item>
    ///   <item> <term>Message</term> <description>Additional message.</description> </item>
    /// </list>
    /// </summary>
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = false;
        public string? Message { get; set; } = null;
    }
}