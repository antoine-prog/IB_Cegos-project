using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Repositories
{
    abstract public class AbstractRepository<T>
    {

        public MySqlConnection connectionSql = Utils.ConnectionSql.GetConnection();

        /**
         * Permet de récupérer un objet
         */
        /// <param name="id"> id de référence en bdd</param>
        /// <returns>Renvoi un objet</returns>
        public abstract T Find(long id);

        /**
         * Permet de récupérer une liste d'objet
         */
        /// <returns>Renvoi une liste d'objet</returns>
        public abstract List<T> FindAll();
        /**
        * Permet de persister un objet
        */
        public abstract T Create(T obj);
        /**
        * Permet de modifier un objet
        */
        public abstract T Update(long id, T obj);
        /**
        * Permet de supprimer un objet
        */
        public abstract int Delete(long id);

        public void OpenConnection()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();
        }

        public void CloseConnection(MySqlDataReader reader)
        {
            Console.WriteLine("Close MySQL...");
            reader.Close();
            connectionSql.Close();
        }

    }
}
