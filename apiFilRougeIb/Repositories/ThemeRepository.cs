using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class ThemeRepository : AbstractRepository<Models.Theme>
    {

        private Utils.QueryBuilder _queryBuilder;

        public ThemeRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Theme Create(Models.Theme obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> themeDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idtheme")
                {
                    themeDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("theme")
                .Values(themeDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idTheme = cmd.LastInsertedId;
            obj.IdTheme = idTheme;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("theme", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Theme Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("theme")
                .Where("idTheme", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Theme theme = new Models.Theme();
            while (rdr.Read())
            {
                theme.IdTheme = rdr.GetInt64(0);
                theme.theme= rdr.GetString(1);
            }
            this.CloseConnection(rdr);
            return theme;
        }

        public override List<Models.Theme> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("theme")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Theme> listThemes = new List<Models.Theme>();

            while (rdr.Read())
            {
                Models.Theme theme = new Models.Theme();
                theme.IdTheme = rdr.GetInt64(0);
                theme.theme = rdr.GetString(1);
                listThemes.Add(theme);
            }
            this.CloseConnection(rdr);
            return listThemes;
        }

        public override Models.Theme Update(long id, Models.Theme obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> themeDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idtheme" || pr.GetValue(obj) != null)
                {
                    themeDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("theme")
              .Set(themeDictionnary)
              .Where("idTheme", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
