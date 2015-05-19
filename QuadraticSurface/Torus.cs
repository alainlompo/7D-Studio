﻿// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Windows.Media;

namespace QuadraticSurface
{
    public sealed class Torus:Primitive3D
    {
        private double r=3.0d;
        private double a= 2.0d;

        public void SetRA(double r, double a)
        {
            this.r = r;
            this.a = a;
        }

        internal Point3D GetPosition(double t, double y)
        {
            double v = 0.0d;
            if (t != Math.Acos(-a / r))
                v = Math.Asin(y / (a + r * Math.Cos(t)));
            else v = Math.Asin(1);
            double x = (a+ r*Math.Cos(t))*Math.Cos(v);
            double z = r*Math.Sin(t);


            return new Point3D(x, y, z);
        }

        private Vector3D GetNormal(double t, double y)
        {
            return (Vector3D)GetPosition(t, y);
        }

        private Point GetTextureCoordinate(double t, double y)
        {
            Matrix TYtoUV = new Matrix();
            TYtoUV.Scale(1 / (2 * Math.PI), -0.5);

            Point p = new Point(t, y);
            p = p * TYtoUV;

            return p;
        }

        internal override Geometry3D Tessellate()
        {
            int tDiv = 32;
            int yDiv = 32;
            double maxTheta = DegToRad(360.0);
            double minY = -1.0;
            double maxY = 1.0;

            double dt = maxTheta / tDiv;
            double dy = (maxY - minY) / yDiv;

            MeshGeometry3D mesh = new MeshGeometry3D();

            for (int yi = 0; yi <= yDiv; yi++)
            {
                double y = minY + yi * dy;

                for (int ti = 0; ti <= tDiv; ti++)
                {
                    double t = ti * dt;

                    mesh.Positions.Add(GetPosition(t, y));
                    mesh.Normals.Add(GetNormal(t, y));
                    mesh.TextureCoordinates.Add(GetTextureCoordinate(t, y));
                }
            }

            for (int yi = 0; yi < yDiv; yi++)
            {
                for (int ti = 0; ti < tDiv; ti++)
                {
                    int x0 = ti;
                    int x1 = (ti + 1);
                    int y0 = yi * (tDiv + 1);
                    int y1 = (yi + 1) * (tDiv + 1);

                    mesh.TriangleIndices.Add(x0 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y0);

                    mesh.TriangleIndices.Add(x1 + y0);
                    mesh.TriangleIndices.Add(x0 + y1);
                    mesh.TriangleIndices.Add(x1 + y1);
                }
            }

            mesh.Freeze();
            return mesh;
        }
    }
}