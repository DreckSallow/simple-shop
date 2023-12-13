"use client";
import Image from "next/image";
import { useState } from "react";
import { ArrowIcon } from "./icons";

interface Props {
  className?: string;
  images: string[];
}

type SelectIndex = "add" | "sub" | number

export default function Carousel({ className, images }: Props) {
  const [index, setIndex] = useState(0);

  function selectIndex(si: SelectIndex) {
    if (si == "add") {
      setIndex(index + 1 >= images.length ? 0 : index + 1);
    } else if (si == "sub") {
      setIndex(index - 1 <= 0 ? (images.length - 1) : index - 1);
    } else {
      const inRange = si < (images.length) && si >= 0;
      if (inRange) setIndex(si)
    }
  }

  return (
    <div className={`w-full flex flex-col ${className ?? ''}`}>
      <div className="w-full flex-1 relative flex items-center">
        <button className="absolute left-0 bg-zinc-800/[.5] z-10 p-1 rounded-sm ml-2" onClick={() => selectIndex("sub")}>
          <ArrowIcon className="rotate-90 fill-white" height="24" width="24" />
        </button>
        <Image src={images[index]} alt="carousel-image" fill />
        <button className="absolute right-0 bg-zinc-800/[.5] z-10 p-1 rounded-sm mr-2" onClick={() => selectIndex("add")}>
          <ArrowIcon className="-rotate-90 fill-white" height="24" width="24" />
        </button>
      </div>
      <div className="flex-rw justify-center gap-3 py-4 px-4" onClick={(e) => {
        const index = (e.target as HTMLElement).dataset["index"];
        selectIndex(Number(index));
      }}>
        {
          images.map((_img, i) => (
            <button
              className={`rounded-full py-3 ${i == index ? 'bg-amber-500 aspect-auto px-5' : 'bg-gray-300 aspect-square px-3'}`}
              key={i}
              data-index={i}
            />
          ))
        }
      </div>
    </div>
  )

}
