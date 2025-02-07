import { Component } from "react";

export class Home extends Component {
    render() {
        return (
            <div className="container mt-5">
                <section className="text-center">
                    <h1 className="display-4 mb-4">Bienvenido a Nuestra Consultoria Tecnologica</h1>
                    <p className="lead">Ofrecemos soluciones tecnologicas innovadoras que transforman tu negocio.</p>
                    <a href="#services" className="btn btn-primary btn-lg">Descubre nuestros servicios</a>
                </section>

                <section id="services" className="mt-5">
                    <h2 className="text-center mb-4">Nuestros Servicios</h2>
                    <div className="row">
                        <div className="col-md-4 mb-4">
                            <div className="card shadow-sm">
                                <div className="card-body text-center">
                                    <h5 className="card-title">Consultoria en Transformacion Digital</h5>
                                    <p className="card-text">Implementamos soluciones tecnologicas que optimizan tus procesos.</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-4 mb-4">
                            <div className="card shadow-sm">
                                <div className="card-body text-center">
                                    <h5 className="card-title">Desarrollo de Software a Medida</h5>
                                    <p className="card-text">Desarrollamos soluciones personalizadas adaptadas a las necesidades de tu empresa.</p>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-4 mb-4">
                            <div className="card shadow-sm">
                                <div className="card-body text-center">
                                    <h5 className="card-title">Automatizacion de Procesos</h5>
                                    <p className="card-text">Te ayudamos a mejorar la eficiencia operativa a traves de la automatizacion.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

                <section className="bg-light py-5 mt-5">
                    <div className="container">
                        <h2 className="text-center mb-4">¿Por que Elegirnos?</h2>
                        <p className="text-center lead">Nuestro equipo de expertos esta comprometido con el exito de tu negocio. Ofrecemos soluciones tecnologicas innovadoras y personalizadas que te permitiran destacarte en el mercado.</p>
                    </div>
                </section>
            </div>
        )
    }
}