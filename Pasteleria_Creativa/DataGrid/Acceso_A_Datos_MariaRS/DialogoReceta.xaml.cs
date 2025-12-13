using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Acceso_A_Datos_MariaRS
{
    /// <summary>
    /// Lógica de interacción para DialogoReceta.xaml
    /// </summary>
    public partial class DialogoReceta : Window
    {
        public Receta Receta { get; set; }

        public DialogoReceta()
        {
            InitializeComponent();
            Receta = new Receta();
            this.DataContext = Receta;
        }

        public DialogoReceta(Receta receta)
        {
            InitializeComponent();
            this.Receta = receta;
            this.DataContext = this.Receta;
            this.Title = "Modificar Receta";

            btnGuardar.Content = "Modificar";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}