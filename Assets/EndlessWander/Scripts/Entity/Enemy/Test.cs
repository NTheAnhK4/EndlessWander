
using UnityEngine;
using UnityEngine.AddressableAssets;
public class Test : MonoBehaviour
{
    [SerializeField] private AssetLabelReference obj;

    protected void Reset()
    {
        obj = new AssetLabelReference();
    }

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
        var handle = Addressables.LoadAssetAsync<GameObject>(obj);
        handle.Completed += (task =>
        {
            PoolingManager.Spawn(task.Result,this.transform);
        });
    }
}
