using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Found : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SmoothMovement(Transform t, Vector2 endPosition, float duration)
    {
        float elapsed = 0F;
        Vector2 startPosition = transform.position;

        while (elapsed < duration)
            {
            Vector2 newPosition = new Vector2(t.position.x,t.position.y-1f* Time.deltaTime);
            t.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
