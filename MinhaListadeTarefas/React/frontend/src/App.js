import React, {useEffect, Suspense, lazy} from 'react';
import { Route, Routes } from 'react-router-dom';
import ListarPrioridades from './services/ServicePrioridade';
import './App.css';
import Navbar from './components/navbar/Navbar';

const Home = lazy(() => import('./components/pages/home/Home'));
const Prioridades = lazy(() => import('./components/pages/prioridade/index'));
const Tarefas = lazy(() => import('./components/pages/tarefas/Tarefas'));

function App() {

  
useEffect(() => {
 ListarPrioridades().then(res => console.log(res.data));
}
, []);
  return (
   <>
   <Navbar />
    <div>
      Meu Aplicativo
    </div>
    <Suspense fallback={<div>Carregando...</div>}>
     <Routes>
     <Route path="/" element={<Home />} />
      <Route path="/prioridades" element={<Prioridades />} />
      <Route path="/tarefas" element={<Tarefas />} />
      <Route path="*" element={<div>Página não encontrada</div>} />
    </Routes>
    </Suspense>
   
      
     
   </>
   
  );
}

export default App;
