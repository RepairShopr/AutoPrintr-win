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
            //return Program.config.registers.Find(v => v.id == id);
            Register r;
            Program.config.registers.TryGetValue(id, out r);
            return r;
        }

        public static Register get(string name)
        {
            return Program.config.registers.FirstOrDefault(p => p.Value.name == name).Value;
        }

        public static void Add(Register r)
        {
            if (!Program.config.registers.ContainsKey(r.id))
            {
                Program.config.registers.Add(r.id, r);
            }
            else
            {
                Program.config.registers[r.id] = r;
            }            
            Program.config.save();
        }

        public static void Add(List<Register> rr)
        {
            foreach (Register r in rr)
            {
                if (!Program.config.registers.ContainsKey(r.id))
                {
                    Program.config.registers.Add(r.id, r);
                }
                else
                {
                    Program.config.registers[r.id] = r;
                }
            }
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
