using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Stores;

namespace SocialNetworkAPI
// In local, to use SocialNetwaorkAPI : https://localhost:5001/swagger/index.html
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserStore, UserStore>();
            services.AddSingleton<ICommentStore, CommentStore>();
            services.AddSingleton<IPublicationStore, PublicationStore>();

            services.AddControllers()
                // Offer service to represent resources in xml
                .AddXmlSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { 
                    Title = "SocialNetwork API", 
                    Version = "v1",
                    Description = "Customers API to SocialNetworkAPI Swagger",
                    Contact = new Contact
                    {
                        Name = "De Brito Cyril & Fulgence Athur",
                        Email = "developpeur@cyrildebrito.info & arthurkevin.fulgence@gmail.com",
                        Url = "http://cyrildebrito.info/ & https://fr.linkedin.com/in/arthur-fulgence-abb871156"
                    },
                });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My SocialNetwork documentation"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // To use the redirection if is not in https
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
