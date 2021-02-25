using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFilRougeIb.Utils
{
    public class QueryBuilder
    {

        public StringBuilder request = new StringBuilder();
        public QueryBuilder() { }


        /// <summary>
        /// Définie si l'on veut un Select * ou un select 'values'
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        internal QueryBuilder Select(params string[] values)
        {
            request.Clear();
            request.Append("SELECT ");
            if (values.Length > 0)
            {
                foreach (string value in values)
                {
                    request.Append($"{value},");
                }
                request.Remove((request.Length - 1), 1);
            }
            else
            {
                request.Append("*");
            }
            return this;
        }

        /// <summary>
        /// Défini la table dans laquelle la donnée sera insérée
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        internal QueryBuilder Insert(string table)
        {
            request.Clear();
            request.Append($"INSERT INTO {table}");
            return this;
        }


        /// <summary>
        /// Ajoute les éléments d'un dictionnaire à l'aide d'un "VALUES" dans une table de donnée 
        /// en modifiant leur écriture si nécessaire pour qu'il y ait aucune erreur avec la base de donnée
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal string Values(Dictionary<string, dynamic> obj)
        {
            request.Append("(");
            foreach (var key in obj.Keys)
            {
                request.Append($"{key},");
            }
            request.Remove((request.Length - 1), 1);
            request.Append(") VALUES (");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    request.Append($"'{obj[key]}',");
                }
                else if (obj[key] is int || obj[key] is bool || obj[key] is long)
                {
                    request.Append($"{obj[key]},");
                }
                else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    request.Append($"{val.Replace(',', '.')},");
                }
                else
                {
                    request.Append($"'{obj[key]}',");
                }
            }
            request.Remove((request.Length - 1), 1);
            request.Append(");");
            return request.ToString();
        }
        /// <summary>
        /// Appelle l'instruction 'JOIN' qui créer
        /// </summary>
        /// <param name="tableSecondaire"></param>
        /// <param name="cle1"></param>
        /// <param name="cle2"></param>
        /// <returns></returns>
        internal QueryBuilder Join(string tableSecondaire, string cle1, string cle2, string type="")
        {
            request.Append($"{type}JOIN {tableSecondaire} ON {cle1} = {cle2} ");
            return this;
        }
        /// <summary>
        /// Appelle l'instruction 'DELETE' qui affectera une donnée défini par son id et sa base de donnée
        /// </summary>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        internal string Delete(string table, long id)
        {
            request.Clear();
            return request.Append($"DELETE FROM {table} where id{table} = {id}").ToString();
        }
        //Si l'id des tables sont différentes, plusieurs méthodes 'Delete' sont a définir avec "where id" à changer

        internal string DeleteLevel(string table, long id)
        {
            request.Clear();
            return request.Append($"DELETE FROM {table} where idLevel = {id}").ToString();
        }

        internal string DeleteUser(string table, long id)
        {
            request.Clear();
            return request.Append($"DELETE FROM {table} where idUser = {id}").ToString();
        }

        internal string DeleteTheme(string table, long id)
        {
            request.Clear();
            return request.Append($"DELETE FROM {table} where idUser = {id}").ToString();
        }


        internal string Get()
        {
            return request.ToString();
        }


        internal QueryBuilder Where(string key, dynamic value, string type = "=")
        {
            request.Append($" WHERE {key} {type} {value}");
            return this;
        }

        internal QueryBuilder From(string table)
        {
            request.Append($" FROM {table} ");
            return this;
        }

        internal QueryBuilder Update(string table)
        {
            request.Clear();
            request.Append($"UPDATE {table} ");
            return this;
        }


        /// <summary>
        /// Appelle les élements d'un dictionnaire à l'aide d'un "VALUES" qui seront utiliser pour mettre a jour une donnée
        /// en modifiant leur écriture si nécessaire pour qu'il y ait aucune erreur avec la base de donnée
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal QueryBuilder Set(Dictionary<string, dynamic> obj)
        {
            request.Append("SET ");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    request.Append($"{key} = '{obj[key]}',");
                }
                else if (obj[key] is int || obj[key] is bool || obj[key] is long)
                {
                    request.Append($"{key} = {obj[key]},");
                }
                else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    request.Append($"{key} = {val.Replace(',', '.')},");
                }
                else
                {
                    request.Append($"{key} = '{obj[key]}',");
                }
            }
            request.Remove((request.Length - 1), 1);
            return this;
        }





    }
}