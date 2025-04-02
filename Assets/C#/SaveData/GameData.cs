using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class GameData 
{
   [SerializeField] List<PlayerData> _players;
   [SerializeField] List<WorlData> _worlData;

    public List<PlayerData> Plyrs { get => _players; set => _players = value; }
    public List<WorlData> WrlDt { get => _worlData; set => _worlData = value; }
}
