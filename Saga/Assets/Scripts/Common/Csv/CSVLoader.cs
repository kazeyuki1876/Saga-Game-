using UnityEngine;
using System.IO;


public class CSVLoader : MonoBehaviour
{
    public string line;
    public string[] values;
    int i;
    [SerializeField]
    private  string[]Name= new string[5];
    [SerializeField]
    private int[] HP = new int[5];
    [SerializeField]
     private int[] ATK = new int[5];
    [SerializeField]
    private int[] DEF = new int[5];
    public int Num=0;
    void Start()
    {
        TextAsset csv = Resources.Load("CsvFolder/TextCsvData") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)  
        {
           
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            Num++;
        //  Debug.Log(values[0] + values[1] + values[2] + values[3]);
            if (Num>1) {
                Name[Num - 2] = values[0];

                HP[Num - 2] = int.Parse(values[1]);
                ATK[Num - 2] = int.Parse(values[2]);
                DEF[Num - 2] = int.Parse(values[3]);
    //   Debug.Log(Name[Num - 1] + HP[Num - 1] + ATK[Num - 1] + DEF[Num - 1]);
            }
            int B = Num-1;
         //   Debug.Log(values[0] + values[1] + values[2] + values[3]);
            if (Num - 2>=0) {
          //   Debug.Log("Num" + Num + "" + "Name" + Name[Num - 2] + "HP" + HP[Num - 2] + "ATK" + ATK[Num - 2] + "DEF" + DEF[Num - 2]);
            }
           
            //  Debug.Log(csv.name);



         }
    
    }
}