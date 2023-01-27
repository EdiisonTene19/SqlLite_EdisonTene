using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace SqlLite_EdisonTene
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection  con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre= txtNombre.Text, Usuario = txtUsuario.Text, Password = txtpassword.Text };
            con.InsertAsync(DatosRegistro);
            txtNombre.Text = "";
            txtpassword.Text = "";
            txtUsuario.Text = "";
            Navigation.PushAsync(new Login());
        }
    }
}