.assembly HW2Classes
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit HW2Classes.Parser
    extends System.Object
{
  .method public hidebysig static int32
    TryParseArguments(string[] args, [out] valuetype HW2Classes.Operations& operation,
      [out] int32& val1, [out] int32& val2) 
    cil managed
  {
    .maxstack 2
    .locals init ([0] bool)
    
    ldarg.0      // args
    call         bool HW2Classes.Parser::CheckArgumentsCount(string[])
    brtrue.s    try_parse_operation

    ldc.i4.1
    ret

    try_parse_operation: ldarg.0      // args
    ldc.i4.1
    ldelem.ref
    ldarg.1      // operation
    call         bool HW2Classes.Parser::TryParseOperation(string, valuetype HW2Classes.Operations&)
    brtrue.s    try_parse_values

    ldc.i4.3
    ret

    try_parse_values: ldarg.0      // args
    ldc.i4.0
    ldelem.ref
    ldarg.2      // val1
    call         bool HW2Classes.Parser::TryParseValue(string, int32&)
    stloc.0
    
    ldarg.0      // args
    ldc.i4.2
    ldelem.ref
    ldarg.3      // val2
    call         bool HW2Classes.Parser::TryParseValue(string, int32&)
    
    ldloc.0
    bne.un exception
    
    ldloc.0
    brtrue.s correct
    
    exception: ldc.i4.2
    ret

    correct: ldc.i4.0      
    ret
  } 

  .method private hidebysig static bool
    TryParseValue(string arg, [out] int32& val) 
    cil managed
  {
    .maxstack 2

    ldarg.0      // arg
    ldarg.1      // val
    call         bool [System.Runtime]System.Int32::TryParse(string, int32&)
    
    brfalse.s    exception

    ldc.i4.1
    ret

    exception: ldstr        "Value is not int: "
    ldarg.0      // arg
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)

    ldc.i4.0
    ret
  }

  .method private hidebysig static valuetype HW2Classes.Operations Switch(string arg)
  cil managed
  {
    .maxstack 2
    
    ldarg.0      // arg
    ldstr        "+"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     operation_plus
    
    ldarg.0      // arg
    ldstr        "-"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     operation_minus
    
    ldarg.0      // arg
    ldstr        "*"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     operation_multiply
    
    ldarg.0      // arg
    ldstr        "/"
    call         bool [System.Runtime]System.String::op_Equality(string, string)
    brtrue.s     operation_divide
    
    br.s         wrong_operation

    operation_plus: ldc.i4.0
    ret      

    operation_minus: ldc.i4.1
    ret     

    operation_multiply: ldc.i4.2
    ret      

    operation_divide: ldc.i4.3
    ret      

    wrong_operation: ldc.i4.4
    ret      
  }

  .method private hidebysig static bool
    TryParseOperation(string arg, [out] valuetype HW2Classes.Operations& operation) 
    cil managed
  {
    .maxstack 2
    .locals init ([0] int32 temp, [1] int32 V_1, [2] bool V_2, [3] bool V_3)
    
    ldarg.0
    call valuetype HW2Classes.Operations HW2Classes.Parser::Switch(string)
    stloc.0     

    ldloc.0      // temp
    ldc.i4.4
    blt.s correct

    ldstr        "The calculator does not recognize this operation: "
    ldarg.0      // arg
    call         string [System.Runtime]System.String::Concat(string, string)
    call         void [System.Console]System.Console::WriteLine(string)

    ldc.i4.0
    ret

    correct: ldarg.1      // operation
    ldloc.0               // temp
    stind.i4

    ldc.i4.1
    ret
  } 

  .method private hidebysig static bool
    CheckArgumentsCount(string[] args) 
    cil managed
  {
        .maxstack 2
        .locals init ([0] int32)

        ldarg.0  //[ 1 + 1 ]
        ldlen    //[ 3 ]
        stloc.0  //[]
        ldloc.0  //[3]
        ldc.i4.3 //[ 3 ]
        bne.un exception

        ldc.i4.1
        ret

        exception: ldstr "The program requires 3 arguments to work, but the {0} was entered"
        ldloc.0
        box [System.Private.CoreLib]System.Int32
        call string [System.Private.CoreLib]System.String::Format(string, object)
        call void [System.Console]System.Console::WriteLine(string)

        ldc.i4.0
        ret
  } 
} 
