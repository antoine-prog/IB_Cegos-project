using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class UserRepository : AbstractRepository<Models.User>
    {

        private Utils.QueryBuilder _queryBuilder;

        public UserRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.User Create(Models.User obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> userDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "iduser")
                {
                    userDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("user")
                .Values(userDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idUser = cmd.LastInsertedId;
            obj.IdUser = idUser;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.DeleteUser("user", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.User Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("user")
                .Where("idUser", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.User user = new Models.User();
            while (rdr.Read())
            {
                user.IdUser = rdr.GetInt64(0);
                user.FirstName = rdr.GetString(1);
                user.LastName = rdr.GetString(2);
                user.Username = rdr.GetString(3);
                user.Adress = rdr.GetString(4);
                user.Mail = rdr.GetString(5);
                user.Password = rdr.GetString(6);
                user.IsAdmin = rdr.GetBoolean(7);
                user.IsCreator = rdr.GetBoolean(8);
            }
            this.CloseConnection(rdr);
            return user;
        }


        public List<Models.UserAnswer> FindAllUserAnswers(long idUsers)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("userAnswer")
                .Where("user_iduser", idUsers, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.UserAnswer> listUserAnswers = new List<Models.UserAnswer>();

            while (rdr.Read())
            {
                Models.UserAnswer userAnswer = new Models.UserAnswer();
                userAnswer.User_IdUser = rdr.GetInt64(0);
                userAnswer.Answer_IdAnswer = rdr.GetInt64(1);
                userAnswer.Question_IdQuestion = rdr.GetInt64(2);
                listUserAnswers.Add(userAnswer);
            }
            this.CloseConnection(rdr);
            return listUserAnswers;
        }



        public override List<Models.User> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("user")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.User> listUsers = new List<Models.User>();

            while (rdr.Read())
            {
                Models.User user = new Models.User();
                user.IdUser = rdr.GetInt64(0);
                user.FirstName = rdr.GetString(1);
                user.LastName = rdr.GetString(2);
                user.Username = rdr.GetString(3);
                user.Adress = rdr.GetString(4);
                user.Mail = rdr.GetString(5);
                user.Password = rdr.GetString(6);
                user.IsAdmin = rdr.GetBoolean(7);
                user.IsCreator = rdr.GetBoolean(8);
<<<<<<< HEAD
               
=======
>>>>>>> dev
                listUsers.Add(user);
            }
            this.CloseConnection(rdr);
            return listUsers;
        }


        public override Models.User Update(long id, Models.User obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> userDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "iduser" || pr.GetValue(obj) != null)
                {
                    userDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("user")
              .Set(userDictionnary)
              .Where("idUser", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }



    }
}
