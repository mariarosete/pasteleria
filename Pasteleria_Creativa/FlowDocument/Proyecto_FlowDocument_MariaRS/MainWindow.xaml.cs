using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Win32;

namespace Proyecto_FlowDocument_MariaRS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlowDocument documentoInicio;

        public MainWindow()
        {
            InitializeComponent();
            documentoInicio = fdReader.Document;
        }

        //Método para GUARDAR flowDocument
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fileStream = File.Create(saveFileDialog.FileName))
                {
                    XamlWriter.Save(fdReader.Document, fileStream);
                }
            }
        }

        //Método para CARGAR flowDocument
        private void Cargar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
                {
                    FlowDocument doc = XamlReader.Load(fileStream) as FlowDocument;
                    if (doc != null)
                    {
                        fdReader.Document = doc;
                    }
                    else
                    {
                        MessageBox.Show("El archivo no es un FlowDocument válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Método para BORRAR flowDocument
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            fdReader.Document = new FlowDocument();
        }

        // Método para imprimir flowDocument
        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            fdReader.Print();
        }

        // Cargar el FlowDocument desde el archivo Recetas.xaml
        private void Recetas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fileStream = new FileStream("Recetas.xaml", FileMode.Open, FileAccess.Read))
                {
                    FlowDocument doc = XamlReader.Load(fileStream) as FlowDocument;
                    if (doc != null)
                    {
                        fdReader.Document = doc;
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar el documento de recetas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el documento: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // Cargar el FlowDocument desde el archivo Postres.xaml
        private void Postres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fileStream = new FileStream("Postres.xaml", FileMode.Open, FileAccess.Read))
                {
                    FlowDocument doc = XamlReader.Load(fileStream) as FlowDocument;
                    if (doc != null)
                    {
                        fdReader.Document = doc;
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar el documento de postres.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el documento: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Cargar el FlowDocument desde el archivo Decoraciones.xaml
        private void Decoraciones_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fileStream = new FileStream("Decoraciones.xaml", FileMode.Open, FileAccess.Read))
                {
                    FlowDocument doc = XamlReader.Load(fileStream) as FlowDocument;
                    if (doc != null)
                    {
                        fdReader.Document = doc;
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar el documento de decoraciones.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el documento: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Volver al inicio MainWindows
        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            fdReader.Document = documentoInicio;
        }

        //Hipervínculo
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

    }
}