using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//conePrefabを入れる
	public GameObject conePrefab;

	//スタート地点
	private int startPos = -200;
	//開始時に生成されるアイテムの生成範囲終点
	private int firstGenerateLimitPos = -140;

	//UnitychanのGameObject
	[SerializeField] private GameObject UnityChan;
	//最後にアイテム生成したZ座標
	private int lastGeneratePos; 
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	// Use this for initialization
	void Start () {
		//生成範囲にアイテムを生成
		for(int i = startPos; i < firstGenerateLimitPos; i += 15) //iはアイテムが置かれるZ軸の座標としても使われる
		{	
			lastGeneratePos = i;
			ItemGenerate();
			//Debug.Log(lastGeneratePos);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//lastGeneratePosがUnityちゃんの40ｍ手前まで来たら+15ｍの場所にアイテム生成
		if(lastGeneratePos < UnityChan.transform.position.z + 40){
			lastGeneratePos += 15;
			ItemGenerate();
			//Debug.Log(lastGeneratePos);
		}
	}

	void ItemGenerate(){
		//どのアイテムを出すのかをランダムに設定　←なぜ1から11？0から10ではだめか
		int num = Random.Range(1,11);

		if(num <= 2)　//
		{	//コーンをx軸方向に一直線に生成　(道を塞ぐ形に配置)
			for(float j = -1; j <= 1; j += 0.4f)　//-1から1まで0.4fずつ配置。つまり5つ配置される
			{
				GameObject cone = Instantiate(conePrefab) as GameObject;
				cone.transform.position = new Vector3(4 * j, cone.transform.position.y, lastGeneratePos);
			}
		}
		else
		{
			//レーンごとにアイテムを生成
			for(int j = -1; j <= 1; j++)
			{
				//アイテムの種類を決める
				int item = Random.Range(1,11);

				//アイテムを置くZ座標のオフセットをランダムに設定
				int offsetZ = Random.Range(-5,6);

				//60%コイン配置：30％車配置：10％何もなし
				if(1 <= item && item <= 6)
				{
					//コインを生成
					GameObject coin = Instantiate(coinPrefab) as GameObject;
					coin.transform.position = new Vector3(posRange * j,
															coin.transform.position.y,
															lastGeneratePos + offsetZ);
				}
				else if(7 <= item && item <= 9)
				{
					//車を生成
					GameObject car = Instantiate(carPrefab) as GameObject;
					car.transform.position = new Vector3(posRange * j,
															carPrefab.transform.position.y,
															lastGeneratePos + offsetZ);
				}
			}
		}
	}
}
