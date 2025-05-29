using DersProgramiApp;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

public class VeritabaniIslemleri
{
    private string connectionString = "Data Source=dersprogrami.db;Version=3;";

    public VeritabaniIslemleri()
    {
        if (!File.Exists("dersprogrami.db"))
            SQLiteConnection.CreateFile("dersprogrami.db");

        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string createQuery = @"CREATE TABLE IF NOT EXISTS Dersler (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    DersAdi TEXT,
                                    Gun TEXT,
                                    Saat TEXT,
                                    LabNo TEXT)";
            SQLiteCommand cmd = new SQLiteCommand(createQuery, conn);
            cmd.ExecuteNonQuery();
        }
    }

    public void DersEkle(Ders d)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Dersler (DersAdi, Gun, Saat, LabNo) VALUES (@adi, @gun, @saat, @lab)";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@adi", d.DersAdi);
            cmd.Parameters.AddWithValue("@gun", d.Gun);
            cmd.Parameters.AddWithValue("@saat", d.Saat);
            if (d is UygulamaliDers ud)
                cmd.Parameters.AddWithValue("@lab", ud.LabNo);
            else
                cmd.Parameters.AddWithValue("@lab", DBNull.Value);
            cmd.ExecuteNonQuery();
        }
    }

    public List<Ders> DersleriGetir()
    {
        List<Ders> liste = new List<Ders>();
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Dersler";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string lab = reader["LabNo"].ToString();
                if (!string.IsNullOrWhiteSpace(lab))
                {
                    liste.Add(new UygulamaliDers(
                        reader["DersAdi"].ToString(),
                        reader["Gun"].ToString(),
                        reader["Saat"].ToString(),
                        lab
                    ));
                }
                else
                {
                    liste.Add(new Ders(
                        reader["DersAdi"].ToString(),
                        reader["Gun"].ToString(),
                        reader["Saat"].ToString()
                    ));
                }
            }
        }
        return liste;
    }

    


}
