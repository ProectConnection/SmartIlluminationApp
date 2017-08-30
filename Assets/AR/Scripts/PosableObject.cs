using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RigidbodyVelocity2D
{
    public Vector2 velocity;
    public float angularVelocity;
    public RigidbodyVelocity2D(Rigidbody2D rigidbody2d)
    {
        velocity = rigidbody2d.velocity;
        angularVelocity = rigidbody2d.angularVelocity;
    }
}

public class PosableObject : MonoBehaviour {
    public bool pousing;
    public GameObject[] ignoreGameObjects;
    bool prevPousing;
    RigidbodyVelocity2D[] rigidbodyVelocities;
    Rigidbody2D[] pousingRigidbodies2D;
    MonoBehaviour[] pousingMonoBehaviours;
	
	// Update is called once per frame
	void Update () {
	    if(prevPousing != pousing)
        {
            if (pousing) Pouse();
            else Resume();
            prevPousing = pousing;
        }
	}

    void Pouse()
    {
        //rigidBodyの停止
        //以下の条件に符合するrigidBodyを停止
         //・スリープ中ではない
         //・ignoreGameObjectsに含まれていない

         //C#のArray.FindAllにて、以上の条件に適合する
         //オブジェクトを検索する為、
         //最初にPredicate型の叙述関数を宣言
         
         //叙述関数…引数を持ち、かつ１つのbool型の戻り値を返却する関数 
         //          検索に使うアルゴリズム

        //プレディケート自体は、関数名を持たない関数を作り出す方法の一つ。
        //ラムダ式と呼ばれる。
        //可読性の向上が期待できる。
         
        Predicate<Rigidbody2D> rigidBodyPredicate =
            obj => !obj.IsSleeping() &&
            Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pousingRigidbodies2D = Array.FindAll(transform.GetComponentsInChildren<Rigidbody2D>(), rigidBodyPredicate);
        rigidbodyVelocities = new RigidbodyVelocity2D[pousingRigidbodies2D.Length];
        for(int i = 0; i < pousingRigidbodies2D.Length; i++)
        {
            //速度、角速度の保存
            rigidbodyVelocities[i] = new RigidbodyVelocity2D(pousingRigidbodies2D[i]);
            pousingRigidbodies2D[i].Sleep();

        }

        //Monovehaviourの停止
        Predicate<MonoBehaviour> monoBehaviourPredicate =
            obj => obj.enabled &&
                   obj != this &&
                   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pousingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);

        foreach (var monoBehaviour in pousingMonoBehaviours)
        {
            monoBehaviour.enabled = false;
        }
    }
    //再開
    void Resume()
    {
        //rigidBodyの再開
        for(int i = 0;i < pousingRigidbodies2D.Length; i++)
        {
            pousingRigidbodies2D[i].WakeUp();
            pousingRigidbodies2D[i].velocity = rigidbodyVelocities[i].velocity;
            pousingRigidbodies2D[i].angularVelocity = rigidbodyVelocities[i].angularVelocity;
        }

        foreach(var monoBehaviour in pousingMonoBehaviours)
        {
            monoBehaviour.enabled = true;
        }
    }
}
