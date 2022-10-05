using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA_ : MonoBehaviour
{
    public static readonly DATA_<Question> questionData = new DATA_<Question>("question");
    public static readonly DATA_<Penalty> penaltyData = new DATA_<Penalty>("penalty");
    public static readonly DATA_<Penalty> winner = new DATA_<Penalty>("winner");

    [RuntimeInitializeOnLoadMethod]
    static void INIT()
    {
        questionData.Load();
        penaltyData.Load();
        winner.Load();
    }
}




public static class OPTION
{
    public static bool useDevice;
    public static float bgm       { get => b;  set => b = value > 001 ? 001 : (value < 0 ? 0 : value); }
    public static float se        { get => s;  set => s = value > 001 ? 001 : (value < 0 ? 0 : value); }
    public static int menberLen { get => m;  set => m = value > 100 ? 100 : (value < 0 ? 0 : value); }
    public static int time      { get => t;  set => t = value > 90 ? 90 : (value < 10 ? 10 : value); }
    public static int response  { get => r;  set => r = value > 300 ? 300 : (value < 10 ? 10 : value); }
    static float b = 0.1f, s = 0.1f;
    static int m = 5, r = 150, t = 30;

    public static void Save() =>
        DATA__.DATAIO.WRITE
        (
            "option.txt",
            "BGM:"+b + "\n" + 
            "SE:" + s + "\n" + 
            "MENBER:" + m + "\n" +
            "TIME:" + t + "\n" +
            "RESPONSE:" + r + "\n" +
            "USE_DEVICE:" + t + "\n"
        );

    public static void Load()
    {
        string[] aa = DATA__.DATAIO.READ("option.txt", "1\n1\n10\n20\n").Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        useDevice = false;
        foreach (var i in aa)
        {
            string[] a_ = i.Split(':');
            switch (a_[0].ToLower().Trim())
            {
                case "bgm"      : if (a_.Length > 1) float.TryParse(a_[1], out b); break;
                case "se"       : if (a_.Length > 1) float.TryParse(a_[1], out s); break;
                case "menber"   : if (a_.Length > 1) int.TryParse(a_[1], out m); break;
                case "time"     : if (a_.Length > 1) int.TryParse(a_[1], out t); break;
                case "response" : if (a_.Length > 1) int.TryParse(a_[1], out r); break;
                case "usedevice": case "use_device": case "ebldevice": case "ebl_device": useDevice = true; break; 
                default: break;
            }
        } 
    }
}


[System.Serializable]
public class Question : DATAB
{ 
    public string text;
    public ANSWER answer;
    public string ToStr() => text.Replace("<{NEWLINE}>", "\n") + (answer == ANSWER.YES ? ":YES" : ":NO");
    public void SET(string a)
    {
        a = a.Replace("\n", "<{NEWLINE}>").Trim();
        string axa = a.Replace(" ", "").Replace("@", "");
        answer = axa.EndsWith(":YES") || axa.EndsWith(":Y") ? ANSWER.YES : ANSWER.NO;
        if(a.Contains(":"))
            text = a.Substring(0,a.LastIndexOf(':')).Trim();     
    }
    
 }


public enum ANSWER
{
    YES,
    NO
}




[System.Serializable]
public class Penalty : DATAB
{
    public string text;
    public void SET(string a) => text = a.Replace("\n", "<{NEWLINE}>");
    public string ToStr() => text.Replace("<{NEWLINE}>", "\n");
}




[System.Serializable]
public class Winner : DATAB
{
    public string name;
    public DateTime time = new DateTime();
    public string ToStr() =>
        time.Year.ToString().PadLeft(4, '0') + "," +
        time.Month.ToString().PadLeft(2, '0') + "," +
        time.Day.ToString().PadLeft(2, '0') + "," +
        time.Hour.ToString().PadLeft(2, '0') + "," +
        time.Minute.ToString().PadLeft(2, '0') + "," +
        name;

    public void SET(string a)
    {
        var aa = a.Split(',');
        int[] ay = new int[5];
        for(int y = 0; y < 5; y++)
            if (aa.Length > y) 
                int.TryParse(aa[y], out ay[y]); 
        time = new DateTime(ay[0], ay[1], ay[2], ay[3], ay[4],0);
        name = "---";
        if (aa.Length > 4)
        {
            name = ""; 
            for (int y = 5; y < aa.Length; y++)
                name += aa[y] + ","; 
        }
    }
}





 

public interface DATAB
{ 
    void SET(string a);
    string ToStr();
}


public class DATA_<T> where T : DATAB, new()
{
    string file;
    public DATA_(string a) => file = a;

    public List<T> data = new List<T>();

    public void Save()
    {
        string t = "";
        for (int i = 0; i < data.Count; i++)
            t += data[i].ToStr() + "\n";
        DATA__.DATAIO.WRITE(file + ".txt", t);
    }

    public void Load()
    {
        string[] rdat = DATA__.DATAIO.READ(file + ".txt", "").Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        T[] data = new T[rdat.Length];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = new T();
            data[i].SET(rdat[i]);
        }
    }
}




namespace DATA__
{
    using System.IO;

    public static class DATAIO
    {
        public static void WRITE(string a, string text)
        {
            if (!File.Exists(PATH + a))
                File.CreateText(PATH + a).Dispose();
            File.WriteAllText(PATH + a, text, System.Text.Encoding.Unicode);
        }

        public static string READ(string a, string _na) =>  File.Exists(PATH + a) ? File.ReadAllText(PATH + a, System.Text.Encoding.Unicode) : _na ;

        static string p = "";
        static string PATH
        {
            get
            {
                if(p == "")
                    p = (Application.isEditor ?
                         Application.dataPath.Replace("/", @"\") :
                         Directory.GetParent(Application.dataPath.Replace("/", @"\")).ToString())
                         + @"\$DATA$\";
                if (!Directory.Exists(p))
                    Directory.CreateDirectory(p);
                return p;
            }
               
        }
    }

}
