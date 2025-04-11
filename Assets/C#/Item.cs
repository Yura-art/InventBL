using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _id;

    public int Id { get => _id; set => _id = value; }

    public void Use()
    {

    }
}
