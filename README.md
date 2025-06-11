# MadMilkMan.Ini_Decrypter
Decrypter for .ini files encrypted with [MadMilkMan.Ini](https://github.com/MarioZ/MadMilkman.Ini).

### How can I know that I need this tool?
This tool was mainly intended to be designed around games, specifically [Ma Furu Yoru no Rin](https://vndb.org/v12297) and [Onmyou Kishi Towako -Hebigami no Inma Choukyou-](https://vndb.org/v13015). These two games include a file called MadMilkMan.Ini, and by also checking their root folder, also include an .ini file, which has some contents inside of it that are seemingly completely random.
This .ini file happens to have the password used for encrypting the .pkg files (they are just .zip files) that both games have for storing their resources. So, in order to obtain said password, you will first need to obtain the password used for encrypting the .ini file.

### Where can I get this password?
- If the main executable happens to be compiled in **C#**, most of the time it will be stored inside the main executable, so using any tool like [dnSpy](https://github.com/dnSpyEx/dnSpy) and [ILSpy](https://github.com/icsharpcode/ILSpy) will help you see the insides of the main executable, you'll just need to look everywhere to see where they keep it.
- If the program you are trying to tinker with happens to be compiled in **C/C++**, you will need to use any decompiler like [IDA](https://hex-rays.com/) or [Ghidra](https://github.com/NationalSecurityAgency/ghidra), and repeat the same process mentioned with the C# situation.

## Licenses
[MadMilkMan.Ini](https://github.com/MarioZ/MadMilkman.Ini) - MIT License
