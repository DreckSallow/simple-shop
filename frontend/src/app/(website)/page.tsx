import Carousel from "@/components/carousel";
import { api } from "@/config";

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
  // "category": null,
  // "brand": null
}

async function getFeaturedProducts() {
  const res = await fetch(api("/products/populars"));
  const products = await res.json();
  return products;
}
export default async function Home() {
  const images = [
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png"
  ];
  const categories = await getAllCategories();
  const popularProducts = await getFeaturedProducts();
  console.log(categories);
  return (
    <section>
      <Carousel className="web-page" images={images} />
      <section className="px-4 py-2">
        <h3 className="text-2xl">Productos Destacados</h3>
        <div className="mt-2 flex flex-wrap gap-4">
          {popularProducts.map((p) => (
            <div className="rounded-lg p-4 bg-white">
              <h4>{p.name}</h4>
              <h4>{p.description}</h4>
            </div>
          ))}
        </div>
      </section>
      <section className="px-4 py-2">
        <h3 className="text-2xl">Ofertas</h3>
        <div className="mt-2">
          items
        </div>
      </section>
      <section className="px-4 py-2">
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
