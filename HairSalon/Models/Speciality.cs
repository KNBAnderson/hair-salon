using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    public int Id {get; set;}
    public string Name {get; set;}

    public Specialty (string name, int id = 0) {
      Name = name;
      Id = id;
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialty;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Specialty newSpecialty = new Specialty(name, id);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialty";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = (this.Id == newSpecialty.Id);
        bool nameEquality = (this.Name == newSpecialty.Name);
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO `specialty` (`name`) VALUES (@SpecialtyName);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@SpecialtyName";
      name.Value = this.Name;

      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `specialty` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string specialtyName = "";
      int specialtyId = 0;

      while (rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        specialtyName = rdr.GetString(1);
      }

      Specialty foundSpecialty = new Specialty(specialtyName, specialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundSpecialty;
    }
  }
}
