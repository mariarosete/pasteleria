using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace Acceso_A_Datos_MariaRS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OleDbConnection conexion;
        private OleDbDataAdapter adaptador;
        private DataSet miDataSet;


        public MainWindow()
        {
            InitializeComponent();
            ConectaBD();
            CargaGrid();
        }

        // Método para conectar a la BBDD
        public void ConectaBD()
        {
            try
            {
                // Establece la cadena de conexión con la BBDD
                string archivo = "recetas.accdb";
                string cadenaConexion = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={archivo};";
                conexion = new OleDbConnection(cadenaConexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para cargar los datos en el DataGrid
        private void CargaGrid(int idSeleccionado = -1)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                adaptador = new OleDbDataAdapter("SELECT * FROM recetas;", conexion);
                miDataSet = new DataSet();
                adaptador.Fill(miDataSet, "recetas");

                if (!miDataSet.Tables["recetas"].Columns.Contains("ImagenBitmap"))
                {
                    miDataSet.Tables["recetas"].Columns.Add("ImagenBitmap", typeof(BitmapImage));
                }

                foreach (DataRow row in miDataSet.Tables["recetas"].Rows)
                {
                    row["Nombre"] = row["Nombre"].ToString().Trim();
                    row["Chef"] = row["Chef"].ToString().Trim();

                    string rutaRelativa = row["Imagen"].ToString();
                    string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                    string rutaCompleta = System.IO.Path.Combine(rutaBase, rutaRelativa);

                    if (File.Exists(rutaCompleta))
                    {
                        BitmapImage imagen = new BitmapImage(new Uri(rutaCompleta, UriKind.Absolute));
                        row["ImagenBitmap"] = imagen;
                    }
                }

                dgRecetas.ItemsSource = miDataSet.Tables["recetas"].DefaultView;

                if (idSeleccionado != -1)
                {
                    foreach (DataRowView row in dgRecetas.Items)
                    {
                        if ((int)row["Id"] == idSeleccionado)
                        {
                            dgRecetas.SelectedItem = row;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        // Método para desplazar el scroll automáticamente al registro seleccionado
        private void ScrollToSelectedItem()
        {
            if (dgRecetas.SelectedItem != null)
            {
                dgRecetas.ScrollIntoView(dgRecetas.SelectedItem);
            }
        }



        // Método para navegar a la siguiente receta en el DataGrid
        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecetas.Items.Count - 1 > dgRecetas.SelectedIndex)
            {
                dgRecetas.SelectedIndex++;
            }
        }
        
        // Método para navegar a la anterior receta en el DataGrid
        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecetas.SelectedIndex > 0)
            {
                dgRecetas.SelectedIndex--;
            }
        }

        // Método para borrar una receta seleccionada
        private void botnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecetas.SelectedItem != null)
            {
                string nombre = ((DataRowView)dgRecetas.SelectedItem).Row["Nombre"].ToString();

                if (MessageBox.Show("¿Estás seguro de que quieres borrar la receta " + nombre + " " +
 "?", "Borrado", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = (int)((DataRowView)dgRecetas.SelectedItem).Row["id"];
                    BorraEnBD(id);
                }
            }
            else
                MessageBox.Show("No hay ninguna receta seleccionada");
        }

        // Método para borrar una receta en la BBDD usando su ID
        //Se mantiene la selección en el registro anterior
        private void BorraEnBD(int id)
        {
            int indiceActual = dgRecetas.SelectedIndex;

            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }

                OleDbCommand comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM recetas WHERE id=" + id;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar la receta: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            CargaGrid();

            // Seleccionar el registro anterior al eliminado
            if (dgRecetas.Items.Count > 0)
            {
                if (indiceActual > 0)
                    dgRecetas.SelectedIndex = indiceActual - 1;
                else
                    dgRecetas.SelectedIndex = 0;

                ScrollToSelectedItem(); // Desplazar el scroll al registro seleccionado
            }
        }



        // Método para insertar una nueva receta en la BBDD
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            DialogoReceta dlgNuevo = new DialogoReceta();
            if (dlgNuevo.ShowDialog() == true)
            {
                InsertaEnBD(dlgNuevo.Receta);
            }
        }

        // Método para modificar una receta seleccionada
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecetas.SelectedItem != null)
            {
                DataRowView row = (DataRowView)dgRecetas.SelectedItem;
                Receta receta = new Receta
                {
                    Id = (int)row["Id"],
                    Nombre = row["Nombre"].ToString(),
                    Chef = row["Chef"].ToString(),
                    Tipo = row["Tipo"].ToString(),
                    TiempoPreparacion = row["TiempoPreparacion"].ToString(),
                    Dificultad = row["Dificultad"].ToString(),
                    Imagen = row["Imagen"].ToString()
                };

                DialogoReceta dlgModificar = new DialogoReceta(receta);
                if (dlgModificar.ShowDialog() == true)
                {
                    ModificaEnBD(dlgModificar.Receta);
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna receta seleccionada");
            }
        }

        // Método para insertar una receta en la BBDD
        private void InsertaEnBD(Receta receta)
        {
            try
            {
                conexion.Open();
                OleDbCommand comando = new OleDbCommand($"INSERT INTO recetas (Nombre, Chef, Tipo, TiempoPreparacion, Dificultad, Imagen) VALUES (@Nombre, @Chef, @Tipo, @TiempoPreparacion, @Dificultad, @Imagen)", conexion);
                comando.Parameters.AddWithValue("@Nombre", receta.Nombre);
                comando.Parameters.AddWithValue("@Chef", receta.Chef);
                comando.Parameters.AddWithValue("@Tipo", receta.Tipo);
                comando.Parameters.AddWithValue("@TiempoPreparacion", receta.TiempoPreparacion);
                comando.Parameters.AddWithValue("@Dificultad", receta.Dificultad);
                comando.Parameters.AddWithValue("@Imagen", receta.Imagen);
                comando.ExecuteNonQuery();

                // Obtener el ID del último registro insertado
                OleDbCommand cmdGetId = new OleDbCommand("SELECT @@IDENTITY", conexion);
                int nuevoId = Convert.ToInt32(cmdGetId.ExecuteScalar());

                // Llamar a CargaGrid con el nuevo ID para seleccionar el registro insertado
                CargaGrid(nuevoId);
                ScrollToSelectedItem();  // Desplazar el scroll al registro seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la receta: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conexion.Close();
            }
        }
        // Método para modificar una receta en la BBDD
        private void ModificaEnBD(Receta receta)
        {
            try
            {
                conexion.Open();
                OleDbCommand comando = new OleDbCommand($"UPDATE recetas SET Nombre = @Nombre, Chef = @Chef, Tipo = @Tipo, TiempoPreparacion = @TiempoPreparacion, Dificultad = @Dificultad, Imagen = @Imagen WHERE Id = @Id", conexion);
                comando.Parameters.AddWithValue("@Nombre", receta.Nombre);
                comando.Parameters.AddWithValue("@Chef", receta.Chef);
                comando.Parameters.AddWithValue("@Tipo", receta.Tipo);
                comando.Parameters.AddWithValue("@TiempoPreparacion", receta.TiempoPreparacion);
                comando.Parameters.AddWithValue("@Dificultad", receta.Dificultad);
                comando.Parameters.AddWithValue("@Imagen", receta.Imagen);
                comando.Parameters.AddWithValue("@Id", receta.Id);
                comando.ExecuteNonQuery();

                // Llamar a CargaGrid con el ID del registro modificado para seleccionarlo
                CargaGrid(receta.Id);
                ScrollToSelectedItem();  // Desplazar el scroll al registro seleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la receta: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void botnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }

    // Clase que representa una receta
    public class Receta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Chef { get; set; }
        public string Tipo { get; set; }
        public string TiempoPreparacion { get; set; }
        public string Dificultad { get; set; }
        public string Imagen { get; set; }
    }

}

