using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SwapIsland : MonoBehaviour {
	
	public int currentStage ;
	public float speed = 1f;
	bool isCurrentlyMoving;
	float rotDelta = 180f;
	float startRot =180f;

	public float minSwipeDistY;
	public float minSwipeDistX;
	string [] levels = {"","Metro Green","Metro Sand","Metro Chipelago"};
	public GameObject [] islands;
	private Vector2 startPos;

	public Text islandName;

	[Header("TRANSITION PROPS:")]
	public CanvasGroup cG_clouds;
	public GameObject earth;
	public CanvasGroup cG_tittle;
	public CanvasGroup cG_islandName;

	[Header("TITTLE PROPS:")]
	float earthPosYSelectLevel = -325f; 

	[Header("SELECT LEVEL PROPS:")]
	float earthPosYTittle = -451f;

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

	IEnumerator SwipeLeft(){
		if(currentStage < levels.Length -1){
			StartCoroutine(CheckTransition(currentStage,"Increasing"));
			currentStage++;
			islandName.text = levels[currentStage];
			ActivateNecessaryIsland();
			float time = 0;
			while(time < 0.5f){
				time += Time.deltaTime/speed;
				earth.transform.localRotation = Quaternion.Lerp (earth.transform.localRotation, Quaternion.Euler(0f,0f,rotDelta*(currentStage+1)-1f), time);
				yield return null;
			}

			earth.transform.localRotation = Quaternion.Euler(0f,0f,rotDelta*(currentStage+1));

			islands[currentStage-1].SetActive(false);
		}
		isCurrentlyMoving = false;
	}

	IEnumerator SwipeRight(){
		if(currentStage > 0){
			StartCoroutine(CheckTransition(currentStage,"Decreasing"));
			currentStage--;
			islandName.text = levels[currentStage];
			ActivateNecessaryIsland();
			float time = 0;
			while(time < 0.5f){
				time += Time.deltaTime/speed;
				earth.transform.localRotation = Quaternion.Lerp (earth.transform.localRotation, Quaternion.Euler(0f,0f,rotDelta*(currentStage+1)+1f), time);
				yield return null;
			}

			earth.transform.localRotation = Quaternion.Euler(0f,0f,rotDelta*(currentStage+1));

			islands[currentStage+1].SetActive(false);
		}
		isCurrentlyMoving = false;
	}

	void ActivateNecessaryIsland(){
		islands[currentStage].SetActive(true);
	}

	IEnumerator CheckTransition(int _currentStage,string _action){
		float time = 0;

		if(_currentStage == 1 && _action == "Decreasing"){
			while(time < 0.5f){
				time += Time.deltaTime/(speed/1.5f);
				cG_clouds.alpha = Mathf.Lerp(cG_clouds.alpha,0f,time);
				cG_tittle.alpha = Mathf.Lerp(cG_tittle.alpha,1f,time);
				cG_islandName.alpha = 0f;
				earth.transform.localPosition = Vector2.Lerp(earth.transform.localPosition,new Vector2(earth.transform.localPosition.x, earthPosYTittle),time);
				yield return null;
			}
		}else if(_currentStage == 0 && _action == "Increasing"){
			while(time < 0.5f){
				time += Time.deltaTime/(speed/1.5f);
				cG_clouds.alpha = Mathf.Lerp(cG_clouds.alpha,1f,time);
				cG_tittle.alpha = 0f;
				cG_islandName.alpha = Mathf.Lerp(cG_islandName.alpha,1f,time);
				earth.transform.localPosition = Vector2.Lerp(earth.transform.localPosition,new Vector2(earth.transform.localPosition.x, earthPosYSelectLevel),time);
				yield return null;
			}
		}

		yield return null;
	}
}
