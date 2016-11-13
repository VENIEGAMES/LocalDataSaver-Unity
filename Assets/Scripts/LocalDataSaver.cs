using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Text;

public static class LocalDataSaver
{   
	private static string SavePath = Application.persistentDataPath + "/LocalData/";

	public static void Save<T>(T serializableObject) where T : new()
	{
		if(!Directory.Exists(SavePath)){
			Directory.CreateDirectory(SavePath);
		}
		string json = JsonUtility.ToJson(serializableObject);
		File.WriteAllText(GetSaveDataPath<T>(), json);
	}

	public static T Load<T>() where T : new()
	{
		T deserializedObject = new T();
		if (File.Exists (SavePath + (new T()).GetType().FullName)) {
			try
			{
				deserializedObject = JsonUtility.FromJson<T>(File.ReadAllText(GetSaveDataPath<T>()));
			}
			catch
			{
				Debug.Log(string.Format("{0}の定義が変更された可能性があるため読み込めませんでした。", (GetSaveDataPath<T>())));
			}
		}
		return deserializedObject;
	}

	public static void Delete<T>() where T : new()
	{
		File.Delete(GetSaveDataPath<T>());
	}

	private static string GetSaveDataPath<T>() where T : new()
	{
		return SavePath + (new T()).GetType().FullName;
	}
}
