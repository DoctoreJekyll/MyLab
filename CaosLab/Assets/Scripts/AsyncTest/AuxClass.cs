using System.Collections;
using System.Threading.Tasks;

public static class AuxClass
{

    //Funciçón auxiliar para comprobar throws ya que unity no registra o no debería de registrar los errores ocurridos en funciones asyncronas
    public static async void WrapErrors(this  Task task)
    {
        await task;
    }


    //Función para poder llamar funciones async dentro de corrutinas
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
