using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Microsoft.IdentityModel.Logging;
using Action = CamundaState.Models.Action;
using CamundaState;
using CamundaState.AppContext;
using CamundaState.BpmnInstaller;
using CamundaState.Init;
using CamundaState.Models;
using CamundaState.Repo;
using CamundaState.Services;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(opt => opt.SerializerSettings.Converters.Add(new StringEnumConverter()));

//Connect DataBase and Initialize DbSeedData.
builder.Services.AddDbContext<WorkflowContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WorkflowDb")!).UseSnakeCaseNamingConvention();
});
builder.Services.AddScoped<DbSeed>();
builder.Services.AddHostedService<DbInitializer>();

//Connect Camunda.
builder.Services.AddCamunda(appSettings!.CamundaRestApiUri, appSettings.CamundaRestAuthorization);

//Connect with DI repo's
builder.Services.AddTransient<IBaseRepository<Action>, ActionRepository>();
builder.Services.AddTransient<IBaseRepository<ObjectWf>, ObjectWfRepository>();
builder.Services.AddTransient<IBaseRepository<ProjectWf>, ProjectWfRepository>();
builder.Services.AddTransient<IBaseRepository<Status>, StatusRepository>();

//Connect with Di services
builder.Services.AddTransient<ICamundaTranslateService, CamundaTranslateService>();

//Adding property HttpContext for our appliaction.
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();


var app = builder.Build();
app.UseRouting();

//It uses for standard installing attributes to cash, there are like such Locale-Compare: en.
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
