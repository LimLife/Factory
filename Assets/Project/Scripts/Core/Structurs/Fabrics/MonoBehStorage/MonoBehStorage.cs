using UnityEngine;
public class MonoBehStorage : MonoBehaviour
{
    public StorageResourses StorageResourses => _storageResourses;
    public StorageProduct StorageProduct => _storagePrdouct;
    public ConfigStorage Config => _configStorage;

    [SerializeField] private StorageResourses _storageResourses;
    [SerializeField] private StorageProduct _storagePrdouct;
    [SerializeField] private ConfigStorage _configStorage;

}
