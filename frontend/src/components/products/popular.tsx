import Image from "next/image";
interface Product {
  id: number,
  name: string,
  price: number,
  description: string,
  discount: number,
  brand: string
  // "category": null,
  // "brand": null
}
export function PopularProduct({ product }: { product: Product }) {
  return (
    <div className="max-w-[200px] w-[200px] flex flex-col">
      <Image src="https://placehold.co/200x250/png" alt={product.name} className="rounded-xl" width={200} height={250} />
      <div className="flex flex-1 justify-between flex-col">
        <header className="w-full">
          <span className="block mt-1 text-xs font-medium">{product.brand}</span>
          <a href={`/products/${product.id}`} className="text-sm font-medium my-1">{product.name}</a>
          <span className="font-semibold text-sm block text-end">S/. {product.price}</span>
        </header>
        <a href={`/products/${product.id}`} className="text-xs underline hover:no-underline text-neutral-700 mt-auto mb-1">
          Ver detalle
        </a>
      </div>
    </div>
  );
}
