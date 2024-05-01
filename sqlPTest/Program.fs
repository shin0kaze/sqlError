
open FSharp.Data.Sql

let [<Literal>] resolutionPath = __SOURCE_DIRECTORY__ + @"\..\files" 
let [<Literal>] connectionString = "Data Source=" + __SOURCE_DIRECTORY__ + @"\test.db;Mode=ReadWriteCreate"

printfn $"resolution: {resolutionPath}"
printfn $"connection: {connectionString}"

type sql = SqlDataProvider<
                DatabaseVendor = Common.DatabaseProviderTypes.SQLITE,
                ConnectionString = connectionString,        
                SQLiteLibrary = Common.SQLiteLibrary.MicrosoftDataSqlite,
                ResolutionPath = resolutionPath, 
                CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>

[<EntryPoint>]
let main _ = 
    let ctx = sql.GetDataContext()
    //let m = ctx.Main Error!
    printfn "%s" (ctx.Main.Customers |> Seq.head |> _.City)
    0