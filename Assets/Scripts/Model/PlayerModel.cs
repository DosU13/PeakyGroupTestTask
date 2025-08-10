using System;
using System.Linq;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int PlayerMaxHP = 3;
    [NonSerialized] public int HP;
    [NonSerialized] public bool Alive = true;

    private void Awake()
    {
        HP = PlayerMaxHP;
    }

    public void Damage()
    {
        HP--;
        Alive = HP > 0;
    }

    internal void Restart()
    {
        HP = PlayerMaxHP;
        Alive = HP > 0;
    }
}
