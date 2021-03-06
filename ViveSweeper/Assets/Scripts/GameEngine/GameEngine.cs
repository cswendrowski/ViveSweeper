﻿using UnityEngine;
using System.Collections;
using Assets.Scripts.World;
using Assets.Scripts.World.GridWorld;

public class GameEngine : MonoBehaviour
{

    //static Player player;
    private static GridWorld World { get; set; }

    [SerializeField] private GameObject MinePrefab;

    // Use this for initialization
    void Start()
    {
        WorldConstants.LoadObjects();

        WorldConstants.MinePrefab = MinePrefab;
    }

    public void NewGame()
    {
        //WorldConstants.CurrentDifficulty = difficulty;

        switch (WorldConstants.CurrentDifficulty)
        {
            case WorldConstants.Difficulties.Medium:
                World = new GridWorld(16);
                break;
            case WorldConstants.Difficulties.Expert:
                World = new GridWorld(21);
                break;
            case WorldConstants.Difficulties.Easy:
                World = new GridWorld(9);
                break;
            default:
                World = new GridWorld(9);
                break;
        }

        WorldConstants.World = World;
    }

    public static void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
