using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridFunction.Infrastructure.Utility
{
    public static class MigrationUtility
    {
        /// <summary>
        /// Read SQL Script if available
        /// </summary>
        /// <param name="migrationType">The migration type the SQL file script is attached to.</param>
        /// <param name="fileName">The embedded SQL file name.</param>
        /// <returns>The content of the SQL file.</returns>
        public static string ReadSql(Type migrationType, string fileName)
        {
            var assembly = migrationType.Assembly;
            string resourceName = $"{migrationType.Namespace}.{fileName}";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Unable to find the SQL file from an embedded resource", resourceName);
                }

                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
        }
    }
}
