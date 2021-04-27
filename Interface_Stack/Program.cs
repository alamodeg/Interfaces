using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Stack
{
    class Program
    {
        interface IStack
        {
            void Push(int valor);
            bool IsEmpty();
            int Pop();
        }

        /// <summary>
        /// Implementacion con array
        /// </summary>
        class Stack_1 : IStack
        {
            readonly static int tama = 10;
            int top = -1; //llevara el control del tope de la pila
            readonly int[] array = new int[tama];
            public void Push(int valor)
            {
                if(top>=tama)
                {
                    Console.WriteLine("La pila esta llena");
                }
                else
                {
                    top += 1;
                    array[top] = valor;
                }
            }
            public bool IsEmpty()
            {
                if (top < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public int Pop()
            {
                if (IsEmpty())
                {
                    return -999; //control para un Pop de pilavacia
                }
                int valor = array[top--];
                return valor;
            }
        }
        /// <summary>
        /// Implementacion con List
        /// </summary>
        class Stack_2 : IStack
        {
            readonly List<int> listado = new List<int>();

            public void Push(int valor)
            {
                listado.Add(valor);
            }
            public bool IsEmpty()
            {
                return !listado.Any();
            }
            public int Pop()
            {
                if (IsEmpty())
                {
                    return -999; //lista vacia
                }
                else
                {
                    int aux = listado.Last();
                    listado.RemoveAt(listado.Count()-1);
                    return aux;
                }
            }
        }
        /// <summary>
        /// Implementacion con lista enlazada
        /// </summary>
        class Stack_3 : IStack
        {
            Nodo top = null; //referencia de la cabeza de la lista
            public class Nodo
            {
                public int dato;
                public Nodo next; //autoref a otro nodo del mismo tipo
            }
            public void Push(int valor)
            {
                Nodo temporal = new Nodo();
                temporal.dato = valor;
                temporal.next = top; //Nodo temporal se pone primero en la pila
                top = temporal; //se actualiza el top
            }
            public bool IsEmpty()
            {
                return this.top == null; 
            }
            public int Pop()
            {
                if (this.top == null)
                {
                    Console.WriteLine("La lista esta vacia");
                    return -999;
                }
                else
                {
                    int aux = top.dato;
                    top = top.next; //La cabecera se mueve al siguiente nodo
                    return aux;
                }
            }
        }
        static void Main(string[] args)
        {
            //Alterar entre Stack_1,Stack_2,Stack_3 para las 3 implementaciones
            var s = new Stack_1();
            
            s.Push(10);
            s.Push(20);
            s.Push(30);
            Console.WriteLine($" ¿Esta vacia la lista? {s.IsEmpty()}"); 
            while (!s.IsEmpty())
            {
                Console.WriteLine(s.Pop());
            }
            //30
            //20
            //10
            Console.Write("Pulsar ENTER"); Console.ReadLine();
        }
    }
}
