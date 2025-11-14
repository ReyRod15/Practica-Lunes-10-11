using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_numero_1_practica_de_arboles_y_grafo
{
    class Nodo
    {
        public int valor;
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(int valor)
        {
            this.valor = valor;
            izquierdo = null;
            derecho = null;
        }
    }

    class ArbolBinario
    {
        public Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        // Insertar nodo en el árbol (por simplicidad, tipo búsqueda binaria)
        public void Insertar(int valor)
        {
            raiz = InsertarRec(raiz, valor);
        }

        private Nodo InsertarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.valor)
                nodo.izquierdo = InsertarRec(nodo.izquierdo, valor);
            else
                nodo.derecho = InsertarRec(nodo.derecho, valor);

            return nodo;
        }

        // Recorrido en preorden
        public void Preorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.valor + " ");
                Preorden(nodo.izquierdo);
                Preorden(nodo.derecho);
            }
        }

        // Contar nodos (recursivo)
        public int ContarNodos(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarNodos(nodo.izquierdo) + ContarNodos(nodo.derecho);
        }
    }

    class Program
    {
        static void Main()
        {
            ArbolBinario arbol = new ArbolBinario();

            Console.WriteLine("Ingrese valores para el árbol (termine con -1):");
            int valor;
            while (true)
            {
                valor = int.Parse(Console.ReadLine());
                if (valor == -1) break;
                arbol.Insertar(valor);
            }

            Console.WriteLine("\nRecorrido Preorden:");
            arbol.Preorden(arbol.raiz);

            Console.WriteLine($"\nCantidad de nodos: {arbol.ContarNodos(arbol.raiz)}");
            Console.ReadKey();
        }
    }
}
