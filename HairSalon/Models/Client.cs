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
        DateTime nextAppointment = rdr.GetDateTime(2);
        int stylistId = rdr.GetInt32(3);

        Client newClient = new Client(name, stylistId, nextAppointment, id);
        allClients.Add(newClient);
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
        int id1 = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        DateTime nextAppointment = rdr.GetDateTime(2);
        int stylistId = rdr.GetInt32(3);

        Client newClient = new Client(name, stylistId, nextAppointment, id1);
        stylistClients.Add(newClient);
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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.Id == newClient.Id);
        bool nameEquality = (this.Name == newClient.Name);
        bool stylistIdEquality = (this.StylistId == newClient.StylistId);
        bool nextAppointmentEquality = (this.NextAppointment == newClient.NextAppointment);
        return (idEquality && nameEquality && stylistIdEquality && nextAppointmentEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO `client` (`name`, `stylistId`, `nextAppointment`) VALUES (@ClientName, @ClientStylistId, @ClientNextAppointment);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ClientName";
      name.Value = this.Name;

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@ClientStylistId";
      stylistId.Value = this.StylistId;

      MySqlParameter NextAppointment = new MySqlParameter();
      NextAppointment.ParameterName = "@ClientNextAppointment";
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
      string clientName = "";
      int clientStylistId = 0;
      int clientId = 0;
      DateTime clientNextAppointment =  new DateTime(1000, 01, 01);

      while (rdr.Read())
      {

        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        clientNextAppointment = rdr.GetDateTime(2);
        clientStylistId = rdr.GetInt32(3);
      }

      Client foundClient = new Client(clientName, clientStylistId, clientNextAppointment,clientId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }
  }
}
