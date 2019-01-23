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
        public string Description { get; set; }
        public string Ingridients { get; set; }
        public string Count { get; set; }
        public string Type { get; set; }
        public string ImageDirection { get; set; }
        static public void Serialization(string name, string description, string ingridients, string count, string type, string imageDirection)
        {
            RecipeList RL = new RecipeList
            {
                Name = name,
                Description = description,
                Ingridients = ingridients,
                Count = count,
                Type = type,
                ImageDirection = imageDirection
            };
            // создаем объект BinaryFormatter
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(Form1.pathToFile + "Recipe.dat", FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, RL);
            }
        }
        static public RecipeList Deserialization()
        {
            using (FileStream fs = new FileStream(Form1.pathToFile + "Recipe.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                RecipeList newRL = (RecipeList)formatter.Deserialize(fs);
                return newRL;
            }
        }
    }
}
