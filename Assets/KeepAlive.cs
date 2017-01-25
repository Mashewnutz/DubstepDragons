using UnityEngine;
using System.Collections;

public class KeepAlive : MonoBehaviour {
	
	private static KeepAlive instance = null;
	public static KeepAlive Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// any other methods you need
}
