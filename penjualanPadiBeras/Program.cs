using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penjualanPadiBeras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                string db = "penjualanPadiBeras";/*nama db*/
                SqlConnection conn = null;
                string strKoneksi = "Data Source = LAPTOP-E2NL0H6I\\MIFTAHUL_HUDA;" +
                    "Initial Catalog = {0};" +
                    "User ID = sa ; Password = 010704;";
                conn = new SqlConnection(string.Format(strKoneksi, db));
                conn.Open();
                Console.Clear();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\n<------MENU UTAMA APLIKASI------>");
                        Console.WriteLine("1. Data Barang ");
                        Console.WriteLine("2. Data Suplier/Distributor ");
                        Console.WriteLine("3. Data Padi/Beras ");
                        Console.WriteLine("4. Data Transaksi ");
                        Console.WriteLine("5. exit ");
                        Console.WriteLine("\n enter your choice (1-3): ");
                        char ch = Convert.ToChar(Console.ReadLine());

                        switch (ch)
                        {
                            /*Data Barang*/
                            case '1':
                                {
                                    Console.WriteLine("\n<---Data Barang--->");
                                    Console.WriteLine("1. Melihat data barang");
                                    Console.WriteLine("2. Tambah data barang");
                                    Console.WriteLine("3. Hapus data barang");
                                    Console.WriteLine("4. Update data barang");
                                    Console.WriteLine("5. exit");
                                    Console.WriteLine("\n enter your choice (1-5): ");
                                    char chB = Convert.ToChar(Console.ReadLine());

                                    switch (chB)
                                    {
                                        case '1':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("<-><->Berikut data barang>-<>-<");
                                                Console.WriteLine();
                                                pr.READdatabarang(conn);
                                            }
                                            break;
                                        case '2':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("masukkan ID log:");
                                                string id_log = Console.ReadLine();
                                                Console.WriteLine("masukkan ID padiberas:");
                                                string id_p_b = Console.ReadLine();
                                                Console.WriteLine("masukkan Jumlah Berat:");
                                                string JumlahBerat = Console.ReadLine();
                                                Console.WriteLine("masukkan Tanggal:");
                                                string Tanggal = Console.ReadLine();
                                                Console.WriteLine("masukkan Id Admin:");
                                                string id_admin = Console.ReadLine();
                                                try
                                                {
                                                    pr.insertdatabarang(id_log,id_p_b, JumlahBerat, Tanggal, id_admin, conn);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("anda tidak memiliki " +
                                                        "akses untuk menambah data");
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Masukkan id log yang pengen di hapus:\n");
                                                string id_log = Console.ReadLine();
                                                try
                                                {
                                                    pr.deletedatabarang(id_log, conn);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("\nanda tidak memiliki" +
                                                        "akses untuk menambah data atau data yang anda masukkan salah");
                                                    Console.WriteLine(e.ToString());
                                                }
                                            }
                                            break;
                                        case '4':
                                            {
                                                Console.WriteLine("\n<---Update Data barang--->");
                                                Console.WriteLine("Masukkan ID log data barang yang akan diperbarui:");
                                                string newID_log = Console.ReadLine();
                                                Console.WriteLine("Masukkan Jumlah berat baru:");
                                                string newJumlahBerat = Console.ReadLine();
                                                Console.WriteLine("masukkan tanggal dan waktu yang baru:");
                                                string newTanggal = Console.ReadLine();
                                                try
                                                {
                                                    pr.updatedatabarang(newID_log, newJumlahBerat, newTanggal, conn);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error: " + ex.Message);
                                                }
                                            }
                                            break;
                                        case '5':
                                            conn.Close();
                                            Console.Clear();
                                            Main(new string[0]);
                                            return;
                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\n invalid options");
                                            }
                                            break;
                                    }
                                }
                                break;
                            /* End Data Barang*/

                            /*Data Suplier/Distributor*/
                            case '2':
                                {
                                    Console.WriteLine("\n<---Data Suplier/Distributor--->");
                                    Console.WriteLine("1. Melihat data Suplier/Distributor");
                                    Console.WriteLine("2. Tambah data Suplier/Distributor");
                                    Console.WriteLine("3. Hapus data Suplier/Distributor");
                                    Console.WriteLine("4. Update data Suplier/Distributor");
                                    Console.WriteLine("5. exit");
                                    Console.WriteLine("\n enter your choice (1-5): ");
                                    char chSD = Convert.ToChar(Console.ReadLine());

                                    switch (chSD)
                                    {
                                        case '1':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("<-><->Berikut data suplier/distributor>-<>-<");
                                                Console.WriteLine();
                                                pr.READsuplierdist(conn);
                                            }
                                            break;
                                        case '2':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("masukkan ID suplier/distributor:");
                                                string id_s_d = Console.ReadLine();
                                                Console.WriteLine("masukkan Nama suplier/distributor:");
                                                string NamaSuplier = Console.ReadLine();
                                                Console.WriteLine("masukkan Alamat suplier / distributor:");
                                                string Alamat = Console.ReadLine();
                                                Console.WriteLine("masukkan No telpon suplier / distributor:");
                                                string NoTelpon = Console.ReadLine();
                                                try
                                                {
                                                    pr.insertsuplierdist(id_s_d, NamaSuplier, Alamat, NoTelpon, conn);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("anda tidak memiliki " +
                                                        "akses untuk menambah data");
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("hapus data berdasarkan id suplier/ distributor:\n");
                                                string id_s_d = Console.ReadLine();
                                                try
                                                {
                                                    pr.deletesuplierdist(id_s_d, conn);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("\nanda tidak memiliki" +
                                                        "akses untuk menambah data atau data yang anda masukkan salah");
                                                    Console.WriteLine(e.ToString());
                                                }
                                            }
                                            break;
                                        case '4':
                                            {
                                                Console.WriteLine("\n<---Update suplier distributor--->");
                                                Console.WriteLine("Masukkan ID log data barang yang akan diperbarui:");
                                                string newID_log = Console.ReadLine();
                                                Console.WriteLine("Masukkan Jumlah berat baru:");
                                                string newJumlahBerat = Console.ReadLine();
                                                Console.WriteLine("masukkan tanggal dan waktu yang baru:");
                                                string newTanggal = Console.ReadLine();
                                                try
                                                {
                                                    pr.updatedatabarang(newID_log, newJumlahBerat, newTanggal, conn);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error: " + ex.Message);
                                                }
                                            }
                                            break;
                                        case '5':
                                            conn.Close();
                                            Console.Clear();
                                            Main(new string[0]);
                                            return;
                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\n invalid options");
                                            }
                                            break;
                                    }
                                }
                                break;
                            /*End Data Suplier/Distributor*/

                            /*Data Padi/Beras*/
                            case '3':
                                {
                                    Console.WriteLine("\n<---Data Padi/Beras--->");
                                    Console.WriteLine("1. Melihat data Padi/Beras");
                                    Console.WriteLine("2. Tambah data Padi/Beras");
                                    Console.WriteLine("3. Hapus data Padi/Beras");
                                    Console.WriteLine("4. Update data Padi/Beras");
                                    Console.WriteLine("5. exit");
                                    Console.WriteLine("\n enter your choice (1-5): ");
                                    char chPB = Convert.ToChar(Console.ReadLine());

                                    switch (chPB)
                                    {
                                        case '1':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("<-><->Berikut data padi dan beras>-<>-<");
                                                Console.WriteLine();
                                                pr.READpadiberas(conn);
                                            }
                                            break;
                                        case '2':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("masukkan ID padiberas:");
                                                string idp_b = Console.ReadLine();
                                                Console.WriteLine("masukkan Jenis Padi/beras:");
                                                string Jenisp_b = Console.ReadLine();
                                                Console.WriteLine("masukkan Jumlah Padi/beras:");
                                                string Jumlahp_b = Console.ReadLine();
                                                try
                                                {
                                                    pr.insertpadiberas(idp_b,Jenisp_b, Jumlahp_b, conn);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("anda tidak memiliki " +
                                                        "akses untuk menambah data");
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Masukkan jenis padi yang pengen di hapus:\n");
                                                string Jenisp_b = Console.ReadLine();
                                                try
                                                {
                                                    pr.deletepadiberas(Jenisp_b, conn);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("\nanda tidak memiliki" +
                                                        "akses untuk menambah data atau data yang anda masukkan salah");
                                                    Console.WriteLine(e.ToString());
                                                }
                                            }
                                            break;
                                        case '4':
                                            {
                                                Console.WriteLine("\n<---Update Data Padi/Beras--->");
                                                Console.WriteLine("Masukkan ID Padi/Beras yang akan diperbarui:");
                                                string idp_b = Console.ReadLine();
                                                Console.WriteLine("Masukkan Jenis Padi/Beras baru:");
                                                string newJenis = Console.ReadLine();
                                                Console.WriteLine("Masukkan Jumlah Padi/Beras baru:");
                                                string newJumlah = Console.ReadLine();
                                                try
                                                {
                                                    pr.updatepadiberas(idp_b, newJenis, newJumlah, conn);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error: " + ex.Message);
                                                }
                                            }
                                            break;
                                        case '5':
                                            conn.Close();
                                            Console.Clear();
                                            Main(new string[0]);
                                            return;
                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\n invalid options");
                                            }
                                            break;
                                    }
                                }
                                break;
                            /*End Data Padi/Beras*/

                            /*Data Transaksi*/
                            case '4':
                                {
                                    Console.WriteLine("\n<---Data Transaksi--->");
                                    Console.WriteLine("1. Melihat data Transaksi");
                                    Console.WriteLine("2. Tambah data Transaksi");
                                    Console.WriteLine("3. Hapus data Transaksi");
                                    Console.WriteLine("4. Update data Transaksi");
                                    Console.WriteLine("5. exit");
                                    Console.WriteLine("\n enter your choice (1-5): ");
                                    char chT = Convert.ToChar(Console.ReadLine());

                                    switch (chT)
                                    {
                                        case '1':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("<-><->Berikut data transaksi>-<>-<");
                                                Console.WriteLine();
                                                pr.READtransaksi(conn);
                                            }
                                            break;
                                        case '2':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("masukkan ID transaksi:");
                                                string id_Transaksi = Console.ReadLine();
                                                Console.WriteLine("masukkan jumlah beras:");
                                                string jumlahBerat = Console.ReadLine();
                                                Console.WriteLine("masukkan total transaksi:");
                                                string TotalTransaksi = Console.ReadLine();
                                                Console.WriteLine("masukkan id padi/beras:");
                                                string ID_pb = Console.ReadLine();
                                                Console.WriteLine("masukkan Id suplier/ distributor:");
                                                string ID_sd = Console.ReadLine();
                                                try
                                                {
                                                    pr.insertTransaksi(id_Transaksi, jumlahBerat, TotalTransaksi, ID_pb, ID_sd, conn);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("anda tidak memiliki " +
                                                        "akses untuk menambah data");
                                                }
                                            }
                                            break;
                                        case '3':
                                            {
                                                Console.Clear();
                                                Console.WriteLine("untuk hapus masukkan id transaksi:\n");
                                                string id_Transaksi = Console.ReadLine();
                                                try
                                                {
                                                    pr.deleteTransaksi(id_Transaksi, conn);
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("\nanda tidak memiliki" +
                                                        "akses untuk menambah data atau data yang anda masukkan salah");
                                                    Console.WriteLine(e.ToString());
                                                }
                                            }
                                            break;
                                        case '4':
                                            {
                                                Console.WriteLine("\n<---Update Transaksi--->");
                                                Console.WriteLine("masukkan berdasarkan ID transaksi yang akan diperbarui:");
                                                string newID_Transaksi = Console.ReadLine();
                                                Console.WriteLine("Masukkan Jumlah berat baru:");
                                                string newJumlahbrt = Console.ReadLine();
                                                Console.WriteLine("masukkan Total harga baru:");
                                                string newTotaltr = Console.ReadLine();
                                                try
                                                {
                                                    pr.updateTransaksi(newID_Transaksi,newJumlahbrt,newTotaltr, conn);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error: " + ex.Message);
                                                }
                                            }
                                            break;
                                        case '5':
                                            conn.Close();
                                            Console.Clear();
                                            Main(new string[0]);
                                            return;
                                        default:
                                            {
                                                Console.Clear();
                                                Console.WriteLine("\n invalid options");
                                            }
                                            break;
                                    }
                                }
                                break;
                            /*End Data Transaksi*/

                            case '5':
                                conn.Close();
                                Console.Clear();
                                Main(new string[0]);
                                return;
                            default:
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n invalid options");
                                }
                                break;

                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("\n check for the value entered");
                    }
                }
            }
        }
        /*funtion padi dan beras*/
        public void READpadiberas(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID_p_b, Jenis_p_b, Jumlah_p_b FROM Padi_Beras", conn);
            SqlDataReader r = cmd.ExecuteReader();

            Console.WriteLine("┌───────┬─────────────────┬──────────────┐");
            Console.WriteLine("| ID_p_b|Jenis_p_b        | Jumlah_p_b   |");
            Console.WriteLine("├───────┼─────────────────┼──────────────┤");

            while (r.Read())
            {
                Console.WriteLine($"| {r["ID_p_b"],-2} | {r["Jenis_p_b"],-1} | {r["Jumlah_p_b"],-12} |");
            }

            Console.WriteLine("└───────┴─────────────────┴──────────────┘");
            r.Close();
        }
        public void insertpadiberas(string idp_b ,string Jenisp_b, string Jumlahp_b, SqlConnection conn)
        {
            try
            {
                string str = "INSERT INTO Padi_Beras (ID_p_b,Jenis_p_b, Jumlah_p_b) VALUES (@id,@jenis, @jumlah)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@id", idp_b));
                cmd.Parameters.Add(new SqlParameter("@jenis", Jenisp_b));
                cmd.Parameters.Add(new SqlParameter("@jumlah", Jumlahp_b));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void deletepadiberas(string Jenisp_b, SqlConnection conn)
        {
            string str = "";
            str = "DELETE Padi_Beras WHERE Jenis_p_b = @jenis";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("jenis", Jenisp_b)); ;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil di hapus");
        }
        public void updatepadiberas(string ID_p_b, string newJenisp_b, string newJumlahp_b, SqlConnection conn)
        {
            try
            {
                string str = "UPDATE Padi_Beras SET Jenis_p_b = @newJenis, Jumlah_p_b = @newJumlah WHERE ID_p_b = @id";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@newJenis", newJenisp_b));
                cmd.Parameters.Add(new SqlParameter("@newJumlah", newJumlahp_b));
                cmd.Parameters.Add(new SqlParameter("@id", ID_p_b));
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data padi dan beras Berhasil Diperbarui");
                }
                else
                {
                    Console.WriteLine("Tidak ada data dengan ID yang sesuai");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        /*function data barang*/
        public void READdatabarang(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID_log,ID_p_b,Jumlah_Berat,Tanggal,ID_Admin FROM Data_Barang", conn);
            SqlDataReader r = cmd.ExecuteReader();

            Console.WriteLine("┌──────────┬────────┬──────────────┬────────────┬──────────┐");
            Console.WriteLine("| ID_log   | ID_p_b | Jumlah_Berat | Tanggal    | ID_Admin |");
            Console.WriteLine("├──────────┼────────┼──────────────┼────────────┼──────────┤");

            while (r.Read())
            {
                Console.WriteLine($"| {r["ID_log"],-8} | {r["ID_p_b"],-6} | {r["Jumlah_Berat"],-12} | {((DateTime)r["Tanggal"]).ToString("yyyy-MM-dd"),-10} | {r["ID_Admin"],-8} |");
            }

            Console.WriteLine("└──────────┴────────┴──────────────┴────────────┴──────────┘");
            r.Close();
        }
        public void insertdatabarang(string id_log,string id_p_b, string JumlahBerat,string Tanggal, string id_admin, SqlConnection conn)
        {
            try
            {
                string str = "INSERT INTO Data_Barang (ID_log,ID_p_b,Jumlah_Berat,Tanggal, ID_Admin) VALUES (@id_log,@id_p_b, @jumlah,@tanggal, @idadmin)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@id_log", id_log));
                cmd.Parameters.Add(new SqlParameter("@id_p_b", id_p_b));
                cmd.Parameters.Add(new SqlParameter("@jumlah", JumlahBerat));
                cmd.Parameters.Add(new SqlParameter("@tanggal", Tanggal));
                cmd.Parameters.Add(new SqlParameter("@idadmin", id_admin));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void deletedatabarang(string id_log, SqlConnection conn)
        {
            string str = "";
            str = "DELETE Data_Barang WHERE ID_log = @id_log";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("ID_log", id_log)); ;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil di hapus");
        }
        public void updatedatabarang(string newID_log, string newJumlahBerat, string newTanggal, SqlConnection conn)
        {
            try
            {
                string str = "UPDATE Data_Barang SET Jumlah_Berat = @newjumlah,Tanggal = @newtanggal WHERE ID_log = @newid_log";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@newjumlah", newJumlahBerat));
                cmd.Parameters.Add(new SqlParameter("@newtanggal", newTanggal));
                cmd.Parameters.Add(new SqlParameter("@newid_log", newID_log));
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data barang Berhasil Diperbarui");
                }
                else
                {
                    Console.WriteLine("Tidak ada data dengan ID yang sesuai");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        /*function suplier & distributor*/

        public void READsuplierdist(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID_s_d, Nama_Suplier, Alamat, No_Telpon FROM Suplier_Distributor", conn);
            SqlDataReader r = cmd.ExecuteReader();

            Console.WriteLine("┌──────────┬───────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("| ID_s_d   | Nama_Suplier  |     Alamat      |   No_Telpon     |");
            Console.WriteLine("├──────────┼───────────────┼─────────────────┼─────────────────┤");

            while (r.Read())
            {
                Console.WriteLine($"| {r["ID_s_d"],-8} | {r["Nama_Suplier"],-13} | {r["Alamat"],-15} | {r["No_Telpon"],-10} |");
            }

            Console.WriteLine("└──────────┴───────────────┴─────────────────┴─────────────────┘");
            r.Close();
        }
        public void insertsuplierdist(string id_s_d, string NamaSuplier, string Alamat, string NoTelpon, SqlConnection conn)
        {
            try
            {
                string str = "INSERT INTO Suplier_Distributor (ID_s_d,Nama_Suplier,Alamat,No_Telpon) VALUES (@id_s_d,@namasup, @alamat,@notelp)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@id_s_d", id_s_d));
                cmd.Parameters.Add(new SqlParameter("@namasup", NamaSuplier));
                cmd.Parameters.Add(new SqlParameter("@alamat", Alamat));
                cmd.Parameters.Add(new SqlParameter("@notelp", NoTelpon));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void deletesuplierdist(string id_s_d, SqlConnection conn)
        {
            string str = "";
            str = "DELETE Suplier_Distributor WHERE ID_s_d = @id_s_d";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("ID_s_d", id_s_d)); ;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil di hapus");
        }
        public void updatesuplierdist(string newid_s_d, string newNamaSuplier, string newAlamat,string newNoTelpon, SqlConnection conn)
        {
            try
            {
                string str = "UPDATE Suplier_Distributor SET Nama_Suplier=@newNamaSuplier , Alamat=@newAlamat ,No_Telpon=@newNoTelpon WHERE ID_s_d = @newid_s_d";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@newNamaSuplier", newNamaSuplier));
                cmd.Parameters.Add(new SqlParameter("@newAlamat", newAlamat));
                cmd.Parameters.Add(new SqlParameter("@newNoTelpon", newNoTelpon));
                cmd.Parameters.Add(new SqlParameter("@newid_s_d", newid_s_d));
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data suplier/distributor Berhasil Diperbarui");
                }
                else
                {
                    Console.WriteLine("Tidak ada data dengan ID yang sesuai");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        /*function transaksi*/
        public void READtransaksi(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID_Transaksi, Jumlah_Berat, Total_Transaksi, ID_p_b, ID_s_d FROM Transaksi", conn);
            SqlDataReader r = cmd.ExecuteReader();

            Console.WriteLine("┌──────────────┬──────────────┬─────────────────┬──────────┬──────────┐");
            Console.WriteLine("| ID_Transaksi | Jumlah_Berat | Total_Transaksi | ID_p_b   |  ID_s_d  |");
            Console.WriteLine("├──────────────┼──────────────┼─────────────────┼──────────┼──────────┤");

            while (r.Read())
            {
                Console.WriteLine($"| {r["ID_Transaksi"],-12} | {r["Jumlah_Berat"],-12} | {r["Total_Transaksi"],-15} | {r["ID_p_b"],-8} | {r["ID_s_d"],-8} |");
            }

            Console.WriteLine("└──────────────┴──────────────┴─────────────────┴──────────┴──────────┘");
            r.Close();
        }
        public void insertTransaksi(string id_Transaksi,string jumlahBerat,string TotalTransaksi,string ID_pb,string ID_sd, SqlConnection conn)
        {
            try
            {
                string str = "INSERT INTO Transaksi (ID_Transaksi,Jumlah_Berat,Total_Transaksi,ID_p_b,ID_s_d) VALUES (@id_transaksi,@jumlahbrt, @totaltr,@id_pb, @id_sd)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@id_transaksi", id_Transaksi));
                cmd.Parameters.Add(new SqlParameter("@jumlahbrt", jumlahBerat));
                cmd.Parameters.Add(new SqlParameter("@totaltr", TotalTransaksi));
                cmd.Parameters.Add(new SqlParameter("@id_pb", ID_pb));
                cmd.Parameters.Add(new SqlParameter("@id_sd", ID_sd));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void deleteTransaksi(string id_Transaksi, SqlConnection conn)
        {
            string str = "";
            str = "DELETE Transaksi WHERE ID_Transaksi = @id_transaksi";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("ID_Transaksi", id_Transaksi)); ;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil di hapus");
        }
        public void updateTransaksi(string newID_Transaksi, string newJumlahbrt, string newTotaltr, SqlConnection conn)
        {
            try
            {
                string str = "UPDATE Transaksi SET Jumlah_Berat=@newjumlahbrt ,Total_Transaksi=@newtotaltr WHERE ID_Transaksi = @newid_transaksi";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.Add(new SqlParameter("@newjumlahbrt", newJumlahbrt));
                cmd.Parameters.Add(new SqlParameter("@newtotaltr", newTotaltr));
                cmd.Parameters.Add(new SqlParameter("@newid_transaksi", newID_Transaksi));
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data transaksi Berhasil Diperbarui");
                }
                else
                {
                    Console.WriteLine("Tidak ada data dengan ID yang sesuai");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

