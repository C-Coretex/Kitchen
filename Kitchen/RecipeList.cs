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
        static public void Serialization(string name, string ingridients, string description)
        {
            RecipeList RL = new RecipeList
            {
                Name = name,
                Ingridients = ingridients,
                Description = description
            };
            // создаем объект BinaryFormatter
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(Form2.pathToFile + "Recipe.dat", FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, RL);
            }
        }
        static public RecipeList Deserialization()
        {
            using (FileStream fs = new FileStream(Form2.pathToFile + "Recipe.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                RecipeList newRL = (RecipeList)formatter.Deserialize(fs);
                return newRL;
            }
        }
    }
}
