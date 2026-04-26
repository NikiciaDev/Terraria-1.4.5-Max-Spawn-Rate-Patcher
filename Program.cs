using Mono.Cecil;
using Mono.Cecil.Cil;

var exe = "PATH TO TERRARIA EXE";
var terrарiaDir = Path.GetDirectoryName(exe);

var resolver = new DefaultAssemblyResolver();
resolver.AddSearchDirectory(terrарiaDir);

var readerParams = new ReaderParameters { AssemblyResolver = resolver };
var asm = AssemblyDefinition.ReadAssembly(exe, readerParams);
var type = asm.MainModule.GetType("Terraria.GameContent.Creative.CreativePowers/SpawnRateSliderPerPlayerPower");

var remap = type.Methods.First(m => m.Name == "RemapSliderValueToPowerValue");
foreach (var instr in remap.Body.Instructions)
{
    if (instr.OpCode == OpCodes.Ldc_R4 && (float)instr.Operand == 10f)
    {
        instr.Operand = 50f;
        Console.WriteLine("Patched RemapSliderValueToPowerValue: 10f -> 50f");
        break;
    }
}

var provideSlider = type.Methods.First(m => m.Name == "ProvideSlider");
foreach (var instr in provideSlider.Body.Instructions)
{
    if (instr.OpCode == OpCodes.Ldstr && (string)instr.Operand == "x10")
    {
        instr.Operand = "x50";
        Console.WriteLine("Patched ProvideSlider label: x10 -> x50");
        break;
    }
}

var tmp = exe + ".patched";
asm.Write(tmp);
asm.Dispose();
File.Move(tmp, exe, overwrite: true);
Console.WriteLine("Done! Terraria.exe has been patched.");
