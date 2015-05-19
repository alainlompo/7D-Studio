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

namespace SevenD.Designer.Primitives.Demos
{
    public class CubeDemoPrimitive
    {
        private PerspectiveCamera _workCamera;
        private Viewport3D _workViewPort3D;

        public void setViewPort3D(Viewport3D vp3D)
        {
            _workViewPort3D = vp3D;
        }
        public void SetWorkCamera(PerspectiveCamera camera)
        {
            _workCamera = camera;

        }
    }
}
