using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class QuestionRepository : AbstractRepository<Models.Question>
    {
        private Utils.QueryBuilder _queryBuilder;

        public QuestionRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Question Create(Models.Question obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> questionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idquestion")
                {
                    questionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("question")
                .Values(questionDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idQuestion = cmd.LastInsertedId;
            obj.IdQuestion = idQuestion;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("question", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Question Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("question")
                .Where("idQuestion", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Question question = new Models.Question();
            while (rdr.Read())
            {
                question.IdQuestion = rdr.GetInt64(0);
                question.Title = rdr.GetString(1);
                question.Comment = rdr.GetString(2);
                question.Level_idLevel = rdr.GetInt64(3);
              
            }
            this.CloseConnection(rdr);
            return question;
        }



        public override List<Models.Question> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("question")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Question> listQuestion = new List<Models.Question>();

            while (rdr.Read())
            {
                Models.Question question = new Models.Question();
                question.IdQuestion = rdr.GetInt64(0);
                question.Title = rdr.GetString(1);
                try {
                question.Comment = rdr.GetString(2); } 
                catch { }
                question.Level_idLevel = rdr.GetInt64(3);
                listQuestion.Add(question);
            }
            this.CloseConnection(rdr);
            return listQuestion;
        }

        public List<Models.Question> FindAllByQuizz(long idUser)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("question")
                .Join("quizz_has_questions","quizz_has_questions.question_idquestion","question.idquestion")
                .Where("quizz_idquizz",idUser)
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Question> listQuestion = new List<Models.Question>();

            while (rdr.Read())
            {
                Models.Question question = new Models.Question();
                question.IdQuestion = rdr.GetInt64(0);
                question.Title = rdr.GetString(1);
                question.Comment = rdr.GetString(2);
                question.Level_idLevel = rdr.GetInt64(3);
                listQuestion.Add(question);
            }
            this.CloseConnection(rdr);
            return listQuestion;
        }

        public override Models.Question Update(long id, Models.Question obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> questionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idquestion" || pr.GetValue(obj) != null)
                {
                    questionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("question")
              .Set(questionDictionnary)
              .Where("idQuestion", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }

    }
}
