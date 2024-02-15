namespace KOF.RouteMap.Domain.Tenant
{
    public class Tenant(int tenantId) : ITenant
    {
        public int TenantId { get; set; } = tenantId;
    }
}
