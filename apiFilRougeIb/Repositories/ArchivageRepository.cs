using apiFilRougeIb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class ArchivageRepository : AbstractRepository<Archivage>
    {
        private Utils.QueryBuilder _queryBuilder;

        public ArchivageRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Archivage Create(Models.Archivage obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> archivageDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idarchivage" && pr.Name.ToLower() != "datecompleted")
                {
                    archivageDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("archivage")
                .Values(archivageDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idArchivage = cmd.LastInsertedId;
            obj.DateCompleted=DateTime.Now;
            obj.IdArchivage = idArchivage;
            connectionSql.Close();
            return obj;
        }

        internal List<long> FindByCreatorId(long idCreator)
        {
            List<long> listIds = new List<long>();
            this.OpenConnection();
            string request = _queryBuilder
                .Select("archivage.idarchivage")
                .From("Archivage")
                .Join("quizz","quizz.idquizz","archivage.quizz_idquizz")
                .Where("quizz.user_iduser",idCreator)
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listIds.Add(rdr.GetInt64(0));
            }
            this.CloseConnection(rdr);
            return listIds;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("archivage", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Archivage Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("archivage")
                .Where("idArchivage", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Archivage archivage = new Models.Archivage();
            while (rdr.Read())
            {
                archivage.IdArchivage = rdr.GetInt64(0); try
                {

                    archivage.DateCompleted = rdr.GetDateTime(1);
                }
                catch { }
                archivage.IsValidated = rdr.GetBoolean(2);
                archivage.Quizz_idQuizz = rdr.GetInt64(3);
                archivage.User_idUser = rdr.GetInt64(4);
            }
            this.CloseConnection(rdr);
            return archivage;
        }

        public override List<Models.Archivage> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("archivage")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Archivage> listArchivage = new List<Models.Archivage>();

            while (rdr.Read())
            {
                Models.Archivage archivage = new Models.Archivage();
                archivage.IdArchivage = rdr.GetInt64(0);
                try
                {

                archivage.DateCompleted = rdr.GetDateTime(1);
                }
                catch { }
                archivage.IsValidated = rdr.GetBoolean(2);
                archivage.Quizz_idQuizz = rdr.GetInt64(3);
                archivage.User_idUser = rdr.GetInt64(4);
                listArchivage.Add(archivage);
            }
            this.CloseConnection(rdr);
            return listArchivage;
        }

        public override Models.Archivage Update(long id, Models.Archivage obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> archivageDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idarchivage" || pr.GetValue(obj) != null)
                {
                    archivageDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("archivage")
              .Set(archivageDictionnary)
              .Where("idArchivage", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }
    }
}
