﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory {

    private Dictionary<int, Item> Items = new Dictionary<int, Item>();

    public bool IsEmpty => Items.Count == 0;
    public List<Item> ItemList => Items.Values.ToList();

    public void AddItem(Item item) {
        Items.TryGetValue(item.info.index, out var it);
        if (it != null) {
            it.info.amount++;
        } else {
            Items.Add(item.info.index, item);
        }
    }

    public void RemoveItem(Item item) {
        Items.TryGetValue(item.info.index, out var it);
        if (it != null) {
            Items.Remove(item.info.index);
        }
    }

    public void RemoveItem(int index) {
        Items.TryGetValue(index, out var it);
        if(it != null) {
            Items.Remove(index);
        }
    }
}