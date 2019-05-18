using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int Id {get; set;}
    public string Name {get; set;}
    public string DaysAvailable {get; set;}

    public Stylist (string name, string daysAvailable, int id = 0) {
      Name = name;
      DaysAvailable = daysAvailable;
      Id = id;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string daysAvailable = rdr.GetString(2);

        Stylist newStylist = new Stylist(name, daysAvailable, id);
        allStylists.Add(newStylist);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylist";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.Id == newStylist.Id);
        bool nameEquality = (this.Name == newStylist.Name);
        bool daysAvailableEquality = (this.DaysAvailable == newStylist.DaysAvailable);
        return (idEquality && nameEquality && daysAvailableEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylist` (`name`, `daysAvailable`) VALUES (@StylistName, @StylistDaysAvailable);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@StylistName";
      name.Value = this.Name;

      MySqlParameter daysAvailable = new MySqlParameter();
      daysAvailable.ParameterName = "@StylistDaysAvailable";
      daysAvailable.Value = this.DaysAvailable;

      cmd.Parameters.Add(name);
      cmd.Parameters.Add(daysAvailable);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `stylist` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string stylistName = "";
      string stylistDaysAvailable = "";
      int stylistId = 0;

      while (rdr.Read())
      {
        stylistName = rdr.GetString(1);
        stylistDaysAvailable = rdr.GetString(2);
        stylistId = rdr.GetInt32(0);
      }

      Stylist foundStylist = new Stylist(stylistName, stylistDaysAvailable, stylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundStylist;
    }

    public List<Specialty> GetSpecialties()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT specialty.* FROM stylist
         JOIN stylist_specialty ON (stylist.id = stylist_specialty.stylist_id)
         JOIN specialty ON (stylist_specialty.specialty_id = specialty.id)
         WHERE stylist.id = @StylistId;";
     MySqlParameter stylistIdParameter = new MySqlParameter();
     stylistIdParameter.ParameterName = "@StylistId";
     stylistIdParameter.Value = _id;
     cmd.Parameters.Add(stylistIdParameter);
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
     List<Specialty> specialties = new List<Specialty>{};
     while(rdr.Read())
     {
       int specialtyId = rdr.GetInt32(0);
       string specialtyName = rdr.GetString(1);
       Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
       specialties.Add(newSpecialty);
     }
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
     return specialties;
   }

   public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist_specialty (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);
      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = newSpecialty.GetId();
      cmd.Parameters.Add(specialty_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
