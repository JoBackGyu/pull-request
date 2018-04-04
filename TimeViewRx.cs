using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeViewRx : MonoBehaviour {


	[SerializeField] private TimeCounterRx timeCounter;
	[SerializeField] private Text counterText;

	// Use this for initialization
	void Start ()
	{
			timeCounter.OnTimeChanged.Subscribe(time =>
			{
				counterText.text = time.ToString();
			});

		Subject<string> subject = new Subject<string>();

		subject
			.Select(str => int.Parse(str)) 
			.Subscribe(
				x => Debug.Log("成功:"+x),
				ex =>Debug.Log("例外が発生:"+ex)
			);
		
		subject.OnNext("1");
		subject.OnNext("2");
		subject.OnCompleted();

	}
}
