module HW

open System
open HW5
open ResultBuilder
open Parser
open Calculator

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open Giraffe

let parametersCalculatorHandler:HttpHandler =
    fun next ctx ->
        let res = result {
            let! expression = ctx.TryBindQueryString<Expression>()
            let args = [|expression.V1; expression.op; expression.V2|]
            let! output = tryParseArgs args 
            return calculate output
        }
        
        match res with
        | Ok ok -> (setStatusCode 200 >=> json ok) next ctx
        | Error error -> (setStatusCode 400 >=> json error) next ctx
    
let webApp =
    choose [
        GET >=> choose[
            route "/"            >=> text "calculator now in browser"
            route "/calculate"   >=> parametersCalculatorHandler]
        setStatusCode 404        >=> text "Page not Found"
        ]     

let configureApp (app : IApplicationBuilder) =
    app.UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .Configure(configureApp)
                    .ConfigureServices(configureServices)
                    |> ignore)
        .Build()
        .Run()
    0