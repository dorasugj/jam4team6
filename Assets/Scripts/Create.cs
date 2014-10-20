using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {

	public GameObject SpritePrefab;
	private int Flag;
	private float Scale; 
	private GameObject ObjSp;
	private int Count;
	private bool bFlag;
	private Touch[] touch = new Touch[5];

	// Use this for initialization
	void Start () {
		Flag = 0;
		bFlag = false;
		Scale = 0.0f;
		Count = 160;
	}
	
	// Update is called once per frame
	void Update () {
		if (Flag == 0) {
			if (Input.GetKeyDown (KeyCode.Z) && Input.GetKeyDown (KeyCode.M)) {

				Destroy(ObjSp);
				ObjSp = (GameObject)Instantiate (SpritePrefab, transform.position, transform.rotation);
				//Vector3 Vec = Input.mousePosition;

				ObjSp.transform.position = Vector3.zero;

				Flag = 1;
				bFlag = false;
			}
			/*if(Input.GetMouseButtonDown(0))
			{
				Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
				Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, TapPoint.z));

				Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
				Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);

				if(aCollider2d)
				{
					RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
					if(hitObject.collider.gameObject.name == "RightThouch")
					{
						Destroy(ObjSp);
						ObjSp = (GameObject)Instantiate (SpritePrefab, transform.position, transform.rotation);
						
						ObjSp.transform.position = Vector3.zero;
						
						Flag = 1;
						bFlag = true;
						//Debug.Log(hitObject.collider.gameObject.name);
					}
				}
			}*/
			for(int i = 0; i < Input.touchCount; i++)
			{
				touch[i] = Input.GetTouch(i);
			}
			if(touch[0].phase == TouchPhase.Began && touch[1].phase == TouchPhase.Began)
			{
				Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
				Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(touch[0].position.x, touch[0].position.y, TapPoint.z));
				
				Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
				Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);

				Vector3 TapPoint2 = Camera.main.WorldToScreenPoint(gameObject.transform.position);
				Vector3 newVector2 = Camera.main.ScreenToWorldPoint(new Vector3(touch[1].position.x, touch[1].position.y, TapPoint2.z));

				Vector2 HitPoint2 = new Vector2(newVector2.x, newVector2.y);
				Collider2D aCollider2d2 = Physics2D.OverlapPoint(HitPoint2);
				
				if(aCollider2d && aCollider2d2)
				{
					RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
					RaycastHit2D hitObject2 = Physics2D.Raycast(HitPoint2, -Vector2.up);
					if( (hitObject.collider.gameObject.name == "RightThouch" && hitObject2.collider.gameObject.name == "LefhThouch") ||
					   (hitObject2.collider.gameObject.name == "RightThouch" && hitObject.collider.gameObject.name == "LefhThouch"))
					{
						Destroy(ObjSp);
						ObjSp = (GameObject)Instantiate (SpritePrefab, transform.position, transform.rotation);
						
						ObjSp.transform.position = Vector3.zero;
						
						Flag = 1;
						bFlag = true;
						//Debug.Log(hitObject.collider.gameObject.name);
					}
				}
			}
		} else if(Flag >= 1) {
			if(!bFlag)
			{
				if(Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.M))
				{
					Scale += 0.01f;
					ObjSp.transform.localScale = new Vector3(0.1f + Scale, 0.1f + Scale, 1.0f);
					Count--;
				}
				if(Input.GetKeyUp(KeyCode.Z) && Input.GetKeyUp(KeyCode.M))
				{
					//Destroy(ObjSp);
					Flag++;
					//Scale = 0.0f;
				}
				if( Flag > 1 || !Input.GetKey(KeyCode.Z) || !Input.GetKey(KeyCode.M))
				{
					Scale = 0.0f;
					Flag = 0;
					//Debug.Log(Count);

					if(Count <= 5 && Count >= -5)
					{
						LoadLevel("Ok");
					}
					else
					{
						LoadLevel("Ng");
					}

					Count = 160;
				}
			}
			else
			{

				/*if(Input.GetMouseButton(0))
				{
					Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, TapPoint.z));
					
					Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
					Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);
					
					if(aCollider2d)
					{
						RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
						if(hitObject.collider.gameObject.name == "RightThouch")
						{
							Scale += 0.01f;
							ObjSp.transform.localScale = new Vector3(0.1f + Scale, 0.1f + Scale, 1.0f);
							Count--;
						}
						else{
							Scale = 0.0f;
							Flag = 0;
							//Debug.Log(Count);
							
							if(Count <= 5 && Count >= -5)
							{
								LoadLevel("Ok");
							}
							else
							{
								LoadLevel("Ng");
							}
							
							Count = 160;
						}
					}
				}
				if(Input.GetMouseButtonUp(0))
				{
					Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, TapPoint.z));
					
					Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
					Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);
					
					if(aCollider2d)
					{
						RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
						if(hitObject.collider.gameObject.name == "RightThouch")
						{
							Scale = 0.0f;
							Flag = 0;
							//Debug.Log(Count);
							
							if(Count <= 5 && Count >= -5)
							{
								LoadLevel("Ok");
							}
							else
							{
								LoadLevel("Ng");
							}
							
							Count = 160;
						}
					}
				}*/

				for(int i = 0; i < Input.touchCount; i++)
				{
					touch[i] = Input.GetTouch(i);
				}
				if(touch[0].phase == TouchPhase.Stationary && touch[1].phase == TouchPhase.Stationary)
				{
					Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(touch[0].position.x, touch[0].position.y, TapPoint.z));
					
					Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
					Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);
					
					Vector3 TapPoint2 = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector2 = Camera.main.ScreenToWorldPoint(new Vector3(touch[1].position.x, touch[1].position.y, TapPoint2.z));
					
					Vector2 HitPoint2 = new Vector2(newVector2.x, newVector2.y);
					Collider2D aCollider2d2 = Physics2D.OverlapPoint(HitPoint2);
					
					if(aCollider2d && aCollider2d2)
					{
						RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
						RaycastHit2D hitObject2 = Physics2D.Raycast(HitPoint2, -Vector2.up);
						if( (hitObject.collider.gameObject.name == "RightThouch" && hitObject2.collider.gameObject.name == "LefhThouch") ||
						   (hitObject2.collider.gameObject.name == "RightThouch" && hitObject.collider.gameObject.name == "LefhThouch"))
						{
							Scale += 0.01f;
							ObjSp.transform.localScale = new Vector3(0.1f + Scale, 0.1f + Scale, 1.0f);
							Count--;
						}
						else{
							Scale = 0.0f;
							Flag = 0;
							//Debug.Log(Count);
							
							if(Count <= 5 && Count >= -5)
							{
								LoadLevel("Ok");
							}
							else
							{
								LoadLevel("Ng");
							}
							
							Count = 160;
						}
					}
				}
				if(touch[0].phase == TouchPhase.Ended  && touch[1].phase == TouchPhase.Ended)
				{
					Vector3 TapPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(touch[0].position.x, touch[0].position.y, TapPoint.z));
					
					Vector2 HitPoint = new Vector2(newVector.x, newVector.y);
					Collider2D aCollider2d = Physics2D.OverlapPoint(HitPoint);
					
					Vector3 TapPoint2 = Camera.main.WorldToScreenPoint(gameObject.transform.position);
					Vector3 newVector2 = Camera.main.ScreenToWorldPoint(new Vector3(touch[1].position.x, touch[1].position.y, TapPoint2.z));
					
					Vector2 HitPoint2 = new Vector2(newVector2.x, newVector2.y);
					Collider2D aCollider2d2 = Physics2D.OverlapPoint(HitPoint2);
					
					if(aCollider2d && aCollider2d2)
					{
						RaycastHit2D hitObject = Physics2D.Raycast(HitPoint, -Vector2.up);
						RaycastHit2D hitObject2 = Physics2D.Raycast(HitPoint2, -Vector2.up);
						if( (hitObject.collider.gameObject.name == "RightThouch" && hitObject2.collider.gameObject.name == "LefhThouch") ||
						   (hitObject2.collider.gameObject.name == "RightThouch" && hitObject.collider.gameObject.name == "LefhThouch"))
						{
							Scale = 0.0f;
							Flag = 0;
							//Debug.Log(Count);
							
							if(Count <= 5 && Count >= -5)
							{
								LoadLevel("Ok");
							}
							else
							{
								LoadLevel("Ng");
							}
							
							Count = 160;
						}
					}
				}
			}
		}
	}

	void LoadLevel(string name)
	{
		float time = 1;

		FadeCamera.Instance.FadeOut(time, () => 
		                            {
										Application.LoadLevel(name);
										FadeCamera.Instance.FadeIn(time,() => {

			});
		});
	}
}
