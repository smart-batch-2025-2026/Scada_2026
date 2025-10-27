using MySql.Data.MySqlClient;
using SCADA.Application;
using SCADA.Domain;
using System;
using System.Collections.Generic;

namespace SCADA.Infrastructure
{
    public class ComponentsRepository : GeneralFunctions<MaterialsData>
    {
        private readonly string connectionString;

        public ComponentsRepository(string connString)
        {
            connectionString = connString;
        }

        public void ADD(MaterialsData item)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = @"INSERT INTO components 
                            (Code, Description, UOM, Gravity, Color, Type, Absorption, MaxDiameter, Class, 
                             WaterContent, Ice, PercentOnCement, InfluenceWC, AltCode)
                             VALUES (@Code, @Description, @UOM, @Gravity, @Color, @Type, @Absorption, 
                             @MaxDiameter, @Class, @WaterContent, @Ice, @PercentOnCement, @InfluenceWC, @AltCode)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Code", item.Code);
            cmd.Parameters.AddWithValue("@Description", item.Description);
            cmd.Parameters.AddWithValue("@UOM", item.UOM);
            cmd.Parameters.AddWithValue("@Gravity", item.Gravity);
            cmd.Parameters.AddWithValue("@Color", item.Color);
            cmd.Parameters.AddWithValue("@Type", item.Type);
            cmd.Parameters.AddWithValue("@Absorption", item.Absorption);
            cmd.Parameters.AddWithValue("@MaxDiameter", item.MaxDiameter);
            cmd.Parameters.AddWithValue("@Class", item.Class);
            cmd.Parameters.AddWithValue("@WaterContent", item.WaterContent);
            cmd.Parameters.AddWithValue("@Ice", item.Ice);
            cmd.Parameters.AddWithValue("@PercentOnCement", item.PercentOnCement);
            cmd.Parameters.AddWithValue("@InfluenceWC", item.InfluenceWC);
            cmd.Parameters.AddWithValue("@AltCode", item.AltCode);
            cmd.ExecuteNonQuery();
        }

        public void Delete(MaterialsData item)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM components WHERE Code = @Code";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Code", item.Code);
            cmd.ExecuteNonQuery();
        }

        public void Update(MaterialsData item)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = @"UPDATE components SET
                             Description=@Description, UOM=@UOM, Gravity=@Gravity, Color=@Color, Type=@Type, 
                             Absorption=@Absorption, MaxDiameter=@MaxDiameter, Class=@Class, WaterContent=@WaterContent,
                             Ice=@Ice, PercentOnCement=@PercentOnCement, InfluenceWC=@InfluenceWC, AltCode=@AltCode
                             WHERE Code=@Code";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Description", item.Description);
            cmd.Parameters.AddWithValue("@UOM", item.UOM);
            cmd.Parameters.AddWithValue("@Gravity", item.Gravity);
            cmd.Parameters.AddWithValue("@Color", item.Color);
            cmd.Parameters.AddWithValue("@Type", item.Type);
            cmd.Parameters.AddWithValue("@Absorption", item.Absorption);
            cmd.Parameters.AddWithValue("@MaxDiameter", item.MaxDiameter);
            cmd.Parameters.AddWithValue("@Class", item.Class);
            cmd.Parameters.AddWithValue("@WaterContent", item.WaterContent);
            cmd.Parameters.AddWithValue("@Ice", item.Ice);
            cmd.Parameters.AddWithValue("@PercentOnCement", item.PercentOnCement);
            cmd.Parameters.AddWithValue("@InfluenceWC", item.InfluenceWC);
            cmd.Parameters.AddWithValue("@AltCode", item.AltCode);
            cmd.Parameters.AddWithValue("@Code", item.Code);
            cmd.ExecuteNonQuery();
        }

        public MaterialsData Find(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM components WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public MaterialsData Find(string code)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM components WHERE Code = @Code";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Code", code);

            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public List<MaterialsData> Filter(string type)
        {
            var list = new List<MaterialsData>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM components WHERE Type = @Type";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Type", type);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));

            return list;
        }


        public List<MaterialsData> GetAll()
        {
            var list = new List<MaterialsData>();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM components";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                list.Add(Map(reader));

            return list;
        }

        private MaterialsData Map(MySqlDataReader reader)
        {
            return new MaterialsData
            {
                Code = reader["Code"]?.ToString(),
                Description = reader["Description"]?.ToString(),
                UOM = reader["UOM"]?.ToString(),
                Gravity = reader["Gravity"] == DBNull.Value ? 0f : Convert.ToSingle(reader["Gravity"]),
                Color = reader["Color"]?.ToString(),
                Type = reader["Type"]?.ToString(),
                Absorption = reader["Absorption"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["Absorption"]),
                MaxDiameter = reader["MaxDiameter"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["MaxDiameter"]),
                Class = reader["Class"]?.ToString(),
                WaterContent = reader["WaterContent"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["WaterContent"]),
                Ice = reader["Ice"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Ice"]),
                PercentOnCement = reader["PercentOnCement"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["PercentOnCement"]),
                InfluenceWC = reader["InfluenceWC"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["InfluenceWC"]),
                AltCode = reader["AltCode"]?.ToString()
            };
        }


    }
}
