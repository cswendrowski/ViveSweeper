﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.World.GridWorld
{
    public class MineCoroutine : MonoBehaviour
    {
        [SerializeField]
        private int _frameDelay;

        [SerializeField]
        private GameObject _explosionPrefab;

        [SerializeField]
        private GameObject _explosionSoundsPrefab;

        public void StartExplosion(GridSpace space)
        {
            var spaceTransform = space.GetTransform().localPosition;

            Instantiate(
                WorldConstants.MinePrefab,
                new Vector3(spaceTransform.x, spaceTransform.y, spaceTransform.z),
                Quaternion.identity);

            StartCoroutine(Explosion(spaceTransform));
        }

        public IEnumerator Explosion(Vector3 location)
        {
            for (var i = 0; i < _frameDelay; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            Instantiate(
                _explosionPrefab,
                location,
                Quaternion.identity);

            Instantiate(
                _explosionSoundsPrefab,
                location,
                Quaternion.identity);
        }
    }
}
