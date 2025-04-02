using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WorlData 
{
    [SerializeField] List<LevelData> _levels;
    [SerializeField] bool _completed;

    public List<LevelData> Lvls { get => _levels; set => _levels = value; }
    public bool Cmpltd { get => _completed; set => _completed = value; }
}
