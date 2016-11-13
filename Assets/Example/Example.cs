using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

	[SerializeField]
	PlayerData playerData;

	public void OnClickSave(){
		LocalDataSaver.Save<PlayerData>(playerData);
	}

	public void OnClickLoad(){
		playerData = LocalDataSaver.Load<PlayerData>();
	}

	public void OnClickDelete(){
		LocalDataSaver.Delete<PlayerData>();
	}
}

[System.Serializable]
public class PlayerData{
	public string name;
	public int hp;
	public int mp;
}
