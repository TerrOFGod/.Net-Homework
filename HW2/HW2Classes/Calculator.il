.assembly HW2Classes
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  HW2Classes.Calculator
    extends System.Object
{

  .method public hidebysig static int32
    Calculate(valuetype HW2Classes.Operations operation, int32 val1,
      int32 val2) 
    cil managed
  {
    .maxstack 2
    .locals init ([0] int32 result)

    ldarg.0          // operation
    switch       (plus, minus, multiply)
    br.s         divide

    plus: ldarg.1     // val1
    ldarg.2           // val2
    add
    stloc.0           // set result
    br.s         get_result

    minus: ldarg.1    // val1
    ldarg.2           // val2
    sub
    stloc.0           // set result
    br.s         get_result

    multiply: ldarg.1 // val1
    ldarg.2           // val2
    mul
    stloc.0           // set result
    br.s         get_result

    divide: ldarg.1   // val1
    ldarg.2           // val2
    div
    stloc.0           // set result
    br.s         get_result

    get_result: ldloc.0   // get result
    ret
  } 
} 
