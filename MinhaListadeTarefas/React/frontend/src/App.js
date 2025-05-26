import React, {useEffect} from 'react';
import ListarPrioridades from './services/ServicePrioridade';
import './App.css';


function App() {

  
useEffect(() => {
 ListarPrioridades().then(res => console.log(res.data));
}
, []);
  return (
    <div>
      Meu Aplicativo
    </div>
  );
}

export default App;
