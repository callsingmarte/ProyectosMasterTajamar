﻿namespace CoreSQL_ELB_demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
