using DemoucronHeadless.Apis;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader()) ;

app.MapGet("/", () => "Hello World!");

app.MapGet("/saved-graph", GraphApi.GetSavedUnorderedGraph);
app.MapPost("/sort-graph", GraphApi.SortGraph);
app.MapPost("/set-flows", GraphApi.SetInformationFlows);

app.Run();
