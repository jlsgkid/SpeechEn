/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

namespace commanastationwww.multistorydungeons{

public class Move : MonoBehaviour {

	private float speed = 7f;
	private float gravity = 300f;
	float horizontalMovement;
	float verticalMovement;
	private CharacterController character;
	private Vector3 destination = Vector3.zero;
	
	void Start()
	{		
		character = GetComponent<CharacterController>();		
	}
	
	void Update () {
		horizontalMovement = Input.GetAxis("Horizontal");
		verticalMovement = Input.GetAxis("Vertical");
		
		destination.Set(horizontalMovement, 0, verticalMovement);
        destination = transform.TransformDirection(destination);
        destination *= speed;
		
		destination.y -= gravity * Time.deltaTime;
        character.Move(destination * Time.deltaTime);		
	}
}
}
