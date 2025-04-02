using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData 
{
    [SerializeField] bool _completed;
    [SerializeField] int _playerId;

    public bool Cmpltd { get => _completed; set => _completed = value; }
    public int Plyrd { get => _playerId; set => _playerId = value; }
}
