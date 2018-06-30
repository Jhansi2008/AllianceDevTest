using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace Entities
{
    public class EntityBase<T>
    {
        private static string fileStoragePath = null;

        public string Id
        {
            get;
            set;
        }

        public EntityBase()
        {
            EntityBase<T>.fileStoragePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetPath(string Id)
        {
            string path=EntityBase<T>.fileStoragePath + "\\" + Id + ".txt";
            return path;
        }
        public void Save()
        {
            this.Id = Guid.NewGuid().ToString();
           

            using (StreamWriter file = File.CreateText(GetPath(this.Id)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);

            }
        }

        public void Delete()
        {
          
            File.Delete(GetPath(this.Id));
            this.Id = null;
        }

        public static T Find(string Id)
        {
          
          
            T result = default(T);
            bool flag = File.Exists(GetPath(Id));
            if (flag)
            {
               
                    using (StreamReader file = File.OpenText(GetPath(Id)))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        result = (T)(serializer.Deserialize(file, typeof(T)));
                    }
               
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            bool areEqual = true;
            bool flag = obj.GetType().FullName == typeof(T).FullName;
            if (flag)
            {
                PropertyInfo[] properties = base.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = properties[i];
                    areEqual = (areEqual && property.GetValue(this).Equals(obj.GetType().GetProperty(property.Name).GetValue(obj)));
                }
            }
            else
            {
                areEqual = false;
            }
            return areEqual;
        }
    }
}
