using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_de_grafos_y_arboles
{
    class Nodo
    {
        public int valor;
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(int valor)
        {
            this.valor = valor;
        }
    }

    class ArbolBinario
    {
        public Nodo raiz;

        public Nodo Insertar(Nodo nodo, int valor)
        {
            if (nodo == null) return new Nodo(valor);
            if (valor < nodo.valor)
                nodo.izquierdo = Insertar(nodo.izquierdo, valor);
            else
                nodo.derecho = Insertar(nodo.derecho, valor);
            return nodo;
        }

        public void Inorden(Nodo nodo)
        {
            if (nodo == null) return;
            Inorden(nodo.izquierdo);
            Console.Write(nodo.valor + " ");
            Inorden(nodo.derecho);
        }

        public void Preorden(Nodo nodo)
        {
            if (nodo == null) return;
            Console.Write(nodo.valor + " ");
            Preorden(nodo.izquierdo);
            Preorden(nodo.derecho);
        }

        public void Postorden(Nodo nodo)
        {
            if (nodo == null) return;
            Postorden(nodo.izquierdo);
            Postorden(nodo.derecho);
            Console.Write(nodo.valor + " ");
        }

        public void Espejo(Nodo nodo)
        {
            if (nodo == null) return;

            Nodo temp = nodo.izquierdo;
            nodo.izquierdo = nodo.derecho;
            nodo.derecho = temp;

            Espejo(nodo.izquierdo);
            Espejo(nodo.derecho);
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
                arbol.raiz = arbol.Insertar(arbol.raiz, valor);
            }

            Console.WriteLine("\nInorden original:");
            arbol.Inorden(arbol.raiz);

            arbol.Espejo(arbol.raiz);
            Console.WriteLine("\n\nÁrbol en espejo:");

            Console.WriteLine("Inorden:");
            arbol.Inorden(arbol.raiz);

            Console.WriteLine("\nPreorden:");
            arbol.Preorden(arbol.raiz);

            Console.WriteLine("\nPostorden:");
            arbol.Postorden(arbol.raiz);

            Console.ReadKey();
        }

        }
    }
