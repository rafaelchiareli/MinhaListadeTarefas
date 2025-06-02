import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {

    return (

        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container">
               
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ms-auto">
                        <li className="nav-item">
                            <Link className="nav-link" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/prioridades">Prioridades</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/tarefas">Tarefas</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

    )
}
export default Navbar;
