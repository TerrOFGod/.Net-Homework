﻿module HW5.ResultBuilder

type ResultBuilder() =
    member this.Bind(x, f) =
        match x with    
        | Ok x -> f x
        | Error error -> Error error
        
    member this.Return x = Ok x

let result = ResultBuilder()
    
