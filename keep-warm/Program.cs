var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddSingleton<DbService>();

var app = builder.Build();
app.MapGet("/", async (DbService db) => await db.GetData());
app.MapGet("/health", async (DbService db) => await db.Connect());

app.Run();

public class DbService
{
    private bool _connected = false;

    public async Task Connect()
    {
        if (!_connected)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            _connected = true;
        }
    }

    public async Task<bool> GetData()
    {
        if (!_connected)
        {
            await Connect();
        }

        return true;
    }
}