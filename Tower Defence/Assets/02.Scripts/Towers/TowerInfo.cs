using UnityEngine;

[CreateAssetMenu(fileName = "New TowerInfo", menuName ="Tower/Create New Tower")]
public class TowerInfo : ScriptableObject
{
    public TowerType type;
    public int level;
    public int price;
}

public enum TowerType
{
    Turret,
    Missile,
    Laser,
}
