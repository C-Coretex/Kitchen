using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Kitchen
{
    [Serializable]
    class RecipeList
    {
        public string Name { get; set; }
        public string Ingridients { get; set; }
        public string Description { get; set; }
        static public void NameGenerator()
        {
        }
    }
}
