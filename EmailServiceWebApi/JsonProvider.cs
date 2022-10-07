using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace EmailServiceWebApi
{
    public class JsonProvider
    {
        private string path { get; }

        /// <summary>
        /// A universal class that handles json files in the root directory (where the exe-file is stored)
        /// </summary>
        /// <param name="name">the name of the file that the class works with (write it down without .json)</param>
        public JsonProvider(string name)
        {
            path = AppContext.BaseDirectory + name + ".json";
        }

        /// <summary>
        /// Creates or overwrites a file
        /// </summary>
        /// <typeparam name="T">The type of object that is written to the file (classes or lists with arrays)</typeparam>
        /// <param name="TObject"></param>
        public void Write<T>(T TObject)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(TObject, options);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Reads an object from a file
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <returns></returns>
        public T Read<T>() where T : new()
        {
            T TObject = new T();
            try
            {
                var json = File.ReadAllText(path);
                TObject = JsonSerializer.Deserialize<T>(json);
            }
            catch (FileNotFoundException)
            {
            }
            return TObject;
        }
    }
}
