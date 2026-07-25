var builder = DistributedApplication.CreateBuilder(args);


var sql = builder.AddSqlServer("sql")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithEndpointProxySupport(false);

var db = sql.AddDatabase("CubeTimeAnalyzer");

var api = builder.AddProject<Projects.CubeTimeAnalyzer_Api>("Api")
    .WithArgs("--Aspire")
    .WithReference(db)
    .WaitFor(db)
    .WithEnvironment("SQL_Connection_String", db);

builder.AddProject<Projects.CubeTimeAnalyzer_App>("Frontend")
    .WithArgs("--Aspire")
    .WaitFor(api);

await builder.Build().RunAsync();
