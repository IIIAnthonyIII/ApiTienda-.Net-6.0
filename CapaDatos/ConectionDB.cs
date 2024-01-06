using Microsoft.Extensions.Configuration;

namespace CapaDatos
{
  public class ConectionDB
  {
    public string cadena {  get; set; }
    public ConectionDB () 
    {
       IConfigurationBuilder builder = new ConfigurationBuilder();
       builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
       var root = builder.Build();
       cadena = root.GetConnectionString("ConnectionDB");
    }
  }
}