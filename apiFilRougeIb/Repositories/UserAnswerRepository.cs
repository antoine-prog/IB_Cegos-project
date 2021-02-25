using apiFilRougeIb.Models;
using apiFilRougeIb.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace apiFilRougeIb.Repositories
{
    internal class UserAnswerRepository : AbstractRepository<Models.UserAnswer>
    {
        private QueryBuilder _queryBuilder;

        public UserAnswerRepository(QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override UserAnswer Create(UserAnswer obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> userAnswerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                //if (pr.Name.ToLower() != "iduserAnswer")
                //{
                    userAnswerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                //}
            }
            string request = _queryBuilder
                .Insert("userAnswer")
                .Values(userAnswerDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idUserAnswer = cmd.LastInsertedId;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("userAnswer", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public List<UserAnswer> FindUsers(long idUsers)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("userAnswer")
                .Where("user_iduser", idUsers, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<UserAnswer> listUserAnswers = new List<UserAnswer>();

            while (rdr.Read())
            {
                UserAnswer userAnswer = new UserAnswer();
                userAnswer.User_IdUser = rdr.GetInt64(0);
                userAnswer.Answer_IdAnswer = rdr.GetInt64(1);
                userAnswer.Question_IdQuestion = rdr.GetInt64(2);
                listUserAnswers.Add(userAnswer);
            }
            this.CloseConnection(rdr);
            return listUserAnswers;
        }


        public List<UserAnswer> FindQuestions(long idQuestions)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("userAnswer")
                .Where("question_idquestion", idQuestions, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<UserAnswer> listUserAnswers = new List<UserAnswer>();

            while (rdr.Read())
            {
                UserAnswer userAnswer = new UserAnswer();
                userAnswer.User_IdUser = rdr.GetInt64(0);
                userAnswer.Answer_IdAnswer = rdr.GetInt64(1);
                userAnswer.Question_IdQuestion = rdr.GetInt64(2);
                listUserAnswers.Add(userAnswer);
            }
            this.CloseConnection(rdr);
            return listUserAnswers;
        }



        public List<UserAnswer> FindAnswers(long idAnswers)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("userAnswer")
                .Where("answer_idanswer", idAnswers, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<UserAnswer> listUserAnswers = new List<UserAnswer>();

            while (rdr.Read())
            {
                UserAnswer userAnswer = new UserAnswer();
                userAnswer.User_IdUser = rdr.GetInt64(0);
                userAnswer.Answer_IdAnswer = rdr.GetInt64(1);
                userAnswer.Question_IdQuestion = rdr.GetInt64(2);
                listUserAnswers.Add(userAnswer);
            }
            this.CloseConnection(rdr);
            return listUserAnswers;
        }

        public override Models.UserAnswer Update(long id, Models.UserAnswer obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> userAnswerDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "iduserAnswer" || pr.GetValue(obj) != null)
                {
                    userAnswerDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("userAnswer")
              .Set(userAnswerDictionnary)
              .Where("idUserAnswer", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }



        public override List<UserAnswer> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("userAnswer")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.UserAnswer> listUserAnswers = new List<Models.UserAnswer>();

            while (rdr.Read())
            {
                Models.UserAnswer userAnswer = new Models.UserAnswer();
                userAnswer.User_IdUser = rdr.GetInt64(0);
                userAnswer.Answer_IdAnswer= rdr.GetInt64(1);
                userAnswer.Question_IdQuestion = rdr.GetInt64(2);
                listUserAnswers.Add(userAnswer);
            }
            this.CloseConnection(rdr);
            return listUserAnswers;
        }


        public override UserAnswer Find(long id)
        {
            throw new NotImplementedException();
        }
    }
}