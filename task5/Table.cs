using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{/*
На базі generic collections платформи .NET реалізувати узагальнену структуру 
даних Table<R, C, V>
R - row key
C - column key
V - value
Ця структура даних повинна забезпечувати доступ до збережених в ній значень 
по ключах R i C зі складністю O(1).*/
    internal class Table<R,C,V>
    {
        private Dictionary<R,Dictionary<C,V>> table { get; set; }
        public Table()
        {
            table = new Dictionary<R, Dictionary<C, V>>();
        }
        public void Add(R row, C col, V value)
        {
            if (!table.ContainsKey(row))
            {
                table.Add((R)row, new Dictionary<C, V>());
                table[row].Add(col, value);
            }
            else if (table[row].ContainsKey(col))
            {
                throw new duplicationExeption("This column already exists!");
            }
            else
            {
                table[row].Add(col, value);
            }            
        }
        public V GetValue(R row, C col)
        {
            if (table.ContainsKey(row))
            {
                if (table[row].ContainsKey(col))
                {
                    return table[row][col];
                }
                else
                {
                    return default(V);
                }
            }
            else
            {
                return default(V);
            }
        }

        public void Remove(R row, C col)
        {
            if (table[row].ContainsKey(col))
            {
                table[row].Remove(col);
            }
            else
            {
                throw new ArgumentNullException("This column doesn't exist!");
            }            
        }
        public void RemoveRow(R row)
        {
            if (table.ContainsKey(row))
            {
                table.Remove(row);
            }
            else
            {
                throw new ArgumentNullException("This row doesn't exist!");
            }
        }
        public void Clear()
        {
            foreach (var r in table.Keys)
            {
                table[r].Clear();
            }
            table.Clear();
        }
        public V this[R row , C col] 
        { 
            get { return GetValue(row, col); } 
            set { Add(row, col, value); }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in table)
            { 
                stringBuilder.Append(item.Key.ToString() + "\n");
                foreach(var value in table[item.Key])
                {
                    stringBuilder.Append(value.Key.ToString() + "\n");
                }
            }
            return stringBuilder.ToString();
        }
    }
}
