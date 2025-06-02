import Api from '../helpers/api';

export default function ListarPrioridades() {
    return Api.get('/Prioridades/ListarPrioridades')
}

export  function CadatrarPrioridade(prioridade){
    return Api.post('/Prioridades/CadastrarPriodidade', prioridade)
}

