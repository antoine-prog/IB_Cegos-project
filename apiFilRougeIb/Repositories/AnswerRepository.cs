using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class AnswerRepository : AbstractRepository<Models.Answer>
    {

        private Utils.QueryBuilder _queryBuilder;

        public AnswerRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Answer Create(Models.Answer obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> answerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idanswer")
                {
                    answerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("answer")
                .Values(answerDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idAnswer = cmd.LastInsertedId;
            obj.IdAnswer = idAnswer;
            connectionSql.Close();
            return obj;
        }

        internal dynamic Results(long iduser, long idquiz)
        {
            this.OpenConnection();
            string secondRequest = "("+ _queryBuilder
                .Select("question_idquestion")
                .From("quizz_has_questions")
                .Where("quizz_idquizz", idquiz)
                .Get()
                +")";
            string request = _queryBuilder
                .Select("Count(result), Count(*)")
                .From("answer")
                .Join("useranswer","useranswer.answer_idanswer","answer.idanswer")
                .Where("user_iduser",iduser)
                .And()
                .Where("question_idquestion",$"{secondRequest}","IN",false)
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Resultat resultat = new Models.Resultat();
            while (rdr.Read())
            {
                resultat.resultat = rdr.GetInt64(0);
                resultat.total = rdr.GetInt64(1);
            }
            connectionSql.Close();
            return resultat;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("answer", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Answer Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("answer")
                .Where("idAnswer", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Answer answer = new Models.Answer();
            while (rdr.Read())
            {
                answer.IdAnswer = rdr.GetInt64(0);
                answer.answer = rdr.GetString(1);
                answer.Result = rdr.GetBoolean(2);
            }
            this.CloseConnection(rdr);
            return answer;
        }

        public override List<Models.Answer> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("answer")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Answer> listAnswer = new List<Models.Answer>();

            while (rdr.Read())
            {
                Models.Answer answer = new Models.Answer();
                answer.IdAnswer = rdr.GetInt64(0);
                answer.answer = rdr.GetString(1);
                answer.Result = rdr.GetBoolean(2);
                listAnswer.Add(answer);
            }
            this.CloseConnection(rdr);
            return listAnswer;
        }

        public override Models.Answer Update(long id, Models.Answer obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> answerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idanswer" || pr.GetValue(obj) != null)
                {
                    answerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("answer")
              .Set(answerDictionnary)
              .Where("idAnswer", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }

    }
}
