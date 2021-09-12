using System;
using FluentMigrator;
using Skinet.Infrastructure.Base;
using Skinet.Infrastructure.Extensions;

namespace Skinet.Infrastructure.Migrations.V1
{
    [Migration(202109000001, TransactionBehavior.Default)]
    public class TableInitial : MigrationsBaseCentral
    {
        public override void Up()
        {
            Result<Exception, Migration> resposta = CheckCreatedTables(this)
                .Bind(CreateTableProduct);
            
            Console.WriteLine(resposta);
        }

        
        public override void Down()
        {
            Delete.Table("Products");
        }

        private Result<Exception, Migration> CheckCreatedTables(Migration migration)
        {
            if (Schema.Schema(SCHEMA_APP).Table("Products").Exists())
            {
                return new ApplicationException($"{SCHEMA_APP}.Products");
            }

            return migration;
        }

        private Result<Exception, Migration> CreateTableProduct(Migration migration)
        {
            Create.Table("Products")
                .InSchema(SCHEMA_APP)

                .WithColumn("Id")
                .AsInt64()
                .PrimaryKey("PK_Products")
                .Unique()
                .NotNullable()
                .Identity()
                .WithColumnDescription("Identificador único")

                .WithColumn("Name")
                .AsAnsiString(200)
                .NotNullable()
                .WithColumnDescription("Nome do Cliente de Cobrança");

            return migration;
        }
    }
}