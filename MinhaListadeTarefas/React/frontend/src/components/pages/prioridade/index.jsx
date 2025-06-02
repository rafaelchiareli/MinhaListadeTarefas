import React, { useState, useEffect } from "react";
import ListarPrioridades, { CadatrarPrioridade } from "../../../services/ServicePrioridade";

const Prioridades = () => {
    const [listaPrioridades, setListaPrioridades] = useState([]);
    const [descricao, setDescricao] = useState("");
    const [salvou, setSalvou] = useState(false);

    useEffect(() => {
        ListarPrioridades().then(res => setListaPrioridades(res.data));
    }, [salvou]);
    useEffect(() => { setSalvou(!salvou)},[salvou])

    const handleSalvar = () =>{
        const prioridade = {
            id: 0,
            nome: descricao
        }
        CadatrarPrioridade(prioridade).then(res => (setSalvou(true)))      
    }


    return (<div>
        <h2>Cadastro de prioridades</h2>
        <div>
            <label className="form-control">Descricao</label>
            <input onChange={(e) => setDescricao(e.target.value)}
                value={descricao} type="text" className="form-control"
            />
         
         <button onClick={handleSalvar} type="button" className="btn btn-primary mt-2">Salvar</button>
        </div>

        <h4>Prioridades cadastradas</h4>
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th key="codigo">Codigo</th>
                    <th key="descricao">Descrição</th>
                </tr>
            </thead>
            <tbody>
                {listaPrioridades && listaPrioridades?.map(item => (
                    <tr key={`linha_${item.id}`}>
                        <td key={`col_cod_${item.id}`} >{item.id}</td>
                        <td key={`col_nome_${item.id}`}>{item.nome}</td>
                    </tr>
                ))}
            </tbody>
        </table>

    </div>)
}

export default Prioridades;