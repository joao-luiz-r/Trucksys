namespace TruckSys.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TruckContext context)
        {
            context.Database.EnsureCreated();   
        }

    }
}
