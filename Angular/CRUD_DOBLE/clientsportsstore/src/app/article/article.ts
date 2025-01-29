import { ICategory } from "../category/category";

export interface IArticle {
  id: number;
  name: string;
  categoryID?: number;
  category: ICategory;
  price: number;
  stock: number;
}
