using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    static public NoteManager instance;
    public Transform noteSpawnerTransform;
    Dictionary<KeyCode, NoteSpawner> spawners = new Dictionary<KeyCode, NoteSpawner>();
    public Queue<NoteData> queue = new Queue<NoteData>();

    private void Awake()
    {
        instance = this;
        noteSpawnerTransform = transform.Find("NoteSpawners");
        NoteSpawner[] tmpSpawners = noteSpawnerTransform.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spawners.Add(spawner.keyCode, spawner);
        }
        SetDataQueue(SongSelector.instance.songData.notes);
    }
    public void SetDataQueue(List<NoteData> notes)
    {
        // ���ٽ� ǥ��
        // �ݷ����� ��� �� ���� �Ķ���ͷ� �޾Ƽ� �켱���� ������ �����ϰ� ������ �ٲ�.
        notes.Sort((x, y) => x.time.CompareTo(y.time));
        foreach (NoteData note in notes)
            queue.Enqueue(note);
    }
    public void StartSpawn()
    {
        if(queue.Count > 0)
            StartCoroutine(E_SpawnNotes());
    }
    IEnumerable E_SpawnNotes()
    {
        while (queue.Count > 0)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.Peek().time < GamePlay.instance.playTime)
                {
                    NoteData data = queue.Dequeue();
                    spawners[data.keyCode].SpawnNote();
                }
                else
                    break;
            }
            yield return null;
        }
    }
}
