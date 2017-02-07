using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : MonoBehaviour {

    public string color;
    public List<GemControl> destructionList;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update () {
       if (GameMaster.destructionSemaphore == false) {
            destructionList = new List<GemControl>();
            destructionList.AddRange(checkMatches("UP"));
            destructionList.AddRange(checkMatches("DOWN"));
            destructionList.AddRange(checkMatches("LEFT"));
            destructionList.AddRange(checkMatches("RIGHT"));
            for (int i = 0; i < destructionList.Count; i++) {
                if (GameMaster.destructionSemaphore == false)
                {
                    /*
                    GameMaster.destructionSemaphore = true;
                    GameMaster.newGemX = this.transform.position.x;
                    Object.DestroyImmediate(destructionList[0].gameObject);
                    */
                }
            }
        }
    }

    public List<GemControl> checkMatches(string direction)
    {
        GemControl gemControl;
        List<GemControl> destructionList = new List<GemControl>();
        List<GemControl> temp = new List<GemControl>();
        float x, y;
        if (direction.Equals("UP"))
        {
            x = 0;
            y = 1;
        }
        else if (direction.Equals("DOWN"))
        {
            x = 0;
            y = -1;
        }
        else if (direction.Equals("LEFT"))
        {
            x = -1;
            y = 0;
        }
        else if (direction.Equals("RIGHT"))
        {
            x = 1;
            y = 0;
        }
        else {
            return null;
        }
        Vector3 extent = this.GetComponent<Collider2D>().bounds.extents;
        Vector3 center = this.GetComponent<Collider2D>().bounds.center;
        GameObject hit;
        if (Physics2D.Raycast(new Vector2(center.x + extent.x * x, center.y + extent.y * y), new Vector2(x, y)).rigidbody != null)
        {
            hit = Physics2D.Raycast(new Vector2(center.x + extent.x * x, center.y + extent.y * y), new Vector2(x, y)).rigidbody.gameObject;
            if ((gemControl = hit.GetComponent<GemControl>()) != null)
            {
                if (gemControl.color.Equals(this.color))
                {
                    Debug.Log(gemControl.color + " " + this.color + " " + (gemControl.color.Equals(this.color)));
                    destructionList.Add(gemControl);
                    /*if ((temp = gemControl.checkMatches(direction)) != null)
                    {
                        destructionList.AddRange(temp);
                        temp = null;
                    }*/
                }
            }
        }
        
        return destructionList;
    }

    void OnMouseDown() {
        if(GameMaster.destructionSemaphore == false) {
            GameMaster.destructionSemaphore = true;
            GameMaster.newGemX = this.transform.position.x;
            Object.DestroyImmediate(gameObject);
        }
    }

}
