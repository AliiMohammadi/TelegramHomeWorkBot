using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public static class SaveSystem
{
    public static string DataPath = @"D:\Datapref.txt";
    private static SaveData save;
    private static bool isLoaded = false;
    public static void Load()
    {
        if (!isLoaded)
        {
            if (File.Exists(DataPath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(DataPath, FileMode.Open);
                save = (SaveData)bf.Deserialize(file);
                file.Close();
                save.dicItems = new Dictionary<string, SaveData.Item>();
                foreach (SaveData.Item i in save.items)
                    save.dicItems.Add(i._key, i);
            }
            else
            {
                save = new SaveData();
            }
            isLoaded = true;
        }
    }
    /// <summary>
    /// پاک کردن کل اطلاعات
    /// </summary>
    private static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(DataPath);
        //save.dId = SystemInfo.deviceUniqueIdentifier;
        save.dId = "A";
        bf.Serialize(file, save);
        file.Close();
    }

    public static void OpenSaveFile()
    {
        {
            if (File.Exists(DataPath))
            {
                System.Diagnostics.Process.Start(DataPath);
            }
        }
    }
    public static void Clear()
    {
        if (File.Exists(DataPath))
        {
            File.Delete(DataPath);
            isLoaded = false;
        }
        Load();
    }

    public static bool HasHey(string key)
    {
        return save.dicItems.ContainsKey(key);
    }
    public static string GetString(string key, string alter = "")
    {
        if (!isLoaded)
            Load();

        if (HasHey(key))
            return save.dicItems[key]._value;
        else
            return alter;
    }
    public static void SetString(string key, string value)
    {
        if (!isLoaded)
            Load();

        if (HasHey(key))
            save.dicItems[key]._value = value;
        else
        {
            SaveData.Item c = new SaveData.Item() { _key = key, _value = value };
            save.dicItems.Add(c._key, c);
            save.items.Add(c);
        }
        Save();
    }
    public static void SetJsonNode(string key, JSonSingleObject.JSONNode value)
    {
        SetString(key, value.ToString());
    }
    public static JSonSingleObject.JSONNode GetJsonNode(string key)
    {
        if (!HasHey(key))
        {
            return null;
        }
        else
        {
            return JSonSingleObject.JSONNode.Parse(GetString(key));
        }
    }
    public static void SetDouble(string key, double value)
    {
        SetString(key, value.ToString());
    }
    public static void SetFloat(string key, float value)
    {
        SetString(key, value.ToString());
    }
    public static void SetByte(string key, byte value)
    {
        SetString(key, value.ToString());
    }
    public static void SetInt(string key, int value)
    {
        SetString(key, value.ToString());
    }
    public static void SetUint(string key, uint value)
    {
        SetString(key, value.ToString());
    }
    public static void SetLong(string key, long value)
    {
        SetString(key, value.ToString());
    }
    public static void SetUlong(string key, ulong value)
    {
        SetString(key, value.ToString());
    }
    public static void SetBool(string key, bool value)
    {
        SetString(key, value.ToString());
    }

    public static byte GetByte(string key, byte alter = 0)
    {
        return byte.Parse(GetString(key, alter.ToString()));
    }
    public static int GetInt(string key, int alter = 0)
    {
        return int.Parse(GetString(key, alter.ToString()));
    }
    public static uint GetUint(string key, uint alter = 0)
    {
        return uint.Parse(GetString(key, alter.ToString()));
    }
    public static long GetLong(string key, long alter = 0)
    {
        return long.Parse(GetString(key, alter.ToString()));
    }
    public static ulong GetUlong(string key, ulong alter = 0)
    {
        return ulong.Parse(GetString(key, alter.ToString()));
    }
    public static double GetDouble(string key, double alter = 0)
    {
        return double.Parse(GetString(key, alter.ToString()));
    }
    public static bool GetBool(string key, bool alter=false)
    {
        return bool.Parse(GetString(key, alter.ToString()));
    }
    public static float GetFloat(string key, float alter=0)
    {
        return float.Parse(GetString(key, alter.ToString()));
    }




    [System.Serializable()]
    public class SaveData
    {
        public string dId;

        public List<Item> items = new List<Item>();
        [System.NonSerialized()]
        public Dictionary<string, Item> dicItems = new Dictionary<string, Item>();

        [System.Serializable()]
        public class Item
        {
            public string key;
            public string value;
            public string _key
            {
                set
                {
                    key = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
                }
                get
                {
                    return Encoding.UTF8.GetString(Convert.FromBase64String(key));
                }
            }
            public string _value
            {
                set
                {
                    this.value = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
                }
                get
                {
                    return Encoding.UTF8.GetString(Convert.FromBase64String(value));
                }
            }
        }
    }
}
