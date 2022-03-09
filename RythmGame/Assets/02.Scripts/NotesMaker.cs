using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;
//using Newtonsoft; 나중에 복잡한 거 할 때 제이슨유틸리티 말고 이거쓰면 좋음
public class NotesMaker : MonoBehaviour
{
    SongData songData;
    KeyCode[] keyCodes = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.L };
    public VideoPlayer vp;

    public bool onRecord
    {
        set
        {
            if (value)
                StartRecording();
            else
                StopRecording();
        }
        get { return vp.isPlaying; }
    }
    private void Update()
    {
        if(onRecord)
            Recording();
    }
    private void StartRecording()
    {
        songData = new SongData();
        songData.videoName = vp.clip.name;
        vp.Play();
        Debug.Log("Start recording");
    }
    public void Recording()
    {
        foreach(KeyCode keyCode in keyCodes)
        {
            if(Input.GetKeyDown(keyCode))
            {
                if (Input.GetKeyDown(keyCode))
                    CreateNoteData(keyCode);
                //Create Note Data with keyCode.
            }
        }
       if(Input.GetKey(KeyCode.Insert))
        {
            //save song data.
            SaveSongData();
        }
    }
    private void StopRecording()
    {
        songData = null;
        vp.Stop();
    }
    private void CreateNoteData(KeyCode keyCode)
    {
        NoteData noteData = new NoteData();
        //float roundedTime = (float)Math.Round(vp.time, 2);

        float tmpTime = (float)vp.time * 1000;
        if(tmpTime % 10 < 5)
        {
            tmpTime = tmpTime /= 10;
        }
        else
        {
            tmpTime /= 10;
            tmpTime++;
        }

        int tmpTimeInt = (int)tmpTime;
        float roundedTime = (float)tmpTime/100;

        noteData.time = roundedTime;
        noteData.keyCode = keyCode;
        songData.notes.Add(noteData);
        Debug.Log(songData);

    }
    private void SaveSongData()
    {
        Debug.Log("Save SongData2");
        //panel만 띄우고 선택지 디렉토리 문자열 반환(저장하지 않음)
        string dir = EditorUtility.SaveFilePanel("저장할 곳을 지정하세요", "", $"{songData.videoName}", "json");
        //실제 song data를 json 포맷으로 저장
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }
}
