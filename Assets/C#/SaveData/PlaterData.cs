using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData 
{
    public enum PlayerStateEnum
    {
        Small,
        Big,
        Tall,
        Flower,
        Frog

    }

    [SerializeField] int _lifes;
    [SerializeField] int _score;
    [SerializeField] int _coins;
    [SerializeField] List<int> _items;
    [SerializeField] PlayerStateEnum _playerState;

    

    public int Lfs { get => _lifes; set => _lifes = value; }
    public int Scr { get => _score; set => _score = value; }
    public int Cns { get => _coins; set => _coins = value; }
    public List<int> tms { get => _items; set => _items = value; }
    public PlayerStateEnum PlyrStt { get => _playerState; set => _playerState = value; }
}
