using CapaDatos;
using CapaModelo;

namespace CapaNegocio
{
    public class ProductNeg
    {
        public List<ProductModel> listarProductosSP ()
        {
            ProductData productData = new ProductData ();
            return productData.listarSP();
        }
        public List<ProductModel> listarProductos ()
        {
            ProductData productData = new ProductData ();
            return productData.listarProducts();
        }
        public List<ProductModel> filtrarProductoSP (string description)
        {
            ProductData productData = new ProductData();
            return productData.filterProductsSP (description);
        }
    }
}