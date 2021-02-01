using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class LevelRepository : AbstractRepository<Models.Level>
    {

        private Utils.QueryBuilder _queryBuilder;

        public LevelRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Level Create(Models.Level obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> levelDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idlevel")
                {
                    levelDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("level")
                .Values(levelDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idLevel = cmd.LastInsertedId;
            obj.IdLevel = idLevel;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.DeleteLevel("level", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Level Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("level")
                .Where("idLevel", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Level level = new Models.Level();
            while (rdr.Read())
            {
                level.IdLevel = rdr.GetInt64(0);
                level.Title = rdr.GetString(1);
            }
            this.CloseConnection(rdr);
            return level;
        }

        public override List<Models.Level> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("level")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Level> listLevel = new List<Models.Level>();

            while (rdr.Read())
            {
                Models.Level level = new Models.Level();
                level.IdLevel = rdr.GetInt64(0);
                level.Title = rdr.GetString(1);
                listLevel.Add(level);
            }
            this.CloseConnection(rdr);
            return listLevel;
        }

        public override Models.Level Update(long id, Models.Level obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> levelDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idlevel" || pr.GetValue(obj) != null)
                {
                    levelDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("level")
              .Set(levelDictionnary)
              .Where("idLevel", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }



    }
}
