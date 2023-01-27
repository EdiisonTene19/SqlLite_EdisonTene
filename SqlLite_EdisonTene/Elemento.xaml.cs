using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SqlLite_EdisonTene
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;
        public Elemento(int id, string Nombre, string Usuario, string Password)
        {
            InitializeComponent();
            txtNombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtContrasena.Text = Password;
            IdSeleccionado = id;
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE Id =?", id);
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, Password = ? WHERE Id =?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Update(db, IdSeleccionado, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                Navigation.PushAsync(new ConsultarContenido());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultarContenido());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}