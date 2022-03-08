using System.Collections;
using System.Threading.Tasks;

public static class AuxClass
{

    //Funci��n auxiliar para comprobar throws ya que unity no registra o no deber�a de registrar los errores ocurridos en funciones asyncronas
    public static async void WrapErrors(this  Task task)
    {
        await task;
    }


    //Funci�n para poder llamar funciones async dentro de corrutinas
    public static IEnumerator AsCoroutine(this Task task)
    {
        while (!task.IsCompleted)
        {
            yield return null;
        }

        if (task.IsFaulted)
        {
            throw task.Exception;
        }

    }

}
