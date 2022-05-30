using UnityEngine;
using System.Collections.Generic;
public class SongData
{
    public string videoName;
    public List<NoteData> notes;

    public SongData()
    {
        notes = new List<NoteData>();
    }
}
