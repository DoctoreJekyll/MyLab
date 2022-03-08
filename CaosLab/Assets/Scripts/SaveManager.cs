//Namespaces necesarios para guardar y hacer las transformaciones a binario para mayor seguridad
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveManager
{
    //Métodos para guardar partida
    public static void SaveGameData(Controller00 player)
    {
        GameData gameData = new GameData(player);// Creamos un nuevo objeto de tipo gamedata donde están nuestras variables
        string dataPath = Application.persistentDataPath + "/player.save";//Generamos una ruta donde vamos a guardar nuestros datos
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);//Creamos el archivo
        BinaryFormatter formatter = new BinaryFormatter();//Convertimos los datos a binario
        formatter.Serialize(fileStream, gameData);//Convertimos a binario los datos que necesitemos
        fileStream.Close();//Cerramos nuestro filestream(Flujo de datos)
    }

    public static GameData LoadGameData()
    {
        //Damos la ruta de donde vamos a cargar los datos
        string dataPath = Application.persistentDataPath + "/player.save";

        //Si el archivo existe, lo abrimos, y desconvertimos de binario a datos simples que serán los que utilicemos
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            GameData playerData = (GameData)formatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
            return null;
        }

    }
}
