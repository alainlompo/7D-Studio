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

namespace SevenD.Designer.Primitives
{
    /// <summary>
    /// Interaction logic for PrimitivesPanelControl.xaml
    /// </summary>
    public partial class PrimitivesPanelControl : UserControl
    {
        DockPanel _parentPanel = null;
        public PrimitivesPanelControl(DockPanel parentPanel)
        {
            _parentPanel = parentPanel;
            InitializeComponent();
            Standard.StandardPrimitivesControl sPC = new Standard.StandardPrimitivesControl();
            DockPanel dp = new DockPanel();
            sPC.SetWorkPanel(dp);
            tciCreation.Content = dp;
            DockPanel.SetDock(sPC, Dock.Top);


            dp.Children.Add(sPC);
        }
    }
}
