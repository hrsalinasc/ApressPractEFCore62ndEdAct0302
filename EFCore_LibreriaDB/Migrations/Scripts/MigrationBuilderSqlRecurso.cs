using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.Reflection;
using System.Text;

namespace EFCore_LibreriaDB.Migrations.Scripts
{
    public static class MigrationBuilderSqlRecurso
    {
        public static OperationBuilder<SqlOperation> SqlRecurso(this MigrationBuilder migrationBuilder, string nomobreArchivoRelativo)
        {
            using (var stream = Assembly.GetAssembly(typeof(MigrationBuilderSqlRecurso)).GetManifestResourceStream(nomobreArchivoRelativo))
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    var data = memoryStream.ToArray();
                    var texto = Encoding.UTF8.GetString(data, 3, data.Length - 3);
                    return migrationBuilder.Sql(texto);
                }
            }
        }
    }
}
