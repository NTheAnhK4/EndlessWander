using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class Test : MonoBehaviour
{
    public string linkPath;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(linkPath);
        handle.Completed += (task =>
        {
            Instantiate(task.Result);
        });
    }
}
