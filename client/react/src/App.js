import { BrowserRouter,Route,Routes } from 'react-router-dom';
import './App.css';
import Details from './components/hmo/Details'
import Patients from './components/hmo/Patients'
import Corona from './components/hmo/Corona'

function App() {

  return (
   <div className="App">
      {/* <Patients></Patients> */}
      <BrowserRouter>
        <Routes>
          <Route path="" element={<Patients />} ></Route>
          <Route path="Details/"element={<Details/>} > </Route>
          <Route path="Corona/"element={<Corona/>} > </Route>
        </Routes>
      </BrowserRouter>
      
      
    </div>
  );
}

export default App;
