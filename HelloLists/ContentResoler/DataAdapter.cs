using HelloLists.Base;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HelloLists.ContentResoler
{
    class DataAdapter<T> : IDataAdapter<T>
    {
        private string filePath;
        public string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(filePath)){
                    this.filePath = string.Format("C:/Data/{0}.json", typeof(T).Name);
                }

                return this.filePath;
            }

            set
            {
                this.filePath = value;
            }
        }
        
        public void Delete(T newEntry)
        {
            throw new NotImplementedException();
        }

        public void Insert(T newEntry)
        {
            List<T> list = Read();
            list.Add(newEntry);

            // Clear file content
            File.WriteAllText(FilePath, string.Empty);

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteAsync(JsonConvert.SerializeObject(list, Formatting.Indented));
                }
            }            
        }

        public List<T> Read()
        {
            string json = LoadData();

            try {
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                // Log exception
                return null;
            }
        }

        public void Update(T newEntry)
        {
            throw new NotImplementedException();
        }

        public string LoadData()
        {
            string json = string.Empty;

            var t = Task.Run(() =>
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        json = sr.ReadToEnd();
                    }
                }
            });
            t.Wait();
            
            return json;        
        }
    }
}
