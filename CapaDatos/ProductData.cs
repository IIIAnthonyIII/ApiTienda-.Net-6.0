using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ProductData:ConectionDB
    {
        public List<ProductModel> listarSP ()
        {
            List<ProductModel> productsList = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("showProduct_SP", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);//Se reserva memoria para 1 consullta
                        if (reader != null)
                        {
                            ProductModel productModel;
                            productsList = new List<ProductModel>();
                            int postId = reader.GetOrdinal("idProduct");
                            int postDescription = reader.GetOrdinal("description");
                            int postPrice = reader.GetOrdinal("price");
                            int postDetail = reader.GetOrdinal("detail");
                            int postImage = reader.GetOrdinal("image");
                            while (reader.Read())
                            {
                                productModel = new ProductModel();
                                productModel.idProduct = reader.IsDBNull(postId) ? 0 : reader.GetInt64(postId);
                                productModel.description = reader.IsDBNull(postDescription) ? "" : reader.GetString(postDescription);
                                productModel.price = reader.IsDBNull(postPrice) ? 0 : reader.GetDouble(postPrice);
                                productModel.detail = reader.IsDBNull(postDetail) ? "" : reader.GetString(postDetail);
                                productModel.image = reader.IsDBNull(postImage) ? "" : reader.GetString(postImage);
                                productsList.Add(productModel);
                            }
                            cn.Close();
                        }
                    }
                } catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return productsList;
        }
        //Sin Stored produce
        public List<ProductModel> listarProducts ()
        {
            List<ProductModel> productsList = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select idProduct, detail, description,"+
                        " price, image from Product", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);//Se reserva memoria para 1 consullta
                        if (reader != null)
                        {
                            ProductModel productModel;
                            productsList = new List<ProductModel>();
                            int postId = reader.GetOrdinal("idProduct");
                            int postDescription = reader.GetOrdinal("description");
                            int postPrice = reader.GetOrdinal("price");
                            int postDetail = reader.GetOrdinal("detail");
                            int postImage = reader.GetOrdinal("image");
                            while (reader.Read())
                            {
                                productModel = new ProductModel();
                                productModel.idProduct = reader.IsDBNull(postId) ? 0: reader.GetInt64(postId);
                                productModel.description = reader.IsDBNull(postDescription) ? "" : reader.GetString(postDescription);
                                productModel.price = reader.IsDBNull(postPrice) ? 0 : reader.GetDouble(postPrice);
                                productModel.detail = reader.IsDBNull(postDetail) ? "" : reader.GetString(postDetail);
                                productModel.image = reader.IsDBNull(postImage) ? "" : reader.GetString(postImage);
                                productsList.Add(productModel);
                            }
                            cn.Close();
                        }
                    }
                } catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return productsList;
        }
        public List<ProductModel> filterProductsSP (string descriptionSP)
        {
            List<ProductModel> productsList = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("filterProduct_SP", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@description_SP", descriptionSP==null ? "" : descriptionSP);
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);//Se reserva memoria para 1 consullta
                        if (reader != null)
                        {
                            ProductModel productModel;
                            productsList = new List<ProductModel>();
                            int postId = reader.GetOrdinal("idProduct");
                            int postDescription = reader.GetOrdinal("description");
                            int postPrice = reader.GetOrdinal("price");
                            int postDetail = reader.GetOrdinal("detail");
                            int postImage = reader.GetOrdinal("image");
                            while (reader.Read())
                            {
                                productModel = new ProductModel();
                                productModel.idProduct = reader.IsDBNull(postId) ? 0 : reader.GetInt64(postId);
                                productModel.description = reader.IsDBNull(postDescription) ? "" : reader.GetString(postDescription);
                                productModel.price = reader.IsDBNull(postPrice) ? 0 : reader.GetDouble(postPrice);
                                productModel.detail = reader.IsDBNull(postDetail) ? "" : reader.GetString(postDetail);
                                productModel.image = reader.IsDBNull(postImage) ? "" : reader.GetString(postImage);
                                productsList.Add(productModel);
                            }
                            cn.Close();
                        }
                    }
                } catch (Exception ex)
                {
                    cn.Close();
                }
            }
            return productsList;
        }
        public static bool Ejecutar (string nombreProcedimiento, List<Parametro>? parametros = null)
        {
            ConectionDB conectionBD = new ConectionDB();
            SqlConnection conexion = new SqlConnection(conectionBD.cadena);
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                return (i > 0) ? true : false;
            } catch (Exception ex)
            {
                return false;
            } finally
            {
                conexion.Close();
            }
        }
        //public static DataTable Listar (string nombreProcedimiento, List<Parametro>? parametros = null)
        //{
        //    ConectionDB conectionBD = new ConectionDB();
        //    SqlConnection conexion = new SqlConnection(conectionBD.cadena);
        //    try
        //    {
        //        conexion.Open();
        //        SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        if (parametros != null)
        //        {
        //            foreach (var parametro in parametros)
        //            {
        //                cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
        //            }
        //        }
        //        DataTable tabla = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(tabla);
        //        return tabla;
        //    } catch (Exception ex)
        //    {
        //        return null;
        //    } finally
        //    {
        //        conexion.Close();
        //    }
        //}
    }
}