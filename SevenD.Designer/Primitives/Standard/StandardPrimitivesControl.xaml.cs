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

namespace SevenD.Designer.Primitives.Standard
{
    /// <summary>
    /// Interaction logic for StandardPrimitivesControl.xaml
    /// </summary>
    public partial class StandardPrimitivesControl : UserControl
    {
        private DockPanel _workPanel;

        public void SetWorkPanel(DockPanel workPanel)
        {
            _workPanel = workPanel;
        }
        public StandardPrimitivesControl()
        {
            InitializeComponent();
        }

        private void btnBox_Click(object sender, RoutedEventArgs e)
        {
            if (_workPanel != null)
            {
                BoxPropertiesControl bPC = new BoxPropertiesControl();


                DockPanel.SetDock(bPC, Dock.Top);
                _workPanel.Children.Add(bPC);

            }


        }
    }
}
