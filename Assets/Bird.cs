using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 mInitialPosition;
    Vector3 mCurrenetPosition;
    bool isBirdLucnched = false;
    float mTimeSittingAround = 0;

    [SerializeField] float mLucnhPower = 500;

    private void Awake()
    {
        mInitialPosition = transform.position;
        mCurrenetPosition = mInitialPosition;
    }
    private void Update()
    {
        mCurrenetPosition = transform.position;
        
        GetComponent<LineRenderer>().SetPosition(0, mCurrenetPosition);
        GetComponent<LineRenderer>().SetPosition(1, mInitialPosition);
        if (isBirdLucnched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            mTimeSittingAround += Time.deltaTime;
        }
        if (mCurrenetPosition.y > 20 || mCurrenetPosition.y < -20 ||
            mCurrenetPosition.x > 45 || mCurrenetPosition.x < -45 |
            mTimeSittingAround > 3)
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        //apply force to initial dirrection
        Vector3 currenetPosition = transform.position;
        Vector2 directionToInitialPosition = mInitialPosition - currenetPosition;
       
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * mLucnhPower);
        GetComponent<Rigidbody2D>().gravityScale = 1; ;
        isBirdLucnched = true;

        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Transform>().position = new Vector3(newPos.x,newPos.y,0);
    }
}
