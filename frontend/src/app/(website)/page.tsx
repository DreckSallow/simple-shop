import { api } from "@/config";
import Carousel from "@/components/carousel";
import { PopularProduct } from "@/components/products";

async function getAllCategories() {
  const res = await fetch(api("/categories"));
  const categories: { id: number, name: string }[] = await res.json();
  return categories;
}

interface Product {
  id: number,
  name: string,
  price: number,
  description: string,
  discount: number,
  brand: string
}

async function getFeaturedProducts() {
  const res = await fetch(api("/products/populars"));
  const products = await res.json();
  products.forEach((p: any) => {
    p.brand = p.brand.name
  });
  return products as Product[];
}
export default async function Home() {
  const images = [
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png"
  ];
  const categories = await getAllCategories();
  const popularProducts = await getFeaturedProducts();
  return (
    <section>
      <Carousel className="web-page" images={images} />
      <section className="px-4 py-2">
        <h3 className="text-2xl font-semibold mb-5">Productos Destacados</h3>
        <div className="mt-2 gap-4 grid grid-cols-2 md:grid-cols-4 lg:grid-cols-5 w-[90%] mx-auto">
          {popularProducts.map((p) => (
            <PopularProduct product={p} key={p.id} />
          ))}
        </div>
      </section>
      {/*<section className="px-4 py-2">
        <h3 className="text-2xl">Ofertas</h3>
        <div className="mt-2">
          items
        </div>
      </section>*/}
      <section className="px-4 py-2 mt-10">
        <h3 className="text-xl text-center mb-4">Categorias</h3>
        <div className="flex-rw mt-2 px-4 flex flex-wrap gap-4 mx-auto w-10/12 md:8/12">
          {categories.map((ct) => (
            <button className="rounded-full px-4 py-1 border border-neutral-300">{ct.name}</button>
          ))}
        </div>
      </section>
    </section>
  )
}


