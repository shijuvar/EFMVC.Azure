Imports System.Data.Entity.Migrations
Imports System.Data.Entity.Migrations.Providers
Imports System.Data.SqlClient

Namespace $rootnamespace$.Migrations

    Public Class Settings
        ' TODO: replace [[type name]] with your code first context type name
        Inherits DbMigrationContext(Of [[type name]])

        Public Sub New()
            AutomaticMigrationsEnabled = False
            SetCodeGenerator(Of VBMigrationCodeGenerator)()
            AddSqlGenerator(Of SqlConnection, SqlServerMigrationSqlGenerator)()

            ' Uncomment the following line if you are using SQL Server Compact 
            ' SQL Server Compact is available as the SqlServerCompact NuGet package
            ' AddSqlGenerator(Of System.Data.SqlServerCe.SqlCeConnection, SqlCeMigrationSqlGenerator)()

            ' Seed data: 
            '   Override the Seed method in this class to add seed data.
            '    - The Seed method will be called after migrating to the latest version.
            '    - The method should be written defensively in order that duplicate data is not created. E.g:
            '
            '        If Not context.Countries.Any() Then
            '            context.Countries.Add(New Country() { Name = "Australia" })
            '            context.Countries.Add(New Country() { Name = "New Zealand" })
            '        End If
            '
        End Sub

    End Class

End Namespace
