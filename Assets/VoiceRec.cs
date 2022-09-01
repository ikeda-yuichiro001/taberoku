using UnityEngine.Windows.Speech;
public delegate void Rec(string a);

public static class VoiceRec
{ 
    static KeywordRecognizer kr;
    public static int MicroPhoneCount => UnityEngine.Microphone.devices.Length;

    public static void INIT(Rec r , params string[] words)
    {
        if (kr != null)
        {
            if(kr.IsRunning) kr.Stop();
            kr.Dispose();
            kr = null;
        } 
        kr = new KeywordRecognizer(words);
        kr.OnPhraseRecognized += delegate (PhraseRecognizedEventArgs a) { r?.Invoke(a.text); };
        kr.Start(); 
    } 
}
