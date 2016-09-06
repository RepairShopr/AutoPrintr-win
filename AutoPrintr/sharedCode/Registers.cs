using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPrintr
{

    public static class Registers
    {
        public static Register get(int id)
        {
            return Program.config.registers.Find(v => v.id == id);
        }

        public static Register get(string name)
        {
            return Program.config.registers.Find(v => v.name == name);
        }

        public static void Add(Register r)
        {
            Program.config.registers.Add(r);
            Program.config.save();
        }
    }

    /// <summary>
    /// Register class api/v1/settings/printing
    /// </summary>
    public class Register
    {
        public int id = 0;
        public string name = "";
        public int location_id = 0;
        public string location_name = "";
    }
}
