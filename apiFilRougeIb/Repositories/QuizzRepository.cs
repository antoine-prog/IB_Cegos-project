using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class QuizzRepository : AbstractRepository<Models.Quizz>
    {

        private Utils.QueryBuilder _queryBuilder;

        public QuizzRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Quizz Create(Models.Quizz obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> quizzDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idquizz")
                {
                    quizzDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("quizz")
                .Values(quizzDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idQuizz = cmd.LastInsertedId;
            obj.IdQuizz = idQuizz;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("quizz", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Quizz Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Where("idQuizz", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Quizz quiz = new Models.Quizz();
            while (rdr.Read())
            {
                quiz.IdQuizz = rdr.GetInt64(0);
                quiz.Name = rdr.GetString(1);
                quiz.User_idUser = rdr.GetInt64(2);
                quiz.Theme_idTheme = rdr.GetInt64(3);
            }
            this.CloseConnection(rdr);
            return quiz;
        }

        public  List<Models.Quizz> FindUser(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Where("user_iduser", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Quizz> listQuiz = new List<Models.Quizz>();

            while (rdr.Read())
            {
                Models.Quizz quiz = new Models.Quizz();
                quiz.IdQuizz = rdr.GetInt64(0);
                quiz.Name = rdr.GetString(1);
                quiz.User_idUser = rdr.GetInt64(2);
                quiz.Theme_idTheme = rdr.GetInt64(3);
                listQuiz.Add(quiz);
            }
            this.CloseConnection(rdr);
            return listQuiz;
        }

        public override List<Models.Quizz> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Quizz> listQuiz = new List<Models.Quizz>();

            while (rdr.Read())
            {
                Models.Quizz quiz = new Models.Quizz();
                quiz.IdQuizz = rdr.GetInt64(0);
                quiz.Name = rdr.GetString(1);
                quiz.User_idUser = rdr.GetInt64(2);
                quiz.Theme_idTheme = rdr.GetInt64(3);
                listQuiz.Add(quiz);
            }
            this.CloseConnection(rdr);
            return listQuiz;
        }

        public override Models.Quizz Update(long id, Models.Quizz obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> quizDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idquizz" || pr.GetValue(obj) != null)
                {
                    quizDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("quizz")
              .Set(quizDictionnary)
              .Where("idQuizz", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }



    }
}
