using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace SqlLite_EdisonTene
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string password)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and password=?", usuario, password);
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtPassword.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultarContenido());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o Contraseña Incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}