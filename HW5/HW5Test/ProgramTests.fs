module HW4Tests.ProgramTests

open Xunit
open HW4

[<Fact>]
let ``Main_WrongInputData_WillReturnError`` () =
    let args = [|"332";"/";"?"|]
    let check = Program.main args
    Assert.True(check > 0)

[<Fact>]
let ``Main_CorrectInputData_WillReturnCorrect`` () =
    let args = [|"4";"*";"8"|]
    let check = Program.main args
    let result = check = 0
    Assert.True(result)  