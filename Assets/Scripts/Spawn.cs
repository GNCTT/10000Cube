using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject cubPrefab;
    [SerializeField] private float distance = 0.2f;
    [SerializeField] private Transform[] parentTransforms;

    private void Start()
    {
        SpawnCube();
    }

    private void SpawnCube()
    {
        int index = 0;
        int sizeArr = parentTransforms.Length;
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                index = (i % 2) == 0 ? (100 * i + j) : (100 * i - j);
                var pos = new Vector3(i * distance, 0f, j * distance);
                var cub = Instantiate(cubPrefab, pos, Quaternion.identity);
                cub.transform.parent = parentTransforms[index % sizeArr];
            }
        }
    }

    private void Update()
    {
        var time = Time.time;
        for (int i = 0; i < parentTransforms.Length; i++)
        {
            Transform trans = parentTransforms[i];
            var frequence = 2f;
            var ampitude = distance;
            float randomPhase = 1f / (Random.Range(1, 10));
            float newY = Mathf.Sin(time * frequence + randomPhase) * ampitude;
            trans.position = new Vector3(trans.position.x, newY, trans.position.z);
        }
    }

}
