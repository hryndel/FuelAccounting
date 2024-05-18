using Microsoft.OpenApi.Models;

namespace FuelAccounting.API.Infrastructures
{
    static internal class DocumentExtensions
    {
        public static void GetSwaggerDocument(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Driver", new OpenApiInfo { Title = "Сущность водителя", Version = "v1" });
                c.SwaggerDoc("FuelAccountingItem", new OpenApiInfo { Title = "Сущность накладной", Version = "v1" });
                c.SwaggerDoc("Fuel", new OpenApiInfo { Title = "Сущность топлива", Version = "v1" });
                c.SwaggerDoc("FuelStation", new OpenApiInfo { Title = "Сущность АЗС", Version = "v1" });
                c.SwaggerDoc("Supplier", new OpenApiInfo { Title = "Сущность поставщика", Version = "v1" });
                c.SwaggerDoc("Trailer", new OpenApiInfo { Title = "Сущность полуприцепа", Version = "v1" });
                c.SwaggerDoc("Truck", new OpenApiInfo { Title = "Сущность грузовика", Version = "v1" });
                c.SwaggerDoc("User", new OpenApiInfo { Title = "Сущность пользователя", Version = "v1" });
                c.SwaggerDoc("Token", new OpenApiInfo { Title = "Токен", Version = "v1" });

                var filePath = Path.Combine(AppContext.BaseDirectory, "FuelAccounting.API.xml");
                c.IncludeXmlComments(filePath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Пожалуйста введите JWT-токен",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
        }

        public static void GetSwaggerDocumnetUI(this WebApplication app)
        {
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("Driver/swagger.json", "Водители");
                x.SwaggerEndpoint("FuelAccountingItem/swagger.json", "Накладные");
                x.SwaggerEndpoint("Fuel/swagger.json", "Виды топлива");
                x.SwaggerEndpoint("FuelStation/swagger.json", "АЗС");
                x.SwaggerEndpoint("Supplier/swagger.json", "Поставщики");
                x.SwaggerEndpoint("Trailer/swagger.json", "Полуприцепы");
                x.SwaggerEndpoint("Truck/swagger.json", "Грузовики");
                x.SwaggerEndpoint("User/swagger.json", "Пользователи");
                x.SwaggerEndpoint("Token/swagger.json", "Токен");
            });
        }
    }
}
