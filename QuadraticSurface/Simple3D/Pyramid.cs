// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace QuadraticSurface.Simple3D
{
    public class Pyramid
    {
        private Model3DGroup _instance;
        private double _baseRay = 5.0D;
        private double _height = 15.0D;
        private int _numberOfSides = 5;


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

        public Pyramid()
        {
            _instance = new Model3DGroup();

            double sliceAngle = 2 * Math.PI / _numberOfSides;

            Point3D p0 = new Point3D(0, 0, _height);

            Point3D[] points = new Point3D[_numberOfSides];
            for (int i = 0; i < _numberOfSides; i++)
            {
                points[i] = new Point3D(_baseRay * Math.Cos((i + 1) * sliceAngle), _baseRay * Math.Sin((i + 1) * sliceAngle), 0);


            }

            for (int i = 0; i < _numberOfSides - 1; i++)
            {
                _instance.Children.Add(Utils.CreateTriangleModel(p0, points[i], points[i + 1]));

            }
            _instance.Children.Add(Utils.CreateTriangleModel(p0, points[_numberOfSides - 1], points[0]));        

        }
        public Pyramid(double baseRay, double height, int numberOfSides)
        {
            
            _baseRay = baseRay;
            _height = height;
            _numberOfSides = numberOfSides;

            _instance = new Model3DGroup();

            double sliceAngle = 2 * Math.PI / numberOfSides;

            Point3D p0 = new Point3D(0, 0, height);

            Point3D[] points = new Point3D[numberOfSides];
            for (int i = 0; i < numberOfSides; i++)
            {
                points[i] = new Point3D(baseRay * Math.Cos((i + 1) * sliceAngle), _baseRay * Math.Sin((i + 1) * sliceAngle), 0);


            }

            for (int i = 0; i < numberOfSides - 1; i++)
            {
                _instance.Children.Add(Utils.CreateTriangleModel(p0, points[i], points[i+1]));

            }
            _instance.Children.Add(Utils.CreateTriangleModel(p0, points[numberOfSides-1], points[0]));




          

           

           
        }


    }
}
