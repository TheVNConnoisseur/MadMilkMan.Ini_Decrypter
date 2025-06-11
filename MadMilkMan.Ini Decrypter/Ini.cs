using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadMilkman.Ini;

namespace MadMilkMan.Ini_Decrypter
{
    internal class Ini
    {
        IniOptions options = new IniOptions();
        IniFile iniFile;

        public Ini(string password)
        {
            options.EncryptionPassword = password;
            iniFile = new IniFile(options);
        }

        public IniFile Load(StreamReader stream)
        {
            iniFile.Load(stream);
            IniFile decryptedIniFile = new IniFile();

            foreach (IniSection section in iniFile.Sections)
            {
                decryptedIniFile.Sections.Add(section.Copy(decryptedIniFile));
            }

            return decryptedIniFile;
        }

    }
}
