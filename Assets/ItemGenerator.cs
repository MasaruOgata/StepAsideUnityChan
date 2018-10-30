using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんを入れる
    public GameObject UnityChan;

    float timeElapsed = 0.0f;

    // Use this for initialization
    void Start()
    {
        ////一定の距離ごとにアイテムを生成
        //      for(int i = startPos; i < goalPos; i += 15) {
        //          //どのアイテムを出すのかランダムに設定
        //          int num = Random.Range(1, 11);
        //          if (num <= 2){
        //              //コーンをx軸方向に一直線に生成
        //              for (float j = -1; j <= 1; j += 0.4f)
        //              {
        //                  GameObject cone = Instantiate(conePrefab) as GameObject;
        //                  cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        //              }
        //          }
        //          else
        //          {
        //              //レーンごとにアイテムを生成
        //              for (int j = -1; j <= 1; j++)
        //              {
        //                  //アイテムの種類を決める
        //                  int item = Random.Range(1, 11);
        //                  //アイテムを置くz座標のオフセットをランダムに設定
        //                  int offsetZ = Random.Range(-5, 6);
        //                  //60%コイン配置:30%車配置:10%何もなし
        //                  if (1 <= item && item <= 6)
        //                  {
        //                      //コインを生成
        //                      GameObject coin = Instantiate(coinPrefab) as GameObject;
        //                      coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
        //                  }
        //                  else if (7 <= item && item <= 9)
        //                  {
        //                      GameObject car = Instantiate(carPrefab) as GameObject;
        //                      car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
        //                  }
        //              }
        //          }
        //      }


        //Unityちゃんを取得
        this.UnityChan = GameObject.Find("unitychan");
    }


    // Update is called once per frame
    void Update()
    {

        //一定時間ごとにアイテムを生成するための変数
        float timeOut = 0.7f;
        
        //一定時間ごとにアイテムを生成したい
        timeElapsed += Time.deltaTime; 

        if (timeElapsed > timeOut)
        {
            //ゴールより先にアイテムが生成されないように範囲を制限
            if (UnityChan.transform.position.z <= 80)
            {

                //float genePosZ = Random.Range(UnityChan.transform.position.z + 10, UnityChan.transform.position.z + 40);
                //↑ランダム生成だとアイテムが被って生成される時があるので却下

                //Unityちゃんの45m先にアイテムを生成
                float genePosZ = UnityChan.transform.position.z + 45;
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, genePosZ);
                    }
                }
                else
                {
                    for (float j = -1; j <= 1; j++)
                    {
                        int item = Random.Range(1, 11);
                        int offsetZ = Random.Range(-5, 6);

                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, genePosZ + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, genePosZ + offsetZ);
                        }
                    }
                }
            }

            timeElapsed = 0.0f;
        }

       
        
    }
}