using UnityEngine;
using System;

public class MathUtilities  {

    //Calcula un angulo entre dos puntos sobre le eje x
    static public float calculateAngle2DtoX(Vector3 pointB, Vector3 PointA, float offset)
    {
        //Recibe las cordenadas de B y A , B es el eje, A es el objetivo.

        float angle;

        //Crea 4 variables para un espacio 2d, con X y Y de los puntos A y B
        float ay = PointA.y;
        float az = PointA.z;
        float by = pointB.y;
        float bz = pointB.z;

        //Recibe el arcotangente de la pendiente, y lo pasa a grados (por que devuelve en radianes)
        angle = (Mathf.Atan2((by - ay), (bz - az))) * Mathf.Rad2Deg;

        return - angle  + offset;

    }

    //Calcula un angulo entre dos puntos sobre le eje y
    static public float calculateAngle2DtoY(Vector3 pointB, Vector3 PointA, float offset)
    {
        //Recibe las cordenadas de B y A , B es el eje, A es el objetivo.

        float angle;

        //Crea 4 variables para un espacio 2d, con X y Y de los puntos A y B
        float ax = PointA.x;
        float az = PointA.z;
        float bx = pointB.x;
        float bz = pointB.z;

        //Recibe el arcotangente de la pendiente, y lo pasa a grados (por que devuelve en radianes)
        angle = (Mathf.Atan2((bz - az), (bx - ax))) * Mathf.Rad2Deg;

        return - angle + offset;
        //270- angle

    }

    //Calcula un angulo entre dos puntos sobre le eje z
    static public float calculateAngle2DtoZ(Vector3 pointB, Vector3 PointA, float offset)
    {
        //Recibe las cordenadas de B y A , B es el eje, A es el objetivo.

        float angle;

        //Crea 4 variables para un espacio 2d, con X y Y de los puntos A y B
        float ax = PointA.x;
        float ay = PointA.y;
        float bx = pointB.x;
        float by = pointB.y;

        //Recibe el arcotangente de la pendiente, y lo pasa a grados (por que devuelve en radianes)
        angle = (Mathf.Atan2((bx - ax), (by - ay))) * Mathf.Rad2Deg;

        return - angle + offset;

    }
    

    //interpola entre dos valores, con un valor de cambio. Es como un Lerp solo que super basico y sin uso del tiempo
    static public float IntervalsMov(float current, float target, float velocity) {
        if (velocity > 0)
        {
            if (current <= target && (current + velocity) <= target)
            {
                current += velocity;
            }
            else
            {
                current = target;
            }
        }
        else if(velocity < 0) {
            if ((current >= target) && ((current + velocity) >= target))
            {
                current += velocity;
            }
            else
            {
                current = target;
            }
        }

        return current;
    }

    //Busca el objeto más cercano a un punto en un array de objetos y devuelve el objeto
    static public GameObject FindObjectMoreNear(Vector3 point, UnityEngine.Object[] objectsArray)
    {
        int objectMoreNear = 0;
        float distance = 1000;

        for (int i = 0; i < objectsArray.Length; i++)
        {
            if (distance > Vector3.Distance(point, ((GameObject)objectsArray[i]).transform.position))
            {
                objectMoreNear = i;
                distance = Vector3.Distance(point, ((GameObject)objectsArray[i]).transform.position);
            }

        }

        return (GameObject)objectsArray[objectMoreNear];
    }

    static public Vector4[] AddToVector4(Vector4[] matriz, Vector4 value) {
        int size;
        try
        {
            size = matriz.Length;
        }
        catch (NullReferenceException e)
        {
            size = 0;
        }

        Vector4[] newMatriz = new Vector4[size + 1];

        for (int x = 0; x < newMatriz.Length - 1; x++)
        {
            newMatriz[x] = matriz[x];
        }

        newMatriz[newMatriz.Length - 1] = new Vector4(value.x, value.y, value.z, value.w);

        return newMatriz;
    }

    static public Vector4[] OrderVector4ForW(Vector4[] matriz) {
        int size;
        try
        {
            size = matriz.Length;
        }
        catch (NullReferenceException)
        {
            size = 0;
        }

        Vector4[] newMatriz = new Vector4[size];

        for (int x = 0; x < size; x++)
        {
            int y = 0;
            while (matriz[y].z != x + 1)
            {
                y++;
            }
            newMatriz[x] = matriz[y];
        }

        return newMatriz;
    }
}
