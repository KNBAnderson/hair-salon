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
      // more logic will go here in a moment
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
  }
}
