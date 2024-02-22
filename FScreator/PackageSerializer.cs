using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PackageSerializer
{
    public static void Serialize<T>(T obj, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, obj);
        }
    }

    public static T Deserialize<T>(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            return (T)formatter.Deserialize(stream);
        }
    }
}