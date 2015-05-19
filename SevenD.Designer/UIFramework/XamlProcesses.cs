// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xaml;

namespace SevenD.Designer.UIFramework
{
    public class XamlProcesses
    {

        public static object ConvertXmlToObjectGraph(string xmlString) 
        {
            using (TextReader textReader = new StringReader(xmlString))
            using (XamlXmlReader reader = new XamlXmlReader(textReader, 
                System.Windows.Markup.XamlReader.GetWpfSchemaContext()))
            using (XamlObjectWriter writer = new XamlObjectWriter(reader.SchemaContext))
            {
                while (reader.Read())
                {
                    writer.WriteNode(reader);

                }
                return writer.Result;

            }

        }
    }
}
