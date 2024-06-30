using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float perBoarderThickness = 10f;
    public float scrollspeed=5f;
    public float miny=10f;
    public float maxy=80f;
    void Update()
    {
        gamemanager.Gameover = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") )
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") )
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") )
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") )
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll= Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos=transform.position;
        pos.y-=scroll * scrollspeed * Time.deltaTime;
        pos.y=Mathf.Clamp(pos.y,miny,maxy);
        transform.position=pos;
    }
}

