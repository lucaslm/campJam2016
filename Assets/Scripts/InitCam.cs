using UnityEngine;
using System.Collections;

public class InitCam : MonoBehaviour {

    public GameObject player;
    public GameObject background;

    // Use this for initialization
    void Start () {

        Vector3 pos;
        SpriteRenderer renderer;
        float height = Camera.main.orthographicSize * 2.0f;
        float width  = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

        GameObject top       = gameObject.transform.FindChild("Up").gameObject;
        GameObject bottom    = gameObject.transform.FindChild("Down").gameObject;
        GameObject right     = gameObject.transform.FindChild("Right").gameObject;
        GameObject left      = gameObject.transform.FindChild("Left").gameObject;
        GameObject destroyer = gameObject.transform.FindChild("DestroyThiguis").gameObject;

        // Positioning and sizing relative to the Camera (ie, resolution)

        renderer = background.GetComponent<SpriteRenderer>();
        background.transform.localScale = new Vector3(width, height, 1);

        renderer = top.GetComponent<SpriteRenderer>();
        pos = new Vector3(Screen.width / 2, Screen.height, 1);
        top.transform.position   = Camera.main.ScreenToWorldPoint(pos);
        top.transform.localScale = new Vector3(width, 2, 1);
        top.transform.position  += new Vector3(0, renderer.bounds.extents.y, 0);

        renderer = bottom.GetComponent<SpriteRenderer>();
        pos = new Vector3(Screen.width / 2, 0, 1);
        bottom.transform.position   = Camera.main.ScreenToWorldPoint(pos);
        bottom.transform.localScale = new Vector3(width, 2, 1);
        bottom.transform.position  += new Vector3(0, -renderer.bounds.extents.y, 0);

        renderer = left.GetComponent<SpriteRenderer>();
        pos = new Vector3(0, Screen.height / 2, 1);
        left.transform.position   = Camera.main.ScreenToWorldPoint(pos);
        left.transform.localScale = new Vector3(2, height, 1);
        left.transform.position  += new Vector3(-renderer.bounds.extents.x, 0, 0);

        renderer = right.GetComponent<SpriteRenderer>();
        pos = new Vector3(Screen.width, Screen.height / 2, 1);
        right.transform.position   = Camera.main.ScreenToWorldPoint(pos);
        right.transform.localScale = new Vector3(2, height, 1);
        right.transform.position  += new Vector3(renderer.bounds.extents.x, 0, 0);

        renderer = destroyer.GetComponent<SpriteRenderer>();
        destroyer.transform.localScale = left.transform.localScale;
        destroyer.transform.position   = left.transform.position + new Vector3(-2.5f,0,0);

        renderer = player.GetComponent<SpriteRenderer>();
        pos = new Vector3(0, Screen.height/2, 1);
        player.transform.position = Camera.main.ScreenToWorldPoint(pos);
        player.transform.position += new Vector3(renderer.bounds.extents.x, 0, 0);


    }
}
