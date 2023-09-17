namespace GlobalErrorApp.Configurations;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder ApplicationBuilder)
            => ApplicationBuilder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }

