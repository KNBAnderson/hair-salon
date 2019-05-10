using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    public int Id {get; set;}
    public string Name {get; set;}
    public int StylistId {get; set;}
    public DateTime NextAppointment {get; set;}


    //public string ImageURL {get; set;}

    public Client (string name, int stylistId, DateTime nextAppointment, int id = 0) {
      Name = name;
      StylistId = stylistId;
      NextAppointment = nextAppointment;
      Id = id;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int nextAppointment = rdr.GetDateTime(2);
        int stylistId = rdr.GetInt32(3);

        Client newRestaurant = new Client(name, stylistId, nextAppointment, id);
        allClients.Add(newRestaurant);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public static List<Client> FindStylistList(int id)
    {
      List<Client> stylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand getStylistList = conn.CreateCommand() as MySqlCommand;
      getStylistList.CommandText = @"SELECT * FROM client WHERE stylistId='" + id +"';";
      MySqlDataReader rdr = getStylistList.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int nextAppointment = rdr.GetDateTime(2);
        int stylistId = rdr.GetInt32(3);

        Client newRestaurant = new Client(name, stylistId, nextAppointment, id);
        stylistClients.Add(newRestaurant);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylistClients;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM client";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Client))
      {
        return false;
      }
      else
      {
        Client newRestaurant = (Client) otherRestaurant;
        bool idEquality = (this.Id == newRestaurant.Id);
        bool nameEquality = (this.Name == newRestaurant.Name);
        bool stylistIdEquality = (this.StylistId == newRestaurant.StylistId);
        bool priceEquality = (this.NextAppointment == newRestaurant.NextAppointment);
        return (idEquality && nameEquality && stylistIdEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO `client` (`name`, `stylistId`, `nextAppointment`) VALUES (@RestaurantName, @RestaurantStylistId, @RestaurantNextAppointment);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@RestaurantName";
      name.Value = this.Name;

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@RestaurantStylistId";
      stylistId.Value = this.StylistId;

      MySqlParameter NextAppointment = new MySqlParameter();
      NextAppointment.ParameterName = "@RestaurantStylistId";
      NextAppointment.Value = this.NextAppointment;

      cmd.Parameters.Add(name);
      cmd.Parameters.Add(stylistId);
      cmd.Parameters.Add(NextAppointment);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      // more logic will go here in a moment
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `client` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string restaurantName = "";
      int restaurantStylistId = 0;
      int restaurantId = 0;
      int restaurantNextAppointment = 0;

      while (rdr.Read())
      {
        restaurantId = rdr.GetInt32(0);
        restaurantName = rdr.GetString(1);
        restaurantStylistId = rdr.GetInt32(2);
        restaurantNextAppointment = rdr.GetInt32(3);
      }

      Client foundRestaurant = new Client(restaurantName, restaurantStylistId, restaurantId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRestaurant;
    }
  }
}
