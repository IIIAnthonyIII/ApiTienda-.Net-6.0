using CapaModelo;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APITienda.Controllers
{
  [ApiController]
  [Route("productos")]
  public class ProductoController : ControllerBase
  {
    [HttpGet]
    public dynamic listarProdutos ()
    {
      ProductNeg productNegocio = new ProductNeg();
      string jsonProductos = JsonConvert.SerializeObject(productNegocio.listarProductosSP());
      return new
      {
        codigoRetorno = "0001",
        mensajeRetorno = "Consulta Ok",
        data = JsonConvert.DeserializeObject<List<ProductModel>>(jsonProductos)
      };
    }

    [HttpGet("listar2")]
    public dynamic listarProductos2 ()
    {
       ProductNeg productNegocio = new ProductNeg();
       string jsonProductos = JsonConvert.SerializeObject(productNegocio.listarProductos());
       return new
       {
          codigoRetorno = "0001",
          mensajeRetorno = "Consulta Ok",
          data = JsonConvert.DeserializeObject<List<ProductModel>>(jsonProductos)
        };
    }
    //...filtrar?value=busqueda
    [HttpGet("filtrar")]
    public dynamic filtrarProducto (string value)
    {
       ProductNeg productNegocio = new ProductNeg();
       string jsonProductos = JsonConvert.SerializeObject(productNegocio.filtrarProductoSP(value));
       return new
       {
          codigoRetorno = "0001",
          mensajeRetorno = "Consulta Ok",
          data = JsonConvert.DeserializeObject<List<ProductModel>>(jsonProductos)
        };
    }

    //[HttpPost]
    //[Route("agregar")]
    //public dynamic AgregarProducto (ProductModel product)
    //{
    //  List<Parametro> parametros = new List<Parametro>
    //  {
    //    new Parametro("@descriptionSP", product.description),
    //    new Parametro("@priceSP", product.price.ToString()),
    //    new Parametro("@detailSP", product.detail),
    //    new Parametro("@imageSP", product.image),
    //  };
    //  bool exito = ProductData.Ejecutar("insertProduct_SP", parametros);
    //  return new
    //  {
    //    codigoRetorno = "0001",
    //    mensajeRetorno = exito ? "Se ha guardado" : "Error al guardar",
    //    data = ""
    //  };
    //}
  }
}
