using System;
using System.Collections.Generic;

namespace List
{
    public class DoublyLinkedList<T>
        where T : IComparable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        // =========================
        // INSERTAR EN ORDEN ASCENDENTE
        // =========================
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            if (data.CompareTo(head.Data) <= 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
                return;
            }

            Node<T>? current = head;

            while (current.Next != null 
                   current.Next.Data.CompareTo(data) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Previous = current;

            if (current.Next != null)
                current.Next.Previous = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }

        // =========================
        //  MOSTRAR NORMAL
        // =========================
        public void ShowForward()
        {
            Node<T>? current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }

        // =========================
        // MOSTRAR INVERSO
        // =========================
        public void ShowBackward()
        {
            Node<T>? current = tail;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Previous;
            }

            Console.WriteLine();
        }

        // =========================
        // ORDEN DESCENDENTE REAL
        // =========================
        public void SortDescending()
        {
            if (head == null) return;

            Node<T>? i = head;

            while (i != null)
            {
                Node<T>? j = i.Next;

                while (j != null)
                {
                    if (i.Data.CompareTo(j.Data) < 0)
                    {
                        T temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }

                    j = j.Next;
                }

                i = i.Next;
            }
        }

        // =========================
        // EXISTE
        // =========================
        public bool Exists(T value)
        {
            Node<T>? current = head;

            while (current != null)
            {
                if (current.Data!.Equals(value))
                    return true;

                current = current.Next;
            }

            return false;
        }

        // =========================
        // ELIMINAR UNA OCURRENCIA
        // =========================
        public void RemoveOne(T value)
        {
            Node<T>? current = head;

            while (current != null)
            {
                if (current.Data!.Equals(value))
                {
                    if (current == head)
                    {
                        head = head.Next;

                        if (head != null)
                            head.Previous = null;
                        else
                            tail = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Previous;

                        if (tail != null)
                            tail.Next = null;
                    }
                    else
                    {
                        current.Previous!.Next = current.Next;
                        current.Next!.Previous = current.Previous;
                    }

                    return;
                }

                current = current.Next;
            }
        }

        // =========================
        // ELIMINAR TODAS
        // =========================
        public void RemoveAll(T value)
        {
            while (Exists(value))
                RemoveOne(value);
        }

        // =========================
        // MODA
        // =========================
        public List<T> Mode()
        {
            Dictionary<T, int> freq = new Dictionary<T, int>();

            Node<T>? current = head;

            while (current != null)
            {
                if (freq.ContainsKey(current.Data))
                    freq[current.Data]++;
                else
                    freq[current.Data] = 1;

                current = current.Next;
            }

            int max = 0;

            foreach (var item in freq)
                if (item.Value > max)
                    max = item.Value;

            List<T> modes = new List<T>();

            foreach (var item in freq)
                if (item.Value == max)
                    modes.Add(item.Key);

            return modes;
        }

        // =========================
        // GRÁFICA DE FRECUENCIAS
        // =========================
        public void Graficar()
        {
            if (head == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Dictionary<T, int> freq = new Dictionary<T, int>();

            Node<T>? current = head;

            while (current != null)
            {
                if (freq.ContainsKey(current.Data))
                    freq[current.Data]++;
                else
                    freq[current.Data] = 1;

                current = current.Next;
            }

            foreach (var item in freq)
            {
                Console.Write(item.Key + " ");

                for (int i = 0; i < item.Value; i++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }
    }
}
