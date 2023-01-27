using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlLite_EdisonTene
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarContenido : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> _TablaEstudiante;

        public ConsultarContenido()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Listar();
        }
        public async void Listar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaUsuario.ItemsSource = _TablaEstudiante;
        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id= Convert.ToInt32(item);
            var Nombre = obj.Nombre.ToString();
            var Usuario = obj.Usuario.ToString();
            var Contraseña = obj.Password.ToString();
            Navigation.PushAsync(new Elemento(Id,Nombre,Usuario,Contraseña));
        }
    }
}