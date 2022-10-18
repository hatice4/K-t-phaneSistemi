using KütüphaneSistemi.Models.VeritabaniModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace KütüphaneSistemi.Controllers
{
    public class GirisController : Controller
    {

        public IActionResult Index()
        {//fgfg
            return View();
        }
        [HttpPost]
        public IActionResult Index(Kullanici kullanici)
        {

            return View();
        }
        public IActionResult KayıtOl()
        {

            return View();
        }
        [HttpPost]
        public IActionResult KayıtOl(Kullanici kullanici)
        {
            var data = KullaniciKontrol(kullanici.KullaniciAdi);
            if (data != null)
            {
                return View();
            }
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Sql.connectionString;
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Kullanicilar(AdiSoyadi, KullaniciAdi, Sifre)   VALUES(@param1,@param2,@param3)";
                cmd.Parameters.AddWithValue("@param1", kullanici.AdiSoyadi);
                 cmd.Parameters.AddWithValue("@param2", kullanici.KullaniciAdi);
                cmd.Parameters.AddWithValue("@param3", kullanici.Sifre);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return View();
        }
        public Kullanici KullaniciKontrol(string kullaniciAdi)
        {
            Kullanici sddd = null;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Sql.connectionString;
                connection.Open();
                string sqlCmd = $"Select * from Kullanicilar where Kullanicilar.KullaniciAdi='{kullaniciAdi}'";
                SqlCommand cmd = new SqlCommand(sqlCmd, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        sddd = new Kullanici();
                        sddd.Id = int.Parse(reader["Id"].ToString());
                        sddd.AdiSoyadi = reader["AdiSoyadi"].ToString();
                        sddd.KullaniciAdi = reader["KullaniciAdi"].ToString();
                        sddd.Sifre = reader["Sifre"].ToString();
                    }
                }

            }
            return sddd;
        }
    }
}
