using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EngmanAccron.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        protected override void OnContentRendered(EventArgs e)
        {
            //// Creates a mesh with the shape of a box
            //Mesh m = Mesh.CreateCylinder(30, 20, 10);

            //// Adds the mesh to the master entity collection
            //model1.Entities.Add(m, Color.DarkRed);

            //// Fits the drawing in the viewport
            //model1.ZoomFit();

            base.OnContentRendered(e);
        }

        private void dims_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (radius == null || height == null || num == null) return;
            model1.Entities.Clear();
            try
            {
                CreateCylinders(double.Parse(radius.Text), int.Parse(height?.Text), int.Parse(num.Text));
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CreateCylinders(double radius, int height, int num)
        {
            double translation = radius * 2;
            double accTranslation = 0;
            for (int i = 0; i < num; i++)
            {
                Mesh m = Mesh.CreateCylinder(radius, height, 100);

                accTranslation += (translation * i);
                m.Translate(accTranslation, accTranslation, 0);
                translation *= -1;

                model1.Entities.Add(m, Color.DarkRed);
            }
        }

        private void radius_LostFocus(object sender, RoutedEventArgs e)
        {
            if (radius == null || height == null || num == null) return;
            model1.Entities.Clear();
            try
            {
                CreateCylinders(double.Parse(radius.Text), int.Parse(height?.Text), int.Parse(num.Text));
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
