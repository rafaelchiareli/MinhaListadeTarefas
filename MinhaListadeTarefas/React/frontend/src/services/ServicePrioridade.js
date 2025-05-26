import Api from '../helpers/api';

export default function ListarPrioridades() {
    return Api.get('/Prioridades/ListarPrioridades')
}

