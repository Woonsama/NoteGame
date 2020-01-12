using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]

public class Tile
{
    public string area;
    public float generateTime;

    public Tile(string areaStr, float time)
    {
        area = areaStr;
        generateTime = time;
    }
}


public class Serialization<T>
{
    List<T> target;

    public List<T> ToList() { return target; }

    public Serialization(List<T> target)
    {
        this.target = target;
    }
}

public class Note : MonoBehaviour
{
    


    [SerializeField] List<Tile> tileList = new List<Tile>();

    private float time;
    private bool isTimeStart;

    void Start()
    {

    }

    void Update()
    {
        TimeCheck();

        if(Input.GetKeyDown(KeyCode.A) && isTimeStart)
        {           
            CreateTile();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            for(int i = 0; i < tileList.Count; i++)
            {
                Debug.Log(tileList[i] + "\n");
            }
        }

    }

    private void TimeCheck()
    {
        if (isTimeStart)
        {
            time += Time.deltaTime;
        }
    }
    public void StartTile()
    {
        isTimeStart = true;
    }

    public void EndTile()
    {
        isTimeStart = false;

        //Debug.Log(tileList);

        SaveTile();
    }

    public void CreateTile()
    {
        string tempData = "Area" + Random.Range(1, 5).ToString();
        Debug.Log("생성" + ":" + tempData +","  + time +"초");
        tileList.Add(new Tile(tempData,time));
    }

    public void SaveTile()
    {
        //string tileJsonData = JsonUtility.ToJson(new Serialization<Tile>(tileList));
        string tileJsonData = JsonUtility.ToJson(tileList);

        Debug.Log(tileJsonData);
        File.WriteAllText(Path.Combine(Application.dataPath, "Tile.json"), tileJsonData);
    }

    //public void LoadTile()
    //{
    //    string path = Path.Combine(Application.dataPath, "Tile.json");
    //    string data = File.ReadAllText(path);
    //    tileList = JsonUtility.FromJson<List<Tile>>(data);
    //}
}
