using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace MauiBeyond.Extensions
{
    public class ResourceLoaderExtension : IMarkupExtension<string>
    {
        public string ResourceName { get; set; }
        public string ResourceFile { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(ResourceFile) && !string.IsNullOrEmpty(ResourceName))
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ResourceLoaderExtension)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(ResourceFile);
                byte[] promptBytes;
                string dataType;
                using (var reader = new ResourceReader(stream))
                {
                    reader.GetResourceData(ResourceName, out dataType, out promptBytes);
                    BinaryReader binaryReader = new BinaryReader(new MemoryStream(promptBytes));
                    returnValue = binaryReader.ReadString();
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
