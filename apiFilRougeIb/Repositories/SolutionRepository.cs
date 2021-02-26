using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    public class SolutionRepository : AbstractRepository<Models.Solution>
    {

        private Utils.QueryBuilder _queryBuilder;

        public SolutionRepository(Utils.QueryBuilder queryBuilder)
        {
            this._queryBuilder = queryBuilder;
        }

        public override Models.Solution Create(Models.Solution obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> solutionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idsolution")
                {
                    solutionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
                .Insert("solution")
                .Values(solutionDictionnary);

            Console.WriteLine(request);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            long idSolution = cmd.LastInsertedId;
            obj.IdSolution = idSolution;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("solution", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            Console.WriteLine(request);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Models.Solution Find(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("solution")
                .Where("idSolution", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Models.Solution solution = new Models.Solution();
            while (rdr.Read())
            {
                solution.IdSolution = rdr.GetInt64(0);
                solution.solution = rdr.GetString(1);
                solution.IsTrue = rdr.GetBoolean(2);
                solution.Question_idQuestion = rdr.GetInt64(3);
            }
            this.CloseConnection(rdr);
            return solution;
        }

        public  List<Models.Solution> FindSolutionByQuestion(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("solution")
                .Where("question_idQuestion", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Solution> solutions=new List<Models.Solution>();
            while (rdr.Read())
            {
                Models.Solution solution = new Models.Solution();
                solution.IdSolution = rdr.GetInt64(0);
                solution.solution = rdr.GetString(1);
                solution.IsTrue = rdr.GetBoolean(2);
                solution.Question_idQuestion = rdr.GetInt64(3);
                solutions.Add(solution);
            }
            this.CloseConnection(rdr);
            return solutions;
        }
        public override List<Models.Solution> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("solution")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Models.Solution> listSolutions = new List<Models.Solution>();

            while (rdr.Read())
            {
                Models.Solution solution = new Models.Solution();
                solution.IdSolution = rdr.GetInt64(0);
                solution.solution = rdr.GetString(1);
                solution.IsTrue = rdr.GetBoolean(2);
                solution.Question_idQuestion = rdr.GetInt64(3);
                listSolutions.Add(solution);
            }
            this.CloseConnection(rdr);
            return listSolutions;
        }

        public override Models.Solution Update(long id, Models.Solution obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> solutionDictionnary = new Dictionary<string, dynamic>();

            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != "idsolution" || pr.GetValue(obj) != null)
                {
                    solutionDictionnary.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            string request = _queryBuilder
              .Update("solution")
              .Set(solutionDictionnary)
              .Where("idSolution", id).Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return Find(id);
        }



    }
}
