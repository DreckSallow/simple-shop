import Carousel from "@/components/carousel";

export default function Home() {
  const images = [
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png"
  ]
  return (
    <section>
      <Carousel className="web-page" images={images} />
      <section className="px-4 py-2">
        <h3 className="text-2xl">Productos Destacados</h3>
        <div className="mt-2">
          items
        </div>
      </section>
      <section className="px-4 py-2">
        <h3 className="text-2xl">Ofertas</h3>
        <div className="mt-2">
          items
        </div>
      </section>
      <section className="px-4 py-2">
        <h3 className="text-xl text-center">Productos Destacados</h3>
        <div className="flex-rw mt-2 px-4">
          categories
        </div>
      </section>
    </section>
  )
}
