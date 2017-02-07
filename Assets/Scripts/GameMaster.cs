using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject RedGem;
    public GameObject BlueGem;
    public GameObject YellowGem;
    public GameObject GreenGem;
    public GameObject PinkGem;
    public static float newGemX;
    public static bool destructionSemaphore;

	// Use this for initialization
	void Start () {
        destructionSemaphore = false;
        newGemX = 0.1f;
        for (int numCols = 0; numCols < 12; numCols++) {
            for (int numRows = 0; numRows < 12; numRows++) {
                int random = Random.Range(1, 6);
                if(random == 1){
                    Instantiate(BlueGem, new Vector3((float)(-4.4 + numCols * 0.8), (float)(-4.4 + numRows * 0.8)), new Quaternion());
                }
                if (random == 2){
                    Instantiate(RedGem, new Vector3((float)(-4.4 + numCols * 0.8), (float)(-4.4 + numRows * 0.8)), new Quaternion());
                }
                if (random == 3){
                    Instantiate(GreenGem, new Vector3((float)(-4.4 + numCols * 0.8), (float)(-4.4 + numRows * 0.8)), new Quaternion());
                }
                if (random == 4){
                    Instantiate(YellowGem, new Vector3((float)(-4.4 + numCols * 0.8), (float)(-4.4 + numRows * 0.8)), new Quaternion());
                }
                if (random > 4){
                    Instantiate(PinkGem, new Vector3((float)(-4.4 + numCols * 0.8), (float)(-4.4 + numRows * 0.8)), new Quaternion());
                }
            }
        }
	}

    static public IEnumerator destroyingBlock()
    {
        Debug.Log("destroyingBlock() Start");
        yield return new WaitForSeconds(1f);
        GameMaster.destructionSemaphore = false;
        Debug.Log("destroyingBlock() End");

    }

    // Update is called once per frame
    void Update () {
        if (newGemX != 0.1f) {
            StartCoroutine(destroyingBlock());
            int random = Random.Range(1, 6);
            if (random == 1)
            {
                Instantiate(BlueGem, new Vector3(newGemX, (float)(4.4)), new Quaternion());
            }
            if (random == 2)
            {
                Instantiate(RedGem, new Vector3(newGemX, (float)(4.4)), new Quaternion());
            }
            if (random == 3)
            {
                Instantiate(YellowGem, new Vector3(newGemX, (float)(4.4)), new Quaternion());
            }
            if (random == 4)
            {
                Instantiate(GreenGem, new Vector3(newGemX, (float)(4.4)), new Quaternion());
            }
            if (random > 4)
            {
                Instantiate(PinkGem, new Vector3(newGemX, (float)(4.4)), new Quaternion());
            }
            newGemX = 0.1f;
        }
	}
}
