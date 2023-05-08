import React from "react";
import { Container } from "react-bootstrap";
import { FaFacebookF, FaTwitter, FaLinkedinIn } from "react-icons/fa";

export default function pie(){
    return(
        <Container fluid>
            <footer className="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
                <div className="col-md-4 d-flex align-items-center">
                    <a href="https://grupobusiness.it/" target="_blank" rel="noreferrer" className="mb-3 me-2 mb-md-0 text-muted text-decoration-none lh-1">
                        <span className="mb-3 mb-md-0 text-muted">&copy; 2023 business IT, Inc</span>
                    </a>
                </div>

                <ul className="nav col-md-4 justify-content-end list-unstyled d-flex">
                    <li className="ms-3"><a className="text-muted" target="_blank" rel="noreferrer" href="https://twitter.com/GrupoBusinessIT"><FaTwitter /></a></li>
                    <li className="ms-3"><a className="text-muted" target="_blank" rel="noreferrer" href="https://www.facebook.com/GrupoBusinessIT/"><FaFacebookF /></a></li>
                    <li className="ms-3 pr-1"><a className="text-muted" target="_blank" rel="noreferrer" href="https://www.linkedin.com/company/business-it---unlimited-solutions/mycompany/verification/"><FaLinkedinIn /></a></li>
                </ul>
            </footer>
        </Container>
    )
}