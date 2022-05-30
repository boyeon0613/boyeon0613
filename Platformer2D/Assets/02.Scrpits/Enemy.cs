using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int _hp;
    public int hp
    {
        set
        {
            _hp = value;
            hpBar.value = _hp / hpMax;
        }
        get
        {
            return _hp;
        }
    }
    public int hpMax;

    public int damage = 2;

    public Slider hpBar;

    private void Awake()
    {
        hp = hpMax;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go == null) return;

        if(go.layer==LayerMask.NameToLayer("Player"))
        {
            Player player = go.GetComponent<Player>();
            PlayerController controller = go.GetComponent<PlayerController>();
            player.Hurt(damage);
            controller.KnockBack();
        }
    }
}
