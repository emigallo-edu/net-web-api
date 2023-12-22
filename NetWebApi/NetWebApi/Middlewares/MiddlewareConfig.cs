namespace NetWebApi.Middlewares
{
    public static class MiddlewareConfig
    {
        public static IApplicationBuilder SetsUpSingleRequestDelegateThatHandlesAllRequests(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Servicio temporalmente deshabilitado");
            });
            return app;
        }

        public static IApplicationBuilder SetUpUseAndRun(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });

            // Interrumpe el llamado al endpoint
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 2nd delegate.");
            });

            return app;
        }

    }
}