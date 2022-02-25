var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

app.MapGet("/", () => $"Hello New World! {DateTime.Now}");

app.Run();