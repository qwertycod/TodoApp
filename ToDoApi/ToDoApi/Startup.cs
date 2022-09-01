using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Services;
using ToDoApi.Helper;

namespace ToDoApi
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
            services.Configure<ToDoDatabaseSettings>(
               Configuration.GetSection(nameof(ToDoDatabaseSettings)));

            services.AddSingleton<IToDoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ToDoDatabaseSettings>>().Value);

            services.AddSingleton<ToDoService>();

            services.Configure<UserDatabaseSettings>(
              Configuration.GetSection(nameof(UserDatabaseSettings)));

            services.AddSingleton<IUserDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);

            services.AddSingleton<UserService>();

            services.Configure<SubjectDatabaseSettings>(
              Configuration.GetSection(nameof(SubjectDatabaseSettings)));

            services.AddSingleton<ISubjectDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<SubjectDatabaseSettings>>().Value);
            services.AddSingleton<SubjectService>();

            services.Configure<StudentDatabaseSettings>(
            Configuration.GetSection(nameof(StudentDatabaseSettings)));
            services.AddSingleton<IStudentDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<StudentDatabaseSettings>>().Value);
            services.AddSingleton<StudentService>();

            services.Configure<CourseDatabaseSettings>(
            Configuration.GetSection(nameof(CourseDatabaseSettings)));
            services.AddSingleton<ICourseDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CourseDatabaseSettings>>().Value);
            services.AddSingleton<CourseService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IUserService, UserService>();

        //    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        //options =>
        //{
        //    options.LoginPath = new PathString("/users/login");
        //    options.AccessDeniedPath = new PathString("/auth/denied");
        //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    throw new System.Exception("our error");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
