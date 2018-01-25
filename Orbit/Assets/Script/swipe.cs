using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour {


	public float speed = 5f;
	public GameObject pivot;
	public bool isCurrentlyMoving;
	

	public float minSwipeDistY;
	public float minSwipeDistX;

	private Vector2 startPos;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    void Update(){
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			switch (touch.phase) {	
			case TouchPhase.Began:
				startPos = touch.position;
				break;
			case TouchPhase.Ended:
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX){
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					if (swipeValue > 0 && !isCurrentlyMoving){
						isCurrentlyMoving = true;
						StartCoroutine( SwipeRight());
					}else if (swipeValue < 0 && !isCurrentlyMoving){
						isCurrentlyMoving = true;
						StartCoroutine( SwipeLeft());
					}
				}
				break;
			}
		}

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(!isCurrentlyMoving){
				isCurrentlyMoving = true;
				StartCoroutine( SwipeRight());
			}
		}else if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(!isCurrentlyMoving){
				isCurrentlyMoving = true;
				StartCoroutine( SwipeLeft());
			}
		}
	}

	IEnumerator SwipeRight(){
		if (!(pivot.transform.localPosition.x >= 0f)) {
			Vector2 pos = pivot.transform.localPosition;
			float xTarget = pivot.transform.localPosition.x + 475;
			while (pivot.transform.localPosition.x < xTarget) {
				pos.x += speed;
				pivot.transform.localPosition = pos;
				yield return null;
			}
			pivot.transform.localPosition = pos;
		}
		isCurrentlyMoving = false;
	}

	IEnumerator SwipeLeft(){
		if (!(pivot.transform.localPosition.x <= -800f)) {
			Vector2 pos = pivot.transform.localPosition;
			float xTarget = pivot.transform.localPosition.x - 475;
			while (pivot.transform.localPosition.x > xTarget) {
				pos.x -= speed;
				pivot.transform.localPosition = pos;
				yield return null;
			}
			pivot.transform.localPosition = pos;
		}
		isCurrentlyMoving = false;
	}


}

