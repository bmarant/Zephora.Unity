using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization.Formatters.Binary;


public class XmlSave : MonoBehaviour {


    public string PlayerName;
    public string _FileLocation;
    public string _FileName;
    CharacterInfo CharacterCreate;
    public string _data;

    // Use this for initialization
  public void Start()
    {



        CharacterCreate = new CharacterInfo();
        


    }


    public void LoadCharacter()
    {

        LoadXml();

        CharacterCreate = Deserialization(_data);
    }

    private CharacterInfo Deserialization(string pXMLSerializer)
    {
        XmlSerializer xs = new XmlSerializer(typeof(CharacterInfo));
        MemoryStream memoryStream = new MemoryStream(StringToByteArray(pXMLSerializer));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return (CharacterInfo)xs.Deserialize(memoryStream);
    }

    private byte[] StringToByteArray(string pXMLSerializer)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXMLSerializer);
        return byteArray;
    }

    private void LoadXml()
    {
        StreamReader r = File.OpenText(_FileLocation + "\\" + _FileName);
        string _info = r.ReadToEnd();
        r.Close();
        _data = _info;
        Debug.Log("File Read");
    }

   

    

    public void SaveCharacter(string charactName, string classes, string Gender)
    {


       
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Create(Application.dataPath + "/Characters" + "\\" + charactName + ".txt");

            CharacterInfo character = new CharacterInfo();
            _FileName = charactName + ".xml";
            character.Name = charactName;
            character.Class = classes;
            character.Gender = Gender;

            bf.Serialize(fs, character);
            fs.Close();



            _data = SerializeObject(character);
            CreateXml(_FileName);
        
    }

    public void CreateXml(string charName)
    {

        StreamWriter writer;
        FileInfo t = new FileInfo(Application.dataPath + "/Characters" + "\\" + charName);


        if (!t.Exists)
        {
            writer = t.CreateText();

        }
        else
        {
           
            writer = t.CreateText();
        }
        writer.Write(_data);
        writer.Close();
        Debug.Log("File Written");

      
    }
    private string SerializeObject(CharacterInfo characterCreate)
    {
        string XmlizedString = null;
        MemoryStream memory = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(CharacterInfo));
        
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memory, Encoding.UTF8);
        xs.Serialize(memory, characterCreate);
        memory = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memory.ToArray());
        return XmlizedString;
    }

    private string UTF8ByteArrayToString(byte[] v)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(v);
        return (constructedString);
    }
}
