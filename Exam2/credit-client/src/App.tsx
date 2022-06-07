import React from 'react';
import logo from './logo.svg';
import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Questionnaire from "./components/pages/Questionnaire";
import Result from "./components/pages/Result";
import NavigationPanel from "./components/UI/NavBar/NavigationPanel";

function App() {
  return (
      <div className={'h-100'}>
          <BrowserRouter>
              <NavigationPanel/>
              <Routes>
                <Route path='' element={<Questionnaire/>}/>
                <Route path='/result' element={<Result/>}/>
              </Routes>
        </BrowserRouter>
      </div>
  );
}

export default App;
