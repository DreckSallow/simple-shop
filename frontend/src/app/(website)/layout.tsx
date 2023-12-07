interface Children {
  children: React.ReactNode
}
export default function WebsiteLayout({ children }: Children) {
  return (
    <>
      <nav className="flex flex-row align-center justify-between">
        <div>LOGO</div>
        <div>
          <input type="search" placeholder="Buscar" />
        </div>
        <ul className="flex flex-row align-center justify-between">
          <li>
            Carrito
          </li>
          <li>
            SignIn
          </li>
        </ul>
      </nav>
      {children}
    </>
  )
}
