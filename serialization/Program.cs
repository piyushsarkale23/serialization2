using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student()
            {
                rollno = 1,
                name = "Saul",
                percentage = 100
            };
            string path = "data.save";
            DataSerializer ds = new DataSerializer();
            Student s = null;
            DataSerializer.BinarySerialize(s, filepath);
            s = DataSerializer.BinaryDeserialize(filepath) as Student;

            Console.WriteLine(s.rollno);
            Console.WriteLine(s.name);
            Console.WriteLine(s.percentage);

        }
    }
    public class Student
    {
        public int rollno;
        public string name;
        public int percentage;
    }
    class DataSerializer
    {
        public void BinarySerialize(object data, String filepath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filepath)) File.Delete(filepath);
            fileStream = File.Create(filepath);
            bf.Serialize(fileStream, data);
            fileStream.Close();

        }
    }
    public object BinaryDeserialize(String filepath)
    {
        object obj = null;

        FileStream fileStream;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filepath))
        {
            fileStream = File.OpenRead(filepath);
            obj = bf.Deserialize(fileStream);
            fileStream.Close();
        }
    }
}

        
