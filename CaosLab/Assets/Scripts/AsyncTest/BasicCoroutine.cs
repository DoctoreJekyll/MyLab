using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class BasicCoroutine : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //MyAsync();
            Debug.Log("1");
            StartCoroutine(BasicCorroutine());
            Debug.Log("3");
        }
    }


    private IEnumerator BasicCorroutine()
    {
        Debug.Log("2");
        yield return new WaitForEndOfFrame();
        Debug.Log("4");

        yield return MyAsync().AsCoroutine();

    }

    //Testing async cosas
    //Para usar correctamente funciones asyncronas hay que usar los namespaces System y System.Threading.Task
    //Las funciones async tienen varias peculiaridades entre: Se ejecutan de forma paralela -- Pueden devolver valores
    //Se pueden convertir las funciones de unity en asyncronas, por ejemplo el Update
    private async Task MyAsync()//Para poder llamar funciones async en corrutinas hay que hacer que devuelvan un Task//Hacerlas del tipo task en cierto modo
    {
        Debug.Log("Wait 1 second...");
        await Task.Delay(TimeSpan.FromSeconds(1));
        int number = await MyAsyncInt();//Si usamos el await antes de la funcion, ésta esperará a que termine la funcion para darnos el valor
        Debug.Log("Done");
        Debug.Log(number);
    }

    private async Task<int> MyAsyncInt()
    {

        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));
        }
        await MyFloat();
        return 10;
    }

    private async Task<float> MyFloat()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        return 5.5f;
    }

}


