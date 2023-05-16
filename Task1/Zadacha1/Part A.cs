using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadacha1
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T> : ICollection<T>
    {
        //Начальный элемент односвязного списка, конечный элемент односвязного списка
        private Node<T> _head;
        private Node<T> _tail;

        //Количество элементов
        public int Count { get; private set; }

        public bool IsReadOnly => false;   

        public void Add(T element)
        {
            var node = new Node<T> { Value = element };

            //Если в списке нет элементов
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            //Добавляем последний элемент в конец
            else
            {
                _tail.Next = node;
                _tail = node;
            }
            //Увеличение значения количества элементов
            Count++;
        }

        //Метод очистки списка
        public void Clear() 
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T element)
        {
            var current = _head;
            //Проверка на наличие элементов в списке
            while (current != null)
            {
                //Проверка на равенство текущего элемента с элементов в списке
                if (EqualityComparer<T>.Default.Equals(current.Value, element))
                {
                    return true;
                }
                else
                {
                    current= current.Next;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            //Проверка, что список пустой
            if (array == null)
            {
                throw new ArgumentNullException("array = null | список = нулю");
            }
            //Проверка что индекс списка не меньше количества элементов
            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index outside the list or index = null | индех за пределами списка или равен нулю");
            }
            //Проверка что длина списка - индекс списка, не больше количества элементов
            if (array.Length - index < Count)
            {
                throw new ArgumentOutOfRangeException("Count more element in the list | Количество элементов, больше чем длина списка");
            }
            
            //Копирование списка
            var current = _head;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T element)
        {
            var current = _head;
            Node<T> early = null;
            //Пока список не пустой
            while (current != null)
            {
                //Проверка на равенство текущего элемента с элементов в списке
                if (EqualityComparer<T>.Default.Equals(current.Value = element))
                {
                    if (early != null)
                    {
                        early.Next = current.Next;

                        if(current.Next != null)
                        {
                            _tail = early;
                        }
                    }

                    else
                    {
                        _head = _head.Next;

                        if( _head == null)
                        {
                            _tail = null;
                        }
                    }

                    Count--;
                    return true;
                }

                early = current;
                current = current.Next;
            }
            return false;
        }
        //Метод перебора списка
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }


}