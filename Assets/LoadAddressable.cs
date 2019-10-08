using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAddressable : MonoBehaviour
{
    [SerializeField] private List<AssetReference> assetReferences;
    // Start is called before the first frame update

    private readonly Dictionary<AssetReference, AsyncOperationHandle<GameObject>> asyncOperationHandles = new Dictionary<AssetReference, AsyncOperationHandle<GameObject>>();
    
    private void Spawn()
    {
        var assetRef = assetReferences[0];
        if (assetRef.RuntimeKeyIsValid() == false)
        {
            throw new InvalidKeyException("You have an invalid asset ref key" + assetRef.RuntimeKey);
            
        }

        if (asyncOperationHandles.ContainsKey(assetRef))
        {
            if (asyncOperationHandles[assetRef].IsDone)
            {
                SpawnFromLoadedRef(assetRef, Vector3.zero);
            }
        }

        LoadAndSpawn(assetRef);
    }

    private void LoadAndSpawn(AssetReference assetRef)
    {
        var op = Addressables.LoadAssetAsync<GameObject>(assetRef);
      
    }

    private void SpawnFromLoadedRef(AssetReference assetRef, Vector3 zero)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
