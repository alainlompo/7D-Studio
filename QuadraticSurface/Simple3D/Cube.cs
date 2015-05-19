// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace QuadraticSurface.Simple3D
{
    public class Cube
    {
        private Model3DGroup _instance;
        private double _side = 5.0D;


        public ModelVisual3D GetAsModelVisual3D()
        {
            ModelVisual3D model = new ModelVisual3D();
            model.Content = _instance;
            return model;
        }
        public Model3DGroup GetAsModel3DGroup()
        {
            return _instance;
        }
        public Cube(double s)
        {
            
            _side = s;
            _instance = new Model3DGroup();
            Point3D p0 = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(_side, 0, 0);
            Point3D p2 = new Point3D(_side, 0, _side);
            Point3D p3 = new Point3D(0, 0, _side);
            Point3D p4 = new Point3D(0, _side, 0);
            Point3D p5 = new Point3D(_side, _side, 0);
            Point3D p6 = new Point3D(_side, _side, _side);

            Point3D p7 = new Point3D(0, _side, _side);

            _instance.Children.Add(Utils.CreateTriangleModel(p3, p2, p6));
            _instance.Children.Add(Utils.CreateTriangleModel(p3, p6, p7));
            //right side triangles
            _instance.Children.Add(Utils.CreateTriangleModel(p2, p1, p5));
            _instance.Children.Add(Utils.CreateTriangleModel(p2, p5, p6));
            //back side triangles
            _instance.Children.Add(Utils.CreateTriangleModel(p1, p0, p4));
            _instance.Children.Add(Utils.CreateTriangleModel(p1, p4, p5));
            //left side triangles
            _instance.Children.Add(Utils.CreateTriangleModel(p0, p3, p7));
            _instance.Children.Add(Utils.CreateTriangleModel(p0, p7, p4));
            //top side triangles
            _instance.Children.Add(Utils.CreateTriangleModel(p7, p6, p5));
            _instance.Children.Add(Utils.CreateTriangleModel(p7, p5, p4));
            //bottom side triangles
            _instance.Children.Add(Utils.CreateTriangleModel(p2, p3, p0));
            _instance.Children.Add(Utils.CreateTriangleModel(p2, p0, p1));

           
        }

    }
}
