import { CartIcon, SearchIcon } from "@/components/icons";

interface Children {
  children: React.ReactNode
}
export default function WebsiteLayout({ children }: Children) {
  return (
    <main className="web-main">
      <NavBar />
      {children}
    </main>
  )
}

function NavBar() {
  return (
    <nav className="flex-rw justify-between px-4 bg-white gap-3">
      <div>LOGO</div>
      <div className="flex-rw search-out">
        <SearchIcon />
        <input type="search" placeholder="Buscar" className="ml-2 outline-none" />
      </div>
      <ul className="flex-rw justify-between gap-3">
        <li className="cursor-pointer rounded-full p-2 border border-gray-300">
          <CartIcon />
        </li>
        <li className="btn-pry">
          Login
        </li>
      </ul>
    </nav>
  )
}
