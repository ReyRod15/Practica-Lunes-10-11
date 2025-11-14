using System;

class Nodo
{
    // Valor almacenado en el nodo
    public int Valor;
    // Referencias a los hijos izquierdo y derecho
    public Nodo Izquierdo;
    public Nodo Derecho;

    // Constructor: inicializa el nodo con un valor y sin hijos
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

// Árbol binario de búsqueda (BST)
// En un BST, los valores menores van al subárbol izquierdo y los mayores al derecho.
class ArbolBinarioBusqueda
{
    public Nodo Raiz;

    // Inserta un valor en el árbol (método de entrada que llama a la versión recursiva)
    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz, valor);
    }

    // Inserción recursiva:
    // -   Si el nodo actual es null, crea un nuevo nodo.
    // -    Si el valor es menor que el nodo actual lo inserta en el izquierdo.
    // -  Si es mayor, lo inserta en el derecho.
    // Valores iguales se ignoran (no se insertan duplicados).
    private Nodo InsertarRecursivo(Nodo actual, int valor)
    {
        if (actual == null)
            return new Nodo(valor);

        if (valor < actual.Valor)
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
        else if (valor > actual.Valor)
            actual.Derecho = InsertarRecursivo(actual.Derecho, valor);

        return actual;
    }

    // Suma recursiva de todos los valores del árbol.
    // Caso base: nodo nulo devuelve 0.
    public int Sumar(Nodo nodo)
    {
        if (nodo == null)
            return 0;

        return nodo.Valor + Sumar(nodo.Izquierdo) + Sumar(nodo.Derecho);
    }

    // Cuenta la cantidad de valores pares e impares.
    // Usa parámetros por referencia para acumular los resultados durante la recursión.
    public void ContarParesImpares(Nodo nodo, ref int pares, ref int impares)
    {
        if (nodo == null) return;

        if (nodo.Valor % 2 == 0)
            pares++;
        else
            impares++;

        ContarParesImpares(nodo.Izquierdo, ref pares, ref impares);
        ContarParesImpares(nodo.Derecho, ref pares, ref impares);
    }

    // Recorrido en postorden: visita izquierdo, derecho y luego la raíz.
    // Útil para operaciones que procesan subárboles antes del nodo padre.
    public void Postorden(Nodo nodo)
    {
        if (nodo == null) return;

        Postorden(nodo.Izquierdo);
        Postorden(nodo.Derecho);
        Console.Write(nodo.Valor + " ");
    }
}

class Programa
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        Console.WriteLine("=== Árbol Binario de Búsqueda ===");
        Console.Write("¿Cuántos valores desea ingresar?: ");
        int n = int.Parse(Console.ReadLine());

        // Lectura de n valores y construcción del BST
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el valor #{i + 1}: ");
            int valor = int.Parse(Console.ReadLine());
            arbol.Insertar(valor);
        }

        // Muestra el árbol en recorrido postorden
        Console.WriteLine("\nRecorrido en Postorden:");
        arbol.Postorden(arbol.Raiz);

        // Cálculos: suma total y conteo de pares/impares
        int suma = arbol.Sumar(arbol.Raiz);
        int pares = 0, impares = 0;
        arbol.ContarParesImpares(arbol.Raiz, ref pares, ref impares);

        Console.WriteLine($"\n\nSuma total de valores: {suma}");
        Console.WriteLine($"Cantidad de números pares: {pares}");
        Console.WriteLine($"Cantidad de números impares: {impares}");
    }
}
