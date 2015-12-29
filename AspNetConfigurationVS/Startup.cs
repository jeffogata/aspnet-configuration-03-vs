namespace AspNetConfigurationVS
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.Configuration;

    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName.ToLower()}.json", true);

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            var commonSetting = _configuration["commonSetting"];
            var environmentSetting = _configuration["environmentSetting"];

            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    $"<div>Setting = {commonSetting}</div>" +
                    $"<div>Default Connection = {environmentSetting}</div>");
            });
        }
    }
}