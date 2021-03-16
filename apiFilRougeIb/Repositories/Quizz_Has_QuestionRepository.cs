using apiFilRougeIb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace apiFilRougeIb.Repositories
{
    internal class Quizz_Has_QuestionRepository : AbstractRepository<Models.Quizz_Has_Question> 
    {
        private Utils.QueryBuilder _queryBuilder;

        public Quizz_Has_QuestionRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Quizz_Has_Question Create(Models.Quizz_Has_Question obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> quizz_Has_QuestionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                //if (pr.Name.ToLower() != "idquizz_Has_Question")
                //{
                quizz_Has_QuestionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                //}
            }
            string request = _queryBuilder
                .Insert("quizz_Has_Questions")
                .Values(quizz_Has_QuestionDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idQuizz_Has_Question = cmd.LastInsertedId;
            connectionSql.Close();
            return obj;
        }

        //public override int Delete(long id)
        //{
        //    this.OpenConnection();
        //    string request = _queryBuilder.Delete("quizz_Has_Question", id);
        //    MySqlCommand cmd = new MySqlCommand(request, connectionSql);
        //    int result = cmd.ExecuteNonQuery();
        //    connectionSql.Close();
        //    return result;
        //}




        public List<Models.Quizz_Has_Question> FindQuestions(long idQuestions)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz_Has_Questions")
                .Where("question_idQuestion", idQuestions, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Quizz_Has_Question> listQuizz_Has_Questions = new List<Models.Quizz_Has_Question>();

            while (rdr.Read())
            {
                Models.Quizz_Has_Question quizz_Has_Question = new Models.Quizz_Has_Question();
                quizz_Has_Question.quizz_idQuizz = rdr.GetInt64(0);
                quizz_Has_Question.question_idQuestion = rdr.GetInt64(1);
                listQuizz_Has_Questions.Add(quizz_Has_Question);
            }
            this.CloseConnection(rdr);
            return listQuizz_Has_Questions;
        }



        public List<Models.Quizz_Has_Question> FindQuizz(long idQuizz)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz_Has_Questions")
                .Where("quizz_idQuizz", idQuizz, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Quizz_Has_Question> listQuizz_Has_Questions = new List<Models.Quizz_Has_Question>();

            while (rdr.Read())
            {
                Models.Quizz_Has_Question quizz_Has_Question = new Models.Quizz_Has_Question();
                quizz_Has_Question.quizz_idQuizz = rdr.GetInt64(0);
                quizz_Has_Question.question_idQuestion = rdr.GetInt64(1);
                listQuizz_Has_Questions.Add(quizz_Has_Question);
            }
            this.CloseConnection(rdr);
            return listQuizz_Has_Questions;
        }

        public override Models.Quizz_Has_Question Update(long id, Models.Quizz_Has_Question obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> quizz_Has_QuestionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idquizz_Has_Question" || pr.GetValue(obj) != null)
                {
                    quizz_Has_QuestionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("quizz_Has_Question")
              .Set(quizz_Has_QuestionDictionnary)
              .Where("idQuizz_Has_Question", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }

        public override Quizz_Has_Question Find(long id)
        {
            throw new NotImplementedException();
        }

        public override List<Quizz_Has_Question> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz_Has_Questions")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Quizz_Has_Question> listQuizz_Has_Questions = new List<Models.Quizz_Has_Question>();

            while (rdr.Read())
            {
                Models.Quizz_Has_Question quizz_Has_Question = new Models.Quizz_Has_Question();
                quizz_Has_Question.quizz_idQuizz = rdr.GetInt64(0);
                quizz_Has_Question.question_idQuestion = rdr.GetInt64(1);
                listQuizz_Has_Questions.Add(quizz_Has_Question);
            }
            this.CloseConnection(rdr);
            return listQuizz_Has_Questions;
        }

        public override int Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
