using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using tarea1._4.Models;

namespace tarea1._4.Controller
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Fotos>().Wait();
        }

        public Task<int> SavedFotoAsync(Fotos fot)
        {
            if (fot.IdFoto == 0)
            {
                return db.InsertAsync(fot);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Recupera todas las Fotos
        /// </summary>
        /// <returns>
        /// </returns>
        public Task<List<Fotos>> GetFotoAsync()
        {
            return db.Table<Fotos>().ToListAsync();
        }
        /// <summary>
        /// Recupera fotos por Id
        /// </summary>
        /// <param name="IdFoto">Id de la foto que se requiere</param>
        /// <returns></returns>
        public Task<Fotos> GetFotoByIdAsync(int IdFoto)
        {
            return db.Table<Fotos>().Where(a => a.IdFoto == IdFoto).FirstOrDefaultAsync();
        }

    }
}
