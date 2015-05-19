// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using SevenD.Knowledge;
using _3DTools;

namespace SevenD.Designer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool hasHitAPrimitive3D = false;
        private Point hitPrimitiveInitialPosition;
        QuadraticSurface.Primitive3D hitPrimitive;

        Menus.MainMenuControl _currentMainMenuControl = null;
        Primitives.PrimitivesPanelControl _currentPrimitivesPanelControl = null;
        private bool mDown;
        private Point mLastPos;
        public MainWindow()
        {
            InitializeComponent();

            //MouseHelper mh = new MouseHelper(p_camera);
            //mh.EventSource = MainViewPort3D;
            //////////////mh.WorkViewPort3D = MainViewPort3D;

            Trackball tb = new Trackball();
            tb.EventSource = utilityBorder;
            MainViewPort3D.Camera.Transform = tb.Transform;


            Menus.MainMenuControl mainMenuInstance = new Menus.MainMenuControl();
            _currentMainMenuControl = mainMenuInstance;
            dpTopPanel.Children.Add(mainMenuInstance);
            _currentPrimitivesPanelControl = new Primitives.PrimitivesPanelControl(dpRightPrimitivesPanel);
            dpRightPrimitivesPanel.Children.Add(_currentPrimitivesPanelControl);



            

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
            this.Topmost = true;
            this.WindowState = System.Windows.WindowState.Maximized;

            QuadraticSurface.Cone3D c3D2 = new QuadraticSurface.Cone3D();
            c3D2.Material = new DiffuseMaterial(Brushes.IndianRed);
            c3D2.Transform = new TranslateTransform3D(0, 0, 2);
            MainViewPort3D.Children.Add(c3D2);


            QuadraticSurface.Sphere3D s3D = new QuadraticSurface.Sphere3D();
            s3D.Material = new DiffuseMaterial(Brushes.DarkGoldenrod);
            s3D.Transform = new TranslateTransform3D(3, 3, 2);
            
            
            Transform3DGroup tG3D = new Transform3DGroup();         
            tG3D.Children.Add(new TranslateTransform3D(-1, 3, -0.5));
            Rotation3D r3D = new AxisAngleRotation3D(new Vector3D(0,0,1), 45);
            tG3D.Children.Add(new RotateTransform3D(r3D,0,0,0.5));


            QuadraticSurface.Cylinder3D cyl3D = new QuadraticSurface.Cylinder3D();
            cyl3D.Material = new DiffuseMaterial(Brushes.LightCoral);
            cyl3D.Transform = tG3D;


          


            MainViewPort3D.Children.Add(cyl3D);
           


          



            QuadraticSurface.Conic1 e1 = new QuadraticSurface.Conic1();
          
            e1.Material = new DiffuseMaterial(Brushes.Red);
            e1.Transform = new TranslateTransform3D(4, -2, 3);
            MainViewPort3D.Children.Add(e1);


            QuadraticSurface.Torus2 t2 = new QuadraticSurface.Torus2();
           
            t2.Material = new DiffuseMaterial(Brushes.Red);
            t2.Transform = new TranslateTransform3D(1, -4, 2);
            MainViewPort3D.Children.Add(t2);


            QuadraticSurface.Simple3D.Cube simpleCube = new QuadraticSurface.Simple3D.Cube(9.0D);
            ModelVisual3D cubeAsM3D = simpleCube.GetAsModelVisual3D();
            cubeAsM3D.Transform = new TranslateTransform3D(1, 1, 2);
            MainViewPort3D.Children.Add(cubeAsM3D);


            QuadraticSurface.Simple3D.Pyramid thoutmes = new QuadraticSurface.Simple3D.Pyramid(35,80,18);
            ModelVisual3D pyramidAsM3D = thoutmes.GetAsModelVisual3D();
            pyramidAsM3D.Transform = new TranslateTransform3D(-1, -3, 15);
            MainViewPort3D.Children.Add(pyramidAsM3D);


            MainViewPort3D.MouseDown +=new MouseButtonEventHandler(MainViewPort3D_MouseDown);
            MainViewPort3D.MouseLeftButtonDown +=new MouseButtonEventHandler(MainViewPort3D_MouseLeftButtonDown);
            MainViewPort3D.MouseLeftButtonUp +=new MouseButtonEventHandler(MainViewPort3D_MouseLeftButtonUp);



            
            
            


            
        }

        ModelVisual3D GetHitTestResult(Point location)
        {
            HitTestResult result = VisualTreeHelper.HitTest(MainViewPort3D, location);
            if (result != null && result.VisualHit is ModelVisual3D)
            {
                ModelVisual3D visual = (ModelVisual3D)result.VisualHit;
                return visual;
            }

            return null;
        }


        public void MainViewPort3D_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(MainViewPort3D);
            ModelVisual3D result = GetHitTestResult(location);
            if (result == null)
            {
                return;
            }
            if (result is QuadraticSurface.Primitive3D)
            {
                hitPrimitiveInitialPosition = location;
                hasHitAPrimitive3D = true;
                hitPrimitive = (QuadraticSurface.Primitive3D)result;
                return;
            }
            





        }

        public void MainViewPort3D_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point location = e.GetPosition(MainViewPort3D);
            
          
            Point newPosition = location;
            if (hasHitAPrimitive3D)
            {
                
                double deltaX = newPosition.X - hitPrimitiveInitialPosition.X;
                hitPrimitive.Transform = new TranslateTransform3D( 0.005, 0, 0);
                hasHitAPrimitive3D = false;
                return;

            }

        }

        public void MainViewPort3D_MouseDown(object sender, MouseButtonEventArgs e)
        {

           
            
            Point location = e.GetPosition(MainViewPort3D);
            ModelVisual3D result = GetHitTestResult(location);
            if (result == null)
            {
                return;
            }

            if (result is QuadraticSurface.Cone3D)
            {
                QuadraticSurface.Cone3D cRef = (QuadraticSurface.Cone3D)result;
                cRef.Material = new DiffuseMaterial(Brushes.LightSteelBlue);
                return;
            }




        }

       

    }
}
