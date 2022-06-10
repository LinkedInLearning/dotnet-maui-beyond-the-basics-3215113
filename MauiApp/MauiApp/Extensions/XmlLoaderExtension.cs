using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiBeyond.Extensions
{
    public class XmlLoaderExtension : IMarkupExtension<string>
    {
        public string TargetNode { get; set; }
        public string ResourceFile { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(ResourceFile) && !string.IsNullOrEmpty(TargetNode))
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(XmlLoaderExtension)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(ResourceFile);
                string text = "";
                using (var reader = new System.IO.StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(text);
                var nodes = xmlDoc.GetElementsByTagName(TargetNode);
                if (nodes != null && nodes.Count > 0)
                {
                    returnValue = nodes[0].InnerText;
                }
            }
            return returnValue;

        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
