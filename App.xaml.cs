using tarea1._4.Controller;

namespace tarea1._4
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }


        public static SQLiteHelper SQLiteBD
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "fotos.db3"));
                }
                return db;
            }
        }


    }
}