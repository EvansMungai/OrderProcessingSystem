using OrderProcessing.Worker.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWorkerServices(builder.Configuration);

var host = builder.Build();
host.Run();
