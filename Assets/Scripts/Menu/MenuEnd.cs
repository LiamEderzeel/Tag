using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuEnd : MonoBehaviour {

    [SerializeField] private float[,] _scores = new float[4,2];
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Image[]  _images = new Image[4];
    [SerializeField] private Sprite[] _sprites = new Sprite[4];
    [SerializeField] private MenuManager _menuManager;

	private void Start ()
    {
        for(int i = 0; i < _gameManager._scores.Count; ++i)
        {
            _scores[i,1] = i;
            _scores[i,0] = _gameManager._scores[i];
        }

        Sort( _scores );
	}

    void Sort(float[,] A)
    {
        for( int i = 0 ; i < 4 ; i++ )
            Debug.Log( A[ i, 0 ] + " | " + A[ i, 1 ] );
        float[] temp = new float[2];
        for (int i = 1; i < 4; i++)
        {
            int j = i;
            while (j > 0 && A[j-1,0] < A[j,0])
            {
                temp[0] = A[j,0];
                temp[1] = A[j,1];
                A[ j, 0 ] = A[ j - 1, 0 ];
                A[ j, 1 ] = A[ j - 1, 1 ];
                A[ j - 1,0 ] = temp[0];
                A[ j-1, 1 ] = temp[1];
                j--;
            }
        }

        for(int i = 0; i < 4; ++i)
        {
            int number = (int)(_scores[i,1]);
            _images[i].sprite = _sprites[number];
        }
    }

    private void Update ()
    {
        if(Input.GetButtonDown("B1") || Input.GetButtonDown("B2") || Input.GetButtonDown("B3") || Input.GetButtonDown("B4"))
        {
            _menuManager.SetMain();
        }
        if(Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4"))
        {
            _menuManager.Play();
        }
    }
}
