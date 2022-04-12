using UnityEngine;

public class StorageResourses : MonoBehaviour
{
    [SerializeField] private GameObject _fristResourses;
    [SerializeField] private TextMesh _info;

    [SerializeField, Range(0, 1f)] float _correctSizeX;
    [SerializeField, Range(0, 1f)] float _correctSizeY;
    public void SetVolume(byte volume)
    {
        var correct = 0.1f * volume; // all size on Y == 1, capacity == 10  10*0.1 = 1; 1== max Y
       _fristResourses.transform.localScale = new Vector3(_correctSizeX, correct, _correctSizeY);
    }
    public void Message(string mes)
    {
        if (mes == string.Empty)
            _info.gameObject.SetActive(false);
        else
        {
            _info.gameObject.SetActive(true);
            _info.text = mes;
        }
    }
}
