using ASP_NET_01._Mini_ASP;

WebHost host = new(27001);
host.UseStartup<Startup>();
host.Run();
