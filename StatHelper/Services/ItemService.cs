using StatHelper.Models;
using StatHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;

namespace StatHelper.Services
{
    public class ItemService : ServiceBase
    {

        public readonly ObservableCollection<ItemViewModel> Items;

        public ItemService()
        {
            Items = new ObservableCollection<ItemViewModel>();
            Items.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedMethod);

            LoadItems();
        }

        private void LoadItems()
        {
            List<string> lines = File.ReadAllLines("Resources/Data.csv").ToList();

            DataTable dt = new DataTable();
            
            if (lines.Count > 0)
            {
                foreach (string column in lines[0].Split(','))
                {
                    DataColumn col = new DataColumn();
                    col.ColumnName = column.ToString();
                    dt.Columns.Add(col);
                }

                lines.RemoveAt(0);

                foreach (string line in lines)
                {
                    DataRow row = dt.NewRow();

                    string[] values = line.Split(',');

                    row.ItemArray = values;
                    dt.Rows.Add(row);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                ItemViewModel item = new ItemViewModel(new Item(Int32.Parse(row["Attack"].ToString()), Int32.Parse(row["CritDmg"].ToString()), Equipment.FromName(row["Equipment"].ToString())));
                Items.Add(item);
            }

        }

        private void SaveItems()
        {
            List<string> lines = new();
            lines.Add("Attack,CritDmg,Equipment");
            foreach (ItemViewModel item in Items)
            {
                lines.Add($"{item.Attack},{item.CritDmg},{item.Equipment.Name}");
            }
            File.WriteAllLines("Resources/Data.csv", lines);
        }


        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            SaveItems();
            if (e.NewItems == null)
            {
                return;
            }
            foreach (ItemViewModel item in e.NewItems)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SaveItems();
        }



    }
}
