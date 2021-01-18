using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using thuchanhmodul3.Models;

namespace thuchanhmodul3.Storage
{
    public class FileProduct
    {
        string pathFile = "C:/Users/Pro 2004/Desktop/thuchanhmodul3/products.txt";
        
        public List<Product> Read()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (StreamReader reader = new StreamReader(pathFile))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] product = line.Split(',');
                        Product product1 = new Product(Convert.ToInt32(product[0]), product[1], Convert.ToInt32(product[2]));
                        products.Add(product1);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Can not read");
                Console.WriteLine(e.Message);
            }
            return products;
        }

        public void Write(List<Product> products)
        {
            try
            {
                if (!System.IO.File.Exists(pathFile))
                {
                    System.IO.File.Create(pathFile).Dispose();
                }
                using (StreamWriter writer = new StreamWriter(pathFile))
                {
                    foreach( var p in products)
                    {
                        writer.WriteLine(p.Id + "," + p.Name + "," + p.Price);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Can not write");
                Console.WriteLine(e.Message);
            }
        }
    }
}