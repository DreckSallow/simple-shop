import Carousel from "@/components/carousel";

export default function Home() {
  const images = [
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png",
    "https://placehold.co/1200x500/png"
  ]
  return (
    <section className="text-white">
      <Carousel className="web-page" images={images} />
    </section>
  )
}
