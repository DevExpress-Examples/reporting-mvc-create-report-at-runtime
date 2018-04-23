using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class Category {
    public int CategoryID {
        get;
        set;
    }

    public string CategoryName {
        get;
        set;
    }

    public string Description {
        get;
        set;
    }

    public byte[] Picture {
        get;
        set;
    }

    public byte[] Icon_17 {
        get;
        set;
    }

    public byte[] Icon_25 {
        get;
        set;
    }

    public static List<Category> GetCategories() {
        DataTable catData = DataHelper.ProcessSelectCommand("SELECT * FROM [Categories]");
        if (catData != null) {
            List<Category> categories = new List<Category>();
            foreach (DataRow row in catData.Rows) {
                Category category = new Category() {
                    CategoryID = (int) row["CategoryID"],
                    CategoryName = (string) row["CategoryName"],
                    Description = (string) row["Description"],
                    Picture = (byte[]) row["Picture"],
                    Icon_17 = (byte[]) row["Icon_17"],
                    Icon_25 = (byte[]) row["Icon_25"]
                };
                categories.Add(category);
            }
            return categories;
        }
        return null;
    }
}