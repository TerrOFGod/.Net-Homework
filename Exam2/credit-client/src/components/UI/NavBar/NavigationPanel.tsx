import React, {useState} from 'react';
import {Link} from "react-router-dom";
import Questionnaire from "../../pages/Questionnaire";

const NavigationPanel = () => {
    const [page, setPage] = useState(0);
    return (
        <nav className='navbar navbar-light bg-light'>
            <div className='container-lg'>
                <div className='navbar-collapse navbar' id='navbarSupportedContent'>
                    <div>
                        <a className={'navbar-brand px-4'}>Instant Loan</a>
                    </div>
                    <ul className='navbar-nav flex-row'>
                        <li className='nav-item px-5'>
                            <Link to='' className={page === 0 ? 'nav-link active' : 'nav-link'} onClick={() => setPage(0)}>Questionnaire</Link>
                        </li>
                        <li className=' nav-item px-5'>
                            <Link to='/result' className={page === 1 ? 'nav-link active' : 'nav-link'} onClick={() => setPage(1)}>Result</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};

export default NavigationPanel;