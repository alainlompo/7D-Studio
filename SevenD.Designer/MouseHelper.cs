// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace SevenD.Knowledge
{
    public class MouseHelper
    {
        private PerspectiveCamera _camera;
        private FrameworkElement _eventSource;
        private Point _position;
        //////////////private Point mLastPos = new Point(0,0);
        private double _diffX = 0;
        //////////////Boolean mDown = false;

        //////////////public Viewport3D WorkViewPort3D { get; set; }

       

        public MouseHelper(PerspectiveCamera camera)
        {
            _camera = camera;
        }


        public FrameworkElement EventSource
        {
            get { return _eventSource; }

            set
            {
                if (_eventSource != null)
                {
                    _eventSource.MouseDown -= this.OnMouseDown;
                    _eventSource.MouseUp -= this.OnMouseUp;
                    _eventSource.MouseMove -= this.OnMouseMove;
                }

                _eventSource = value;

                _eventSource.MouseDown += this.OnMouseDown;
                _eventSource.MouseUp += this.OnMouseUp;
                _eventSource.MouseMove += this.OnMouseMove;
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Mouse.Capture(EventSource, CaptureMode.Element);
            _position = e.GetPosition(EventSource);
            _diffX = 0;

            //////////////Point pos = Mouse.GetPosition(WorkViewPort3D);
            //////////////mLastPos = new Point(pos.X - WorkViewPort3D.ActualWidth / 2, WorkViewPort3D.ActualHeight / 2 - pos.Y);
            //////////////mDown = true;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Mouse.Capture(EventSource, CaptureMode.None);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(EventSource);

            _diffX = 0;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _diffX = (_position.Y - currentPosition.Y) * 0.5;
                _camera.FieldOfView -= _diffX;

            }

            //////////////else if (e.RightButton == MouseButtonState.Pressed)
            //////////////{
            //////////////    if (!mDown) return;
                
            //////////////    Point pos = Mouse.GetPosition(WorkViewPort3D);
            //////////////    Point actualPos = new Point(
            //////////////            pos.X - WorkViewPort3D.ActualWidth / 2,
            //////////////            WorkViewPort3D.ActualHeight / 2 - pos.Y);
            //////////////    double dx = actualPos.X - mLastPos.X;
            //////////////    double dy = actualPos.Y - mLastPos.Y;
            //////////////    double mouseAngle = 0;

            //////////////    if (dx != 0 && dy != 0)
            //////////////    {
            //////////////        mouseAngle = Math.Asin(Math.Abs(dy) /
            //////////////            Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
            //////////////        if (dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
            //////////////        else if (dx < 0 && dy < 0) mouseAngle += Math.PI;
            //////////////        else if (dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
            //////////////    }
            //////////////    else if (dx == 0 && dy != 0)
            //////////////    {
            //////////////        mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
            //////////////    }
            //////////////    else if (dx != 0 && dy == 0)
            //////////////    {
            //////////////        mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;
            //////////////    }

            //////////////    double axisAngle = mouseAngle + Math.PI / 2;

            //////////////    Vector3D axis = new Vector3D(
            //////////////            Math.Cos(axisAngle) * 4,
            //////////////            Math.Sin(axisAngle) * 4, 0);

            //////////////    double rotation = 0.02 *
            //////////////            Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            //////////////    Transform3DGroup group =_camera.Transform  as Transform3DGroup;
            //////////////    QuaternionRotation3D r =
            //////////////         new QuaternionRotation3D(
            //////////////         new Quaternion(axis, rotation * 180 / Math.PI));
            //////////////    group.Children.Add(new RotateTransform3D(r));

            //////////////    mLastPos = actualPos;
            //////////////}

            _position = currentPosition;
        }
    }
}
